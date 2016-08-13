using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    /// <summary>
    /// TBON array.
    /// </summary>
    public class TBONArray : ISerializable
    {
        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <value>The elements.</value>
        public List<ISerializable> Elements { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONArray"/> class.
        /// </summary>
        /// <param name="elements">Elements.</param>
        public TBONArray(params ISerializable[] elements)
        {
            Elements = new List<ISerializable>(elements);
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
        public string Serialize(int indent = 0)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[{0}", Elements[0].Serialize(indent));
            for (int i = 1; i < Elements.Count; i++)
                sb.AppendFormat(", {0}", Elements[i].Serialize(indent));
            sb.Append("]");

            return sb.ToString();
        }
    }
}

