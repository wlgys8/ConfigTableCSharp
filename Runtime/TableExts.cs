
using System.IO;
using UnityEngine;

namespace MS.Configs{
    public static class TableExts
    {

        public static void From<T>(this Table<T> table,Stream stream) where T:IDeserializer,new() {
            table.From(stream,0,(uint)stream.Length);
        }
        public static void From<T>(this Table<T> table,Stream stream,uint offset,uint maxLength) where T:IDeserializer,new() {
            table.From(stream,offset, maxLength);
        }
        public static void FromFile<T>(this Table<T> table,string filePath) where T:IDeserializer,new(){
            var binary = System.IO.File.ReadAllBytes(filePath);
            From<T>(table,binary);
        }

        public static void From<T>(this Table<T> table,byte[] binary) where T:IDeserializer,new(){
            From(table,new MemoryStream(binary));
        }

        public static void From<T>(this Table<T> table,byte[] binary,uint offset,uint maxLength) where T:IDeserializer,new(){
            From(table,new MemoryStream(binary),offset,maxLength);
        }

        public static void FromResources<T>(this Table<T> table,string pathInResources) where T:IDeserializer,new(){
            var txtAsset = Resources.Load<TextAsset>(pathInResources);
            if(txtAsset == null){
                throw new System.IO.FileNotFoundException($"file not found at : <Resources>/{pathInResources}");
            }
            From(table,txtAsset.bytes);
        }
    }
}
