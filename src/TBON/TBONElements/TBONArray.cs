using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    public class TBONArray : ISerializable
    {
        public List<ISerializable> Elements { get; private set; }

        public TBONArray(params ISerializable[] elements)
        {
            Elements = new List<ISerializable>(elements);
        }

        public string Serialize(int indent = 0)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[ {0}", Elements[0].Serialize(indent));
            for (int i = 1; i < Elements.Count; i++)
                sb.AppendFormat(", {0}", Elements[i].Serialize(indent));
            sb.Append("]");

            return sb.ToString();
        }
    }
}

