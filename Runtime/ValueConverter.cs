// using System.Collections;
// using System.Collections.Generic;


// namespace MS.Configs{
 
//     public delegate bool ValueConverterFunc<T>(string str,out T value);

//     public delegate bool ValueConverterFunc(string str,out object value);

//     public class ValueConverterRegister<T>{

//         public static ValueConverterFunc<T> tryParse;

//     }

//     public class ValueConverter
//     {

//         private static Dictionary<System.Type,ValueConverterFunc> _convertDict = new Dictionary<System.Type, ValueConverterFunc>();

//         static ValueConverter(){
//             RegisterValueConvert<byte>((string str,out byte v)=>{
//                 return byte.TryParse(str,out v);
//             });
//             RegisterValueConvert<sbyte>((string str,out sbyte v)=>{
//                 return sbyte.TryParse(str,out v);
//             });
//             RegisterValueConvert<short>((string str,out short v)=>{
//                 return short.TryParse(str,out v);
//             });
//             RegisterValueConvert<ushort>((string str,out ushort v)=>{
//                 return ushort.TryParse(str,out v);
//             });
//             RegisterValueConvert<int>((string str,out int v)=>{
//                 return int.TryParse(str,out v);
//             });
//             RegisterValueConvert<uint>((string str,out uint v)=>{
//                 return uint.TryParse(str,out v);
//             });
//             RegisterValueConvert<long>((string str,out long v)=>{
//                 return long.TryParse(str,out v);
//             });
//             RegisterValueConvert<ulong>((string str,out ulong v)=>{
//                 return ulong.TryParse(str,out v);
//             });
            
//             RegisterValueConvert<float>((string str,out float v)=>{
//                 return float.TryParse(str,out v);
//             });
//             RegisterValueConvert((string str,out double v)=>{
//                 return double.TryParse(str,out v);
//             });
//             RegisterValueConvert((string str,out bool v)=>{
//                 return bool.TryParse(str,out v);
//             });
//             RegisterValueConvert((string str,out string v)=>{
//                 v = str;
//                 return true;
//             });
//             RegisterValueConvert((string str,out UnityEngine.Vector2 v)=>{
//                 var strs = str.Split('|');
//                 v = new UnityEngine.Vector2();
//                 if(strs.Length != 2){
//                     return false;
//                 }
//                 var x = 0f;
//                 var y = 0f;
//                 if(!TryParse<float>(strs[0],out x)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[1],out y)){
//                     return false;
//                 }
//                 v=  new UnityEngine.Vector2(x,y);
//                 return true;
//             });
//             RegisterValueConvert((string str,out UnityEngine.Vector3 v)=>{
//                 var strs = str.Split('|');
//                 v = new UnityEngine.Vector3();
//                 if(strs.Length != 3){
//                     return false;
//                 }
//                 var x = 0f;
//                 var y = 0f;
//                 var z = 0f;
//                 if(!TryParse<float>(strs[0],out x)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[1],out y)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[2],out z)){
//                     return false;
//                 }
//                 v=  new UnityEngine.Vector3(x,y,z);
//                 return true;
//             });
//             RegisterValueConvert((string str,out UnityEngine.Rect v)=>{
//                 var strs = str.Split('|');
//                 v = new UnityEngine.Rect();
//                 if(strs.Length != 4){
//                     return false;
//                 }
//                 var x = 0f;
//                 var y = 0f;
//                 var width = 0f;
//                 var height = 0f;
//                 if(!TryParse<float>(strs[0],out x)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[1],out y)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[2],out width)){
//                     return false;
//                 }
//                 if(!TryParse<float>(strs[3],out height)){
//                     return false;
//                 }
//                 v =  new UnityEngine.Rect(x,y,width,height);
//                 return true;
//             });
//             RegisterValueConvert((string str,out UnityEngine.RectOffset v)=>{
//                 var strs = str.Split('|');
//                 v = new UnityEngine.RectOffset();
//                 if(strs.Length != 4){
//                     return false;
//                 }
//                 var left = 0;
//                 var right = 0;
//                 var top = 0;
//                 var bottom = 0;
//                 if(!TryParse<int>(strs[0],out left)){
//                     return false;
//                 }
//                 if(!TryParse<int>(strs[1],out right)){
//                     return false;
//                 }
//                 if(!TryParse<int>(strs[2],out top)){
//                     return false;
//                 }
//                 if(!TryParse<int>(strs[3],out bottom)){
//                     return false;
//                 }
//                 v =  new UnityEngine.RectOffset(left,right,top,bottom);
//                 return true;
//             });
//         }

//         public static void RegisterValueConvert<T>(ValueConverterFunc<T> func){
//             if(func == null){
//                 throw new System.ArgumentNullException();
//             }
//             ValueConverterRegister<T>.tryParse = func;
//             _convertDict.Add(typeof(T),(string str, out object result)=>{
//                 result = null;
//                 if(func == null){
//                     return false;
//                 }
//                 T value;
//                 if(func(str,out value)){
//                     result = value;
//                     return true;
//                 }else{
//                     return false;
//                 }
//             });
//         }
    
//         public static bool TryParse<T>(string str,out T value){
//             var parseFunc = ValueConverterRegister<T>.tryParse;
//             if(parseFunc == null){
//                 value = default(T);
//                 return false;
//             }else{
//                 return parseFunc(str,out value);
//             }
//         }

//         public static T Parse<T>(string str){
//             T result;
//             if(TryParse<T>(str,out result)){
//                 return result;
//             }else{
//                 throw new ParseException(str,typeof(T));
//             }
//         }

 

//     }


// }
