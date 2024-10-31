namespace ComputerScience.DataStructures
{
    public class MyHashSet
    {
        private LinkedList<int>[] _buckets;
        private const int InitialSize = 1000;

        public MyHashSet()
        {
            _buckets = new LinkedList<int>[InitialSize];
        }

        public bool Contains(int key)
        {
            var bucket = GetBucket(key);
            return bucket != null && bucket.Contains(key);
        }

        public void Add(int key)
        {
            if (Contains(key))
                return;

            var hash = GetHash(key);

            if (_buckets[hash] == null)
                _buckets[hash] = new LinkedList<int>();

            _buckets[hash].AddLast(key);
        }

        public void Remove(int key)
        {
            var bucket = GetBucket(key);
            if (bucket == null) return;

            bucket.Remove(key);
        }

        private int GetHash(int key) => Math.Abs(key % _buckets.Length);

        private LinkedList<int> GetBucket(int key) => _buckets[GetHash(key)];
    }
}
