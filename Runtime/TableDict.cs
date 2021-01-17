using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
namespace MS.Configs{
    public class TableDict<K,V> : Table<V> where V:IDeserializer,new()
    {

        private Dictionary<K,int> _keyToIndex = new Dictionary<K, int>();

        public V GetByKey(K key){
            return this[_keyToIndex[key]];
        }

        public bool ContainsKey(K key){
            return _keyToIndex.ContainsKey(key);
        }

        protected void AddKey(K key,int index){
            _keyToIndex.Add(key,index);
        }

        public IReadOnlyCollection<K> keys{
            get{
                return _keyToIndex.Keys;
            }
        }

        public IEnumerator<K> GetKeysEnumerator(){
            return _keyToIndex.Keys.GetEnumerator();
        }


    }
}
