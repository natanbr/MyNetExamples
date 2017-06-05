using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericApp
{
    internal class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private readonly Dictionary<K, LinkedList<V>> _dictionary;

        public MultiDictionary()
        {
            _dictionary = new Dictionary<K, LinkedList<V>>();
        }

        #region IMultiDictionary<K, V>

        public void Add(K key, V value)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].AddLast(value);
            }
            else
            {
                var list = new LinkedList<V>();
                list.AddLast(value);
                _dictionary[key] = list;
            }
        }

        public bool Remove(K key)
        {
            return _dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            if (!_dictionary.ContainsKey(key))
                return false;

            return _dictionary[key].Remove(value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Contains(K key, V value)
        {
            if (!_dictionary.ContainsKey(key))
                return false;

            return _dictionary[key].Contains(value);
        }

        public ICollection<K> Keys { get { return _dictionary.Keys; }}

        public ICollection<V> Values
        {
            get { return _dictionary.Values.SelectMany(list => list).ToList(); }
        }

        public int Count { get { return Values.Count; }}

        #endregion

        #region IEnumerable<KeyValuePair<K, V>>
        
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return _dictionary.SelectMany(GetKeyValues).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static IEnumerable<KeyValuePair<K, V>> GetKeyValues(KeyValuePair<K, LinkedList<V>> kv)
        {
            return kv.Value.Select(v => new KeyValuePair<K, V>(kv.Key, v));
        }

        #endregion
    }
}