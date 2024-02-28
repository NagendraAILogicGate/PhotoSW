using System;
using System.Globalization;
using System.Threading;

namespace PhotoSW.Common
{
	public interface IInstantiateProperty
	{
		void InstantiateProperty(string propertyName, System.Globalization.CultureInfo culture, System.Threading.SynchronizationContext callbackExecutionContext);
	}
}
