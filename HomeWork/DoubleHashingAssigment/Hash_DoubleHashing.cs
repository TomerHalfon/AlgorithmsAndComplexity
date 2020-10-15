using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleHashingAssigment
{
    class Hash_DoubleHashing<TKey, TValue>: IEnumerable<KeyValuePair<TKey, TValue>>
    {
        //The private entry data model
       class Data
        {
            public TKey key;
            public TValue val;
            public bool isDeleted;

            public Data(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
                this.isDeleted = false;
            }
            public override string ToString()
            {
                return $"Key => {key} value => {val}";
            }
        }

        //Single Cell Status:
        // Empty - data will be null 
        // Deleted - for existing data(data not null) where isDeleted is true
        // Occupied - for existing data (data not null) where isDeleted is false

        Data[] _arr;
        const double M = 1.35; //extra 35% space
        int _itemsCnt;
        int _maxItems;
        public int Count => _itemsCnt;
        public Hash_DoubleHashing(int capacity = 2)
        {
            if (capacity < 2) capacity = 2;  //minimum capacity

            //Add 35 percent more to the size of the array relative to the maximum expected items
            int size = FindClosestPrimeNumber((int)(M * capacity));   //size must be prime number

            _itemsCnt = 0;
            _maxItems = capacity;

            _arr = new Data[size];
        }

        #region Main Methods
        //indexers
        public TValue this[TKey key]
        {
            get
            {
                if (SearchByKey(key, out int index)) return _arr[index].val;
                throw new KeyNotFoundException($"No such key => {key}");
            }
            set
            {
                if (SearchByKey(key, out int index)) _arr[index].val = value;
                else throw new KeyNotFoundException($"No such key => {key}");
            }
        }

        //Add method
        public void Add(TKey key, TValue value)
        {
            Data data = new Data(key, value);
            if (SearchByKey(data.key, out int index))
            {
                throw new ArgumentException($"Key duplication isn't allowed => KEY: {data.key}");
            }
            _arr[index] = data;

            _itemsCnt++;

            if (_itemsCnt >= _maxItems) ReHash();
        }

        //Delete method
        public bool Delete(TKey keyToDelete, out TValue value)
        {
            value = default(TValue);
            // if the cell is occupied by different key -> calculate step and loop till you find the match(this is your item) or empty cell(no such item)
            if (!SearchByKey(keyToDelete, out int index)) return false;

            //If the key is found - mark the cell as deleted and save its value
            _arr[index].isDeleted = true;
            value = _arr[index].val;
            _itemsCnt--;
            return true;
        }

        //ReHash method
        void ReHash()
        {
            //double the size of array and find the closest prime value to new size
            var tmpArray = _arr;
            _arr = new Data[FindClosestPrimeNumber(_arr.Length * 2)];

            // double the maxItems
            _maxItems *= 2;
            _itemsCnt = 0;

            // realocate all the existed items 
            //(we also keep the deleted cells, the reason is that later we can be sure that when the cell of the index is null then the key doesn't exist)
            foreach (var item in tmpArray)
            {
                if (item is null || item.isDeleted) continue;
                Add(item.key, item.val);
            }
        }
        #endregion
        #region Helping Methods
        //Search an element by key and return its index (resIndex) ['-1' if false!]
        bool SearchByKey(TKey key, out int index)
        {
            index = CalcHashCode(key);
            int step = Step(key);
            while (_arr[index] != null)
            {
                if (_arr[index].key.Equals(key))
                    return !_arr[index].isDeleted;

                MoveIndex(ref index, step);
            }
            return false;
        }

        //to progress the index with the step in a circular way
        void MoveIndex(ref int index, int step) => index = (index + step) % _arr.Length;

        //checks if a cell is empty or deleted
        bool IsEmptyCell(int index) => _arr[index] is null || _arr[index].isDeleted;
        
        //finds the nearest prime number
       public int FindClosestPrimeNumber(int size)
        {
            //checks if the parameter is a prime number
            bool IsPrime(int num)
            {
                //if the parameter is an even number it's not prime (excluding '2')
                if (num != 2 && num % 2 == 2) return false;
                //loop to the sqrt of the parameter only to the odd numbers
                for (int i = 3; i < Math.Sqrt(num); i += 2) 
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
            int positiveProgression, negativeProgression, res;
            //if the size is even
            if (size % 2 == 0)
            {
                positiveProgression = size + 1;
                negativeProgression = size - 1;
            }
            else positiveProgression = negativeProgression = size;
            while (true)
            {
                //check the positive progression
                if (IsPrime(positiveProgression))
                {
                    res = positiveProgression;
                    break;
                }
                //check the negative progression
                if (IsPrime(negativeProgression))
                {
                    res = negativeProgression;
                    break;
                }
                //jump with odd numbers only
                positiveProgression += 2;
                negativeProgression -= 2;
            }
            return res;
        }
        #endregion
        #region Hashing Methods
        //calculate index by key
        int CalcHashCode(TKey key) => Math.Abs(key.GetHashCode() % _arr.Length);
        int Step(TKey key) 
        {
            string s = key.ToString();
            int step = (Convert.ToInt32(s[0]) + Convert.ToInt32(s[s.Length - 1])) % _arr.Length;
            return step == 0 ? 1 : step;
        }
        #endregion

        //IEnumrable implementation *Not Required for the assigment*
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (!IsEmptyCell(i)) 
                    yield return new KeyValuePair<TKey, TValue>(_arr[i].key, _arr[i].val);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}