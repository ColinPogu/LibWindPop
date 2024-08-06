using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LibWindPop.Texts.LawnStrings
{
    public class LawnStringDictionary<T1, T2> : IDictionary<T1, T2>
        where T1 : class
        where T2 : class
    {
        private readonly List<T1> _list1;
        private readonly List<T2> _list2;

        public LawnStringDictionary()
        {
            _list1 = new List<T1>();
            _list2 = new List<T2>();
        }

        public T2 this[T1 key]
        {
            get => _list2[_list1.IndexOf(key)];
            set => _list2[_list1.IndexOf(key)] = value;
        }

        public KeyValuePair<T1, T2> this[int index]
        {
            get => new KeyValuePair<T1, T2>(_list1[index], _list2[index]);
        }

        public ICollection<T1> Keys => _list1;

        public ICollection<T2> Values => _list2;

        public int Count => _list1.Count;

        public bool IsReadOnly => false;

        public void Add(T1 key, T2 value)
        {
            _list1.Add(key);
            _list2.Add(value);
        }

        public void Add(KeyValuePair<T1, T2> item)
        {
            _list1.Add(item.Key);
            _list2.Add(item.Value);
        }

        public void Clear()
        {
            _list1.Clear();
            _list2.Clear();
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_list1[i] == item.Key && _list2[i] == item.Value)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(T1 key)
        {
            return _list1.Contains(key);
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T1 key)
        {
            int index = _list1.IndexOf(key);
            if (index >= 0)
            {
                _list1.RemoveAt(index);
                _list2.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_list1[i] == item.Key && _list2[i] == item.Value)
                {
                    _list1.RemoveAt(i);
                    _list2.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(T1 key, [MaybeNullWhen(false)] out T2 value)
        {
            int index = _list1.IndexOf(key);
            if (index >= 0)
            {
                value = _list2[index];
                return true;
            }
            value = null;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
