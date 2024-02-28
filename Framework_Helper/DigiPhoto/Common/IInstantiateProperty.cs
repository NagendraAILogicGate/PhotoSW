namespace DigiPhoto.Common
{
    using System;
    using System.Globalization;
    using System.Threading;

    public interface IInstantiateProperty
    {
        void InstantiateProperty(string propertyName, CultureInfo culture, SynchronizationContext callbackExecutionContext);
    }
}

