using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MS.Configs{

    public interface IDeserializer{

        void OnDeserialize(BinaryReader reader);
    }


    public class TableHeader{


        public ushort itemCount{
            get;internal set;
        }

        public byte version{
            get;internal set;
        }
    }

    public class Table<T>:ITable<T> where T:IDeserializer,new()
    {
        private List<T> _items = new List<T>();


        private TableHeader _header;

        public int count{
            get{
                return _items.Count;
            }
        }

        public T this[int index]{
            get{
                return _items[index];
            }
        }

        public System.Type elementType{
            get{
                return typeof(T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void From(Stream stream,uint byteOffset,uint byteLength){
            _items.Clear();
            var reader = new BinaryReaderFragment(stream,byteOffset,byteLength);
            reader.ResetPosition();
            _header = ReadHeader(reader);
            ReadItems(reader);
        }

        private void ReadItems(BinaryReader reader){
            var header = _header;
            _items = new List<T>();
            for(var i = 0; i < header.itemCount; i ++){
                var item = new T();
                item.OnDeserialize(reader);
                _items.Add(item);
                OnItemLoaded(item);
            }
        }

        protected virtual void OnItemLoaded(T item){}
        
        private static TableHeader ReadHeader(BinaryReader reader){
            var version = reader.ReadByte();
            var itemCount = reader.ReadUInt16();
            var header = new TableHeader();
            header.version = version;
            header.itemCount = itemCount;
            return header;
        }





    }
}
