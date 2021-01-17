using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace MS.Configs{
    internal class BinaryReaderFragment : System.IO.BinaryReader
    {
        private uint _byteOffset;
        private uint _byteLength;
        public BinaryReaderFragment(Stream stream,uint byteOffset,uint byteLength):base(stream){
            _byteOffset = byteOffset;
            _byteLength = byteLength;
        }

        public void ResetPosition(){
            this.BaseStream.Position = _byteOffset;
        }

        private uint endPosition{
            get{
                return _byteOffset + _byteLength;
            }
        }

        protected override void FillBuffer(int numBytes)
        {
            if(BaseStream.Position + numBytes > endPosition){
                throw new System.IO.EndOfStreamException($"current position = {BaseStream.Position},endPosition = {endPosition},readBytes = {numBytes}");
            }
            base.FillBuffer(numBytes);
        }

    }
}
