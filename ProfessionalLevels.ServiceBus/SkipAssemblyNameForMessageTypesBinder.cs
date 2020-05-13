using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfessionalLevels.ServiceBus
{
    class SkipAssemblyNameForMessageTypesBinder : ISerializationBinder
    {
        Type[] messageTypes;

        public SkipAssemblyNameForMessageTypesBinder(Type[] messageTypes)
        {
            this.messageTypes = messageTypes;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            return messageTypes.FirstOrDefault(messageType => messageType.FullName == typeName);
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = serializedType.Assembly.FullName;
            typeName = serializedType.FullName;
        }
    }
}
