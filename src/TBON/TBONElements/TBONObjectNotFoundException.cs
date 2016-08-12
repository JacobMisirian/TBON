using System;

namespace TBON
{
    /// <summary>
    /// TBON object not found exception.
    /// </summary>
    public class TBONObjectNotFoundException : Exception
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public new string Message { get { return string.Format("Could not find object named {0} in {1} class!", Name, ParentClass.Name); } }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the parent class.
        /// </summary>
        /// <value>The parent class.</value>
        public TBONClass ParentClass { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TBON.TBONObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="parent">Parent.</param>
        public TBONObjectNotFoundException(string name, TBONClass parent)
        {
            Name = name;
            ParentClass = parent;
        }
    }
}

