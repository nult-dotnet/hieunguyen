using System;

namespace Backend.Data.MultipleProviderHandle
{
    public static class Instance
    {
        public static IProvider GetInstance()
        {
            var type = Type.GetType($"Backend.Data.MultipleProviderHandle.Providers.{DbStringSettings.GetDefaultDbValue()}");

            if (type is null)
            {
                throw new ArgumentNullException();
            }

            var provider = Activator.CreateInstance(type) as IProvider;
            return provider;
        }
    }
}
