using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace MS.Configs{
    public class MergedTableLoader:System.IDisposable
    {
        private TableMergeManifest _tableMergeManifest;
        private Stream _stream;

        private bool _leaveStreamOpen = false;
        private bool _disposed = false;

        public MergedTableLoader(Stream dataStream,TableMergeManifest mergeManifest,bool leaveStreamOpen = false){
            _stream = dataStream;
            _tableMergeManifest = mergeManifest;
            _leaveStreamOpen = leaveStreamOpen;
        }

        public T LoadTable<T>() where T:ITable,new(){
            AssertNotDisposed();
            var tableName = typeof(T).Name;
            tableName = tableName.Substring(0,tableName.Length - 5);
            var tableInfo = _tableMergeManifest.GetTableInfo(tableName);
            var t = new T();
            t.From(_stream,tableInfo.GetOffset(),tableInfo.GetSize());
            return t;
        }

        private void AssertNotDisposed(){
            if(_disposed){
                throw new System.ObjectDisposedException(this.GetType().Name);
            }
        }

        public void Dispose()
        {
            if(_disposed){
                return;
            }
            _disposed = true;
            if(!_leaveStreamOpen){
                _stream.Dispose();
            }
        }


        public static MergedTableLoader FromResources(string dataFilePath,string manifestFilePath){
            var data = Resources.Load<TextAsset>(dataFilePath);
            var manifestText = Resources.Load<TextAsset>(manifestFilePath);
            var manifest = TableMergeManifest.From(manifestText.text);
            var dataMemory = new MemoryStream(data.bytes);
            return new MergedTableLoader(dataMemory,manifest,false);
        }

        public static MergedTableLoader FromFile(string dataFilePath,string manifestFilePath){
            var data = File.ReadAllBytes(dataFilePath);
            var manifestText = File.ReadAllText(manifestFilePath);
            var manifest = TableMergeManifest.From(manifestText);
            var dataMemory = new MemoryStream(data);
            return new MergedTableLoader(dataMemory,manifest,false);
        }
    }
}
