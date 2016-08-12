using System;

namespace TBON
{
    /// <summary>
    /// TBON string.
    /// </summary>
    public class TBONString : ISerializable
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONString"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public TBONString(string value)
        {
            Value = value;
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
        public string Serialize(int indent = 0)
        {
            return string.Format("\"{0}\"", Value);
        }
    }
}

