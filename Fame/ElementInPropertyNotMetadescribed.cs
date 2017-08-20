using System;
using System.Runtime.Serialization;
using Fame.Fm3;

namespace Fame
{
	[Serializable]
	internal class ElementInPropertyNotMetadescribed : Exception
	{
		private PropertyDescription property;

		public ElementInPropertyNotMetadescribed()
		{
		}

		public ElementInPropertyNotMetadescribed(PropertyDescription property)
		{
			this.property = property;
		}

		public ElementInPropertyNotMetadescribed(string message) : base(message)
		{
		}

		public ElementInPropertyNotMetadescribed(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ElementInPropertyNotMetadescribed(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}