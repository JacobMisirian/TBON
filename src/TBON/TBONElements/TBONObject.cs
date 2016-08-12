using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    public class TBONObject : ISerializable
    {
        public string Name { get; set; }
        public List<TBONKeyValuePair> Entries { get; private set; }

        public TBONObject(string name, params TBONKeyValuePair[] pairs)
        {
            Name = name;
            Entries = new List<TBONKeyValuePair>(pairs);
        }

        public TBONObject AddEntry(TBONKeyValuePair entry)
        {
            Entries.Add(entry);
            return this;
        }
        public TBONObject AddEntry(string key, ISerializable value)
        {
            return AddEntry(new TBONKeyValuePair(key, value));
        }
        public TBONObject AddEntry(string key, string value)
        {
            return AddEntry(new TBONKeyValuePair(key, new TBONString(value)));
        }
        public TBONObject AddEntry(string key, string[] value)
        {
            TBONString[] elements = new TBONString[value.Length];
            for (int i = 0; i < value.Length; i++)
                elements[i] = new TBONString(value[i]);
            return AddEntry(new TBONKeyValuePair(key, new TBONArray(elements)));
        }

        public string Serialize(int indent = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendFormat("({0}:\n", Name);
            foreach (var entry in Entries)
            {
                for (int i = 0; i < indent + 1; i++)
                    sb.Append("    ");
                sb.Append(entry.Serialize(indent + 1));
            }
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendLine(")");
            return sb.ToString();
        }
    }
}