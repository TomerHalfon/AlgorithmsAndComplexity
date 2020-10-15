using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExamp
{
    class Entry<TKey, TValue>
        {
            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

    class HashTable<TKey, TValue>: IEnumerable<Entry<TKey, TValue>>
    {
        LinkedList<Entry<TKey, TValue>>[] _innerArray;
        int ItemsCount { get; set; }
        public HashTable(int capacity)
        {
            _innerArray = new LinkedList<Entry<TKey, TValue>>[capacity];
            ItemsCount = 0;
        }
        public bool Get(TKey key, out TValue value)
        {
            int index = GetIndex(key);
            value = default(TValue);
            if (_innerArray[index] is null) return false;
            var res = _innerArray[index].FirstOrDefault(e => e.Key.Equals(key));
            if (res is null) return false;
            value = res.Value;
            return true;
        }
        public bool Set(TKey key, TValue value)
        {
            int index = GetIndex(key);
            var entry = new Entry<TKey, TValue>(key, value);
            if (!_innerArray[index].Any(e => e.Key.Equals(key))) return false;
            _innerArray[index].First.Value = entry;
            return true;
        }
        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);

            if (_innerArray[index] is null)
                _innerArray[index] = new LinkedList<Entry<TKey, TValue>>();

            else if (_innerArray[index].Any(e => e.Key.Equals(key)))
                throw new ArgumentException($"Key: {key} Exists in HashTable");

            _innerArray[index].AddLast(new Entry<TKey, TValue>(key, value));
            ItemsCount++;
            if (ItemsCount > _innerArray.Length)
            {
                ReHash();
            }
        }
        int GetIndex(TKey key)
        {
            var res = key.GetHashCode();
            res %= _innerArray.Length;
            return res;
        }

        void ReHash()
        {
            LinkedList<Entry<TKey, TValue>>[] temp = _innerArray;
            _innerArray = new LinkedList<Entry<TKey, TValue>>[_innerArray.Length * 2];
            foreach (var item in temp)
            {
                _innerArray[GetIndex(item.First.Value.Key)] = item;
            }
        }
        public IEnumerator<Entry<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (_innerArray[i] is null) continue;
                foreach (var item in _innerArray[i]) yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    class HashTableDoubleHashing<TKey, TValue>
    {
        Entry<TKey, TValue>[] _innerArray;
        public HashTableDoubleHashing(int capacity)
        {
            _innerArray = new Entry<TKey, TValue>[capacity];
        }
        int GetIndex(TKey key) => key.GetHashCode() % _innerArray.Length;
        int Step(TKey key) => key.GetHashCode() % 10;
        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);
            int step = Step(key);
            if (index + step > _innerArray.Length)
                ReHash();
            while (_innerArray[index] != null)
            {
                index += step;
                if (index + step > _innerArray.Length)
                    ReHash();
                
            }
            _innerArray[index] = new Entry<TKey, TValue>(key, value);
        }

        void ReHash()
        {
            Entry<TKey, TValue>[] temp = _innerArray;
            _innerArray = new Entry<TKey, TValue>[Convert.ToInt32(_innerArray.Length * 1.3)];
            foreach (var item in temp)
            {
                if (item is null) continue;
                Add(item.Key, item.Value);
            }
        }
    }
}
