using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    /// <summary>
    /// TBON class.
    /// </summary>
    public class TBONClass : ISerializable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        public List<TBONObject> Objects { get; private set; }

        public TBONClass(string name, params TBONObject[] objects)
        {
            Name = name;
            Objects = new List<TBONObject>(objects);
        }
        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="obj">Object.</param>
        public TBONObject AddObject(TBONObject obj)
        {
            Objects.Add(obj);
            return obj;
        }
        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="name">Name.</param>
        /// <param name="pairs">Pairs.</param>
        public TBONObject AddObject(string name, params TBONKeyValuePair[] pairs)
        {
            return AddObject(new TBONObject(name, pairs));
        }
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="name">Name.</param>
        public TBONObject GetObject(string name)
        {
            foreach (var obj in Objects)
                if (obj.Name == name)
                    return obj;
            throw new TBONObjectNotFoundException(name, this);
        }
        /// <summary>
        /// Gets the object names.
        /// </summary>
        /// <returns>The object names.</returns>
        public string[] GetObjectNames()
        {
            string[] result = new string[Objects.Count];
            for (int i = 0; i < result.Length; i++)
                result[i] = Objects[i].Name;
            return result;
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
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