using System;
using System.Collections.Generic;
using System.Text;

namespace TBON
{
    /// <summary>
    /// TBON key value pair.
    /// </summary>
    public class TBONKeyValuePair : ISerializable
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public ISerializable Value { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONKeyValuePair"/> class.
        /// </summary>
        /// <param name="key">Key.</param>
        public TBONKeyValuePair(string key)
        {
            Key = key;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONKeyValuePair"/> class.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public TBONKeyValuePair(string key, ISerializable value)
        {
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
        public string Serialize(int indent = 0)
        {
            return string.Format("{0} : {1}\n",Key, Value.Serialize(indent + 1));
        }
    }
}

