using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    public class TBONKeyValuePair : ISerializable
    {
        public string Key { get; set; }
        public ISerializable Value { get; set; }

        public TBONKeyValuePair(string key)
        {
            Key = key;
        }
        public TBONKeyValuePair(string key, ISerializable value)
        {
            Key = key;
            Value = value;
        }

        public string Serialize(int indent = 0)
        {
            return string.Format("{0} : {1}\n",Key, Value.Serialize(indent + 1));
        }
    }
}

