namespace ComputerScience.DataStructures
{
    public class MyHashMap
    {
        private class KeyValuePairInt
        {
            public required int Key;
            public required int Value;
        }

        private LinkedList<KeyValuePairInt>[] _buckets;
        private const int INITIAL_SIZE = 1000;

        public MyHashMap()
        {
            _buckets = new LinkedList<KeyValuePairInt>[INITIAL_SIZE];
        }

        public void Put(int key, int value)
        {
            var bucket = GetOrCreateBucket(key);
            var keyValue = FindKeyValuePair(bucket, key);

            if (keyValue == null)
                bucket.AddLast(new KeyValuePairInt { Key = key, Value = value });
            else
                keyValue.Value = value;
        }

        public int Get(int key)
        {
            var bucket = GetBucket(key);
            var keyValue = FindKeyValuePair(bucket, key);

            return keyValue?.Value ?? -1;
        }

        public void Remove(int key)
        {
            var bucket = GetBucket(key);
            var keyValue = FindKeyValuePair(bucket, key);

            if (keyValue != null)
                bucket!.Remove(keyValue);
        }

        private LinkedList<KeyValuePairInt> GetOrCreateBucket(int key)
        {
            var hash = GetHash(key);
            return _buckets[hash] ??= new LinkedList<KeyValuePairInt>();
        }

        private LinkedList<KeyValuePairInt>? GetBucket(int key)
        {
            var hash = GetHash(key);
            return _buckets[hash];
        }

        private KeyValuePairInt? FindKeyValuePair(LinkedList<KeyValuePairInt>? bucket, int key) => bucket?.FirstOrDefault(pair => pair.Key == key);

        private int GetHash(int key) => Math.Abs(key % _buckets.Length);
    }
}
