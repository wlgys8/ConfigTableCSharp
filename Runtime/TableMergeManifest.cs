using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MS.Configs{

    [System.Serializable]
    public class TableMergeManifest:ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TableInfo> tables;

        private Dictionary<string,TableInfo> _tableDict = new Dictionary<string, TableInfo>();


        public bool Contains(string tableName){
            return _tableDict.ContainsKey(tableName);
        }
        
        public TableInfo GetTableInfo(string tableName){
            TableInfo table;
            if(_tableDict.TryGetValue(tableName,out table)){
                return table;
            }
            throw new KeyNotFoundException("can not find table with name = " + tableName);
        }

        public static TableMergeManifest From(string text){
            return JsonUtility.FromJson<TableMergeManifest>(text);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            _tableDict.Clear();
            foreach(var t in tables){
                _tableDict.Add(t.GetName(),t);
            }
        }

        [System.Serializable]
        public class TableInfo{

            [SerializeField]
            private string name;
            [SerializeField]
            private uint offset;
            [SerializeField]
            private uint size;

            public string GetName(){
                return this.name;
            }

            public uint GetOffset(){
                return this.offset;
            }

            public uint GetSize(){
                return size;
            }
        }
    }
}
