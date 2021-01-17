using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace MS.Configs.AutoGenerate{
    public static class BinaryReaderExts
    {
        public static ulong ReadLEB128Unsigned (this BinaryReader reader) {
            int byteCnt = 0;
            return ReadLEB128Unsigned(reader,out byteCnt);
        }

        public static ulong ReadLEB128Unsigned (this BinaryReader reader, out int bytes) {
            bytes = 0;
            ulong value = 0;
            int shift = 0;
            bool more = true;
            while (more) {
                var next = reader.ReadByte();
                if (next < 0) { throw new System.InvalidOperationException("Unexpected end of reader"); }
                byte b = (byte)next;
                bytes += 1;
                more = (b & 0x80) != 0;   // extract msb
                ulong chunk = b & 0x7fUL; // extract lower 7 bits
                value |= chunk << shift;
                shift += 7;
            }
            return value;
        }

        public static string ReadStringExt(this BinaryReader reader){
            int bytesCount = 0;
            var value = reader.ReadLEB128Unsigned(out bytesCount);
            var bytes = reader.ReadBytes((int)value);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static Vector2 ReadVector2(this BinaryReader reader){
            var x = reader.ReadSingle();
            var y = reader.ReadSingle();
            return new Vector2(x,y);
        }

        public static Vector3 ReadVector3(this BinaryReader reader){
            return new Vector3(reader.ReadSingle(),reader.ReadSingle(),reader.ReadSingle());
        }

        public static Rect ReadRect(this BinaryReader reader){
            return new Rect(reader.ReadSingle(),reader.ReadSingle(),reader.ReadSingle(),reader.ReadSingle());
        }

        public static RectOffset ReadRectOffset(this BinaryReader reader){
            return new RectOffset(reader.ReadInt32(),reader.ReadInt32(),reader.ReadInt32(),reader.ReadInt32());
        }

        public static Color ReadColor(this BinaryReader reader){
            return new Color32(reader.ReadByte(),reader.ReadByte(),reader.ReadByte(),reader.ReadByte());
        }

        public static T ReadEnum<T>(this BinaryReader reader) where T: System.Enum{
            int b = reader.ReadByte();
            try{
                return (T)(object)b;
            }catch(System.InvalidCastException e){
                throw new System.InvalidCastException($"can not cast {b} to enum {typeof(T)}",e);
            }
        }
    }
}
