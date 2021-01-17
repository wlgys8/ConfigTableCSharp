using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MS.Configs{
    public class ConfigFileFormatException:System.Exception{

        public ConfigFileFormatException():base(){

        }
        public ConfigFileFormatException(string err):base(err){}
    }

    public class MissingFieldException:System.Exception{

        public MissingFieldException(string fieldName,System.Type type):base($"missing field {fieldName} in type {type}"){
        }
    }

    public class ParseException:System.Exception{
        public ParseException(string rawValue,System.Type targetType):base($"can not parse {rawValue} to type {targetType}"){

        }

        public ParseException(string err):base(err){}

        public ParseException(string err,System.Exception inner):base(err,inner){}
    }

    public class DefinitionException:System.Exception{

        public DefinitionException(string err):base(err){}
    }
}
