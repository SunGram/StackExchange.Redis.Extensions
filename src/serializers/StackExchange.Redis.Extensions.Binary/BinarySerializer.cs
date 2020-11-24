using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using StackExchange.Redis.Extensions.Core;

namespace StackExchange.Redis.Extensions.Binary
{
    /// <summary>
    /// Binary implementation of <see cref="ISerializer"/>
    /// </summary>
    public class BinarySerializer : ISerializer
    {
        private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

        /// <inheritdoc/>
        public T Deserialize<T>(byte[] serializedObject)
        {
            using var ms = new MemoryStream(serializedObject);

#pragma warning disable SYSLIB0011 // 类型或成员已过时
            return (T)binaryFormatter.Deserialize(ms);
#pragma warning restore SYSLIB0011 // 类型或成员已过时
        }

        /// <inheritdoc/>
        public byte[] Serialize(object item)
        {
            using var ms = new MemoryStream();

#pragma warning disable SYSLIB0011 // 类型或成员已过时
            binaryFormatter.Serialize(ms, item);
#pragma warning restore SYSLIB0011 // 类型或成员已过时
            return ms.ToArray();
        }
    }
}
