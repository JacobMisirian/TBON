using System;

namespace TBON
{
    /// <summary>
    /// TBON attribute not found exception.
    /// </summary>
    public class TBONAttributeNotFoundException : Exception
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public new string Message { get { return string.Format("No such attribute {0} in object {1}!", Key, ParentObject.Name); } }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; private set; }
        /// <summary>
        /// Gets the parent object.
        /// </summary>
        /// <value>The parent object.</value>
        public TBONObject ParentObject { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONAttributeNotFoundException"/> class.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="parent">Parent.</param>
        public TBONAttributeNotFoundException(string key, TBONObject parent)
        {
            Key = key;
            ParentObject = parent;
        }
    }
}

