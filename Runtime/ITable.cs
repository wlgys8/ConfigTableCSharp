using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace MS.Configs{

    public interface ITable:IEnumerable{

        int count{
            get;
        }
        
        void From(Stream stream,uint byteOffset,uint byteLength);

        System.Type elementType{
            get;
        }

    }
    public interface ITable<T>:IEnumerable<T>,ITable where T:IDeserializer,new()
    {

        T this[int index]{
            get;
        }
    }
}
