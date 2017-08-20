using System;
using Fame.Fm3;

namespace Fame.Internal
{
	internal class UnknownElementError : Exception
	{
		private Element description;
		private object element;

		public UnknownElementError()
		{
		}

		public UnknownElementError(string message) : base(message)
		{
		}

		public UnknownElementError(Element description, object element)
		{
			this.description = description;
			this.element = element;
		}

		public UnknownElementError(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}