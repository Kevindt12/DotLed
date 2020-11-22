using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using AutoMapper;

using DotLed.Domain.EventsArgs;
using DotLed.Domain.Factories;
using DotLed.Domain.Models;
using DotLed.Domain.Services.Devices;
using DotLed.Infrastructure.Data;
using DotLed.Infrastructure.Extentions;

using Microsoft.Extensions.Configuration;

namespace DotLed.Infrastructure.Services
{
	public class DeviceFileService : IDeviceFileService, IDeviceFileCollectorService, IDisposable
	{

		private bool disposedValue;
		private readonly FileSystemWatcher _fileSystemWatcher;
		private bool _supppressNextWatcherEvent;



		/// <summary>
		/// The event that will trigger when a new file has been found.
		/// </summary>
		public event EventHandler<DeviceFileFoundEventArgs> NewFileFound;



		/// <summary>
		/// Configuration
		/// </summary>
		public IConfiguration Configuration { get; init; }

		public SpiBusFactory SpiBusFactory { get; init; }

		/// <summary>
		/// Automapper
		/// </summary>
		public IMapper Mapper { get; init; }

		/// <summary>
		/// The devices and location of the files.
		/// </summary>
		protected IDictionary<string, DeviceFile> DeviceLocationAndFiles { get; init; }


		/// <summary>
		/// The folder location where we check for the files.
		/// </summary>
		public string FolderLocation { get; init; }



		/// <summary>
		/// The device file service.
		/// </summary>
		/// <param name="configuration">The configuration of the application.</param>
		public DeviceFileService(IConfiguration configuration, SpiBusFactory spiBusFactory)
		{
			Configuration = configuration;
			DeviceLocationAndFiles = new Dictionary<string, DeviceFile>();

			// Populate the dictionary that we just created.
			ReadAllFilesFromDirectoryToDictornay();

			_supppressNextWatcherEvent = false;

			_fileSystemWatcher = FileSystemWatcherBuilder(configuration);
		}



		/// <summary>
		/// Builds the watcher.
		/// </summary>
		/// <param name="configuration">The configuration of the watcher.</param>
		/// <returns></returns>
		protected virtual FileSystemWatcher FileSystemWatcherBuilder(IConfiguration configuration)
		{
			FileSystemWatcher watcher = new FileSystemWatcher();

			// Beginning the initialization of the watcher.
			watcher.BeginInit();

			// Set the settings of the watcher and the directory.
			watcher.Path = configuration.GetDeviceFilesFolderLocation();
			watcher.Filter = "*.json";
			watcher.IncludeSubdirectories = true;

			AttachWatcherEvents(watcher);

			watcher.EndInit();

			return watcher;
		}


		/// <summary>
		/// Attaches the events to the watcher.
		/// </summary>
		/// <param name="watcher"></param>
		protected void AttachWatcherEvents(FileSystemWatcher watcher)
		{
			watcher.Changed += FileSystemWatcher_Changed;
			watcher.Created += FileSystemWatcher_Created;
			watcher.Renamed += FileSystemWatcher_Renamed;
			watcher.Deleted += FileSystemWatcher_Deleted;
			watcher.EnableRaisingEvents = true;
		}


		/// <summary>
		/// This will suppress the next watcher event from being called.
		/// </summary>
		protected void SuppressNextWatcherEvent()
		{
			_supppressNextWatcherEvent = true;
		}


		protected void UnsuppressWatcherEvents()
		{
			_supppressNextWatcherEvent = false;
		}





		/// <summary>
		/// Gets all the file names from the directory.
		/// </summary>
		/// <returns></returns>
		protected virtual IEnumerable<string> GetAllJsonFileLocationsForFileInFolder()
		{
			return Directory.GetFiles(FolderLocation, "*.json", SearchOption.AllDirectories);
		}


		/// <summary>
		/// Reads all that is in the folder location and saves it in the dictonary.
		/// </summary>
		/// <param name="fileLocationsAndFiles"></param>
		/// <returns></returns>
		private void ReadAllFilesFromDirectoryToDictornay()
		{
			// Clear the list so we can do this before we do more.
			DeviceLocationAndFiles.Clear();

			foreach (string fileLocation in GetAllJsonFileLocationsForFileInFolder()) {

				DeviceFile file = JsonSerializer.Deserialize<DeviceFile>(File.ReadAllText(fileLocation));

				// Add it to the dictionary
				DeviceLocationAndFiles.Add(fileLocation, file);
			}
		}


		/// <summary>
		/// Gets all the device files.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<DeviceFile> GetDeviceFiles()
		{
			ReadAllFilesFromDirectoryToDictornay();

			return DeviceLocationAndFiles.Values;
		}


		/// <summary>
		/// Gets all the devices that are found.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Device> GetDevices()
		{
			ReadAllFilesFromDirectoryToDictornay();

			return DeviceLocationAndFiles.Values.Select(x => Mapper.Map<DeviceFile, Device>(x));
		}


		/// <summary>
		/// Removes a json file from the store.
		/// </summary>
		/// <param name="jsonFile"></param>
		public void RemoveFile(DeviceFile jsonFile)
		{
			// Suppressing events so we can do a delete action and not throw a event.
			SuppressNextWatcherEvent();

			// The file location of this file.
			string fileLocation = DeviceLocationAndFiles.Single(x => x.Value.Name == jsonFile.Name).Key;

			File.Delete(fileLocation);

			DeviceLocationAndFiles.Remove(fileLocation);
		}




		/// <summary>
		/// Triggerd then the file watcher has found that a file has been deleted.
		/// </summary>
		protected virtual void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
			// Suppress the event and then return.
			if (_supppressNextWatcherEvent) {
				UnsuppressWatcherEvents();
				return;
			}

			DeviceLocationAndFiles.Remove(e.FullPath);
		}

		/// <summary>
		/// Triggerd when the file watcher has found a file to be renamed.
		/// </summary>
		protected virtual void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
		{
			// Suppress the event and then return.
			if (_supppressNextWatcherEvent) {
				UnsuppressWatcherEvents();
				return;
			}

			DeviceFile file = JsonSerializer.Deserialize<DeviceFile>(File.ReadAllText(e.FullPath));

			// Removing the old file and adding the new one.
			DeviceLocationAndFiles.Remove(e.OldFullPath);
			DeviceLocationAndFiles.Add(e.FullPath, file);

		}

		/// <summary>
		/// Triggerd when the file watcher has found a file to be created.
		/// </summary>
		protected virtual void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
			// Suppress the event and then return.
			if (_supppressNextWatcherEvent) {
				UnsuppressWatcherEvents();
				return;
			}

			DeviceFile file = JsonSerializer.Deserialize<DeviceFile>(File.ReadAllText(e.FullPath));

			DeviceLocationAndFiles.Add(e.FullPath, file);
		}

		/// <summary>
		/// When the file watcher has found a file to be changed.
		/// </summary>
		protected virtual void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			// Suppress the event and then return.
			if (_supppressNextWatcherEvent) {
				UnsuppressWatcherEvents();
				return;
			}

			DeviceLocationAndFiles[e.FullPath] = JsonSerializer.Deserialize<DeviceFile>(File.ReadAllText(e.FullPath));
		}




		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue) {
				if (disposing) {
					_fileSystemWatcher?.Dispose();
				}

				disposedValue = true;
			}
		}


		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}


	}
}
