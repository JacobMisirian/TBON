using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    /// <summary>
    /// TBON object.
    /// </summary>
    public class TBONObject : ISerializable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <value>The entries.</value>
        public List<TBONKeyValuePair> Attributes { get; private set; }
        /// <summary>
        /// Gets the parent class.
        /// </summary>
        /// <value>The parent class.</value>
        public TBONClass ParentClass { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONObject"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="pairs">Pairs.</param>
        public TBONObject(string name, TBONClass parent, params TBONKeyValuePair[] pairs)
        {
            Name = name;
            ParentClass = parent;
            Attributes = new List<TBONKeyValuePair>(pairs);
        }
        /// <summary>
        /// Adds the Attribute.
        /// </summary>
        /// <returns>The Attribute.</returns>
        /// <param name="Attribute">Attribute.</param>
        public TBONObject AddAttribute(TBONKeyValuePair Attribute)
        {
            Attributes.Add(Attribute);
            return this;
        }
        /// <summary>
        /// Adds the Attribute.
        /// </summary>
        /// <returns>The Attribute.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONObject AddAttribute(string key, ISerializable value)
        {
            return AddAttribute(new TBONKeyValuePair(key, value));
        }
        /// <summary>
        /// Adds the Attribute.
        /// </summary>
        /// <returns>The Attribute.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONObject AddAttribute(string key, string value)
        {
            return AddAttribute(new TBONKeyValuePair(key, new TBONString(value)));
        }
        /// <summary>
        /// Adds the Attribute.
        /// </summary>
        /// <returns>The Attribute.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONObject AddAttribute(string key, string[] value)
        {
            TBONString[] elements = new TBONString[value.Length];
            for (int i = 0; i < value.Length; i++)
                elements[i] = new TBONString(value[i]);
            return AddAttribute(new TBONKeyValuePair(key, new TBONArray(elements)));
        }
        /// <summary>
        /// Containses the attribute.
        /// </summary>
        /// <returns><c>true</c>, if attribute was containsed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        public bool ContainsAttribute(string key)
        {
            foreach (var attribute in Attributes)
                if (attribute.Key == key)
                    return true;
            return false;
        }
        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="key">Key.</param>
        public TBONKeyValuePair GetAttribute(string key)
        {
            foreach (var attribute in Attributes)
                if (attribute.Key == key)
                    return attribute;
            throw new TBONAttributeNotFoundException(key, this);
        }
        /// <summary>
        /// Sets the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="">.</param>
        public TBONKeyValuePair SetAttribute(string key, ISerializable value)
        {
            var attribute = GetAttribute(key);
            attribute.Value = value;
            return attribute;
        }
        /// <summary>
        /// Sets the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONKeyValuePair SetAttribute(string key, string value)
        {
            return SetAttribute(key, new TBONString(value));
        }
        /// <summary>
        /// Sets the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONKeyValuePair SetAttribute(string key, string[] value)
        {
            TBONString[] elements = new TBONString[value.Length];
            for (int i = 0; i < elements.Length; i++)
                elements[i] = new TBONString(value[i]);
            return SetAttribute(key, new TBONArray(elements));
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
            sb.AppendFormat("({0}:\n", Name);

            if (ParentClass.IsPrototype)
            {
                for (int i = 0; i < indent + 1; i++)
                    sb.Append("    ");
                foreach (string proto in ParentClass.Prototypes)
                    foreach (var attrib in Attributes)
                        if (attrib.Key == proto)
                            sb.AppendFormat("{0}, ", attrib.Value.Serialize());
                sb.Remove(sb.Length - 2, 1);
                sb.AppendLine();
            }
            else
            {
                foreach (var Attribute in Attributes)
                {
                    for (int i = 0; i < indent + 1; i++)
                        sb.Append("    ");
                    sb.Append(Attribute.Serialize(indent + 1));
                }
            }
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendLine(")");
            return sb.ToString();
        }
    }
}