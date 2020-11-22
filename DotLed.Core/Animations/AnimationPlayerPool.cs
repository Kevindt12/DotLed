using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotLed.Core.Animations
{
	public class AnimationPlayerPool : IAnimationPlayerPool
	{
		public int Count { get; }
		public bool IsReadOnly { get; }

		private List<AnimationPlayer> _pool;

		

		public AnimationPlayerPool()
		{
			_pool = new List<AnimationPlayer>();
		}


		public void Add(AnimationPlayer item)
		{
			_pool.Add(item);
		}

		public void Clear()
		{
			_pool.ForEach(x => x?.Dispose());
			_pool.Clear();
		}

		public bool Contains(AnimationPlayer item)
		{
			return _pool.Contains(item);
		}

		public void CopyTo(AnimationPlayer[] array, int arrayIndex)
		{
			_pool.CopyTo(array, arrayIndex);
		}

		public IEnumerator<AnimationPlayer> GetEnumerator()
		{
			return _pool.GetEnumerator();
		}

		public bool Remove(AnimationPlayer item)
		{
			_pool.Single(x => x == item).Dispose();
			return _pool.Remove(item);
		}

		public void StartAllPlayers()
		{
			_pool.ForEach(x => x.Start());
		}

		public void StopAllPayers()
		{
			_pool.ForEach(x => x.Stop());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)_pool.GetEnumerator();
		}
	}
}
