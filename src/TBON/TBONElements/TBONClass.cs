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
        /// <summary>
        /// Gets the prototypes.
        /// </summary>
        /// <value>The prototypes.</value>
        public List<string> Prototypes { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this instance is prototype.
        /// </summary>
        /// <value><c>true</c> if this instance is prototype; otherwise, <c>false</c>.</value>
        public bool IsPrototype { get { return Prototypes.Count > 0; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONClass"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="objects">Objects.</param>
        public TBONClass(string name, params TBONObject[] objects)
        {
            Name = name;
            Prototypes = new List<string>();
            Objects = new List<TBONObject>(objects);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONClass"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="prototypes">Prototypes.</param>
        /// <param name="objects">Objects.</param>
        public TBONClass(string name, string[] prototypes, params TBONObject[] objects)
        {
            Name = name;
            Prototypes = new List<string>(prototypes);
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
            return AddObject(new TBONObject(name, this, pairs));
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
            if (IsPrototype)
            {
                sb.AppendFormat(" ({0}", Prototypes[0]);
                for (int i = 1; i < Prototypes.Count; i++)
                    sb.AppendFormat(", {0}", Prototypes[i]);
                sb.Append(")");
            }
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