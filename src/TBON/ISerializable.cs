using System;

namespace TBON
{
    public interface ISerializable
    {
        string Serialize(int indent = 0);
    }
}

