using System;

namespace TBON
{
    public class TBONString : ISerializable
    {
        public string Value { get; set; }
        public TBONString(string value)
        {
            Value = value;
        }

        public string Serialize(int indent = 0)
        {
            return string.Format("\"{0}\"", Value);
        }
    }
}

