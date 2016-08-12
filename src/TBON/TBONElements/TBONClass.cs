using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    public class TBONClass : ISerializable
    {
        public string Name { get; set; }
        public List<TBONObject> Objects { get; private set; }

        public TBONClass(string name, params TBONObject[] objects)
        {
            Name = name;
            Objects = new List<TBONObject>(objects);
        }

        public TBONObject AddObject(TBONObject obj)
        {
            Objects.Add(obj);
            return obj;
        }
        public TBONObject AddObject(string name, params TBONKeyValuePair[] pairs)
        {
            return AddObject(new TBONObject(name, pairs));
        }

        public string Serialize(int indent = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.Append(Name);
            sb.AppendLine(" {");

            foreach (var obj in Objects)
            {
                for (int i = 0; i < indent; i++)
                    sb.Append("    ");
                sb.Append(obj.Serialize(indent + 1));
            }
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.Append("}");

            return sb.ToString();
        }
    }
}