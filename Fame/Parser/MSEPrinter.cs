using Fame.Internal;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Fame.Parser
{
	public class MSEPrinter : IParseClient
	{

		protected int indentation;
		protected StringBuilder stream = new StringBuilder();
		public static object UNLIMITED = new Object();
		private bool wasln;
		private string filepath;

		public MSEPrinter(string filepath)
		{
			this.filepath = filepath;
		}

		protected void Lntabs()
		{
			if (!wasln)
			{
				stream.Append('\n');
				for (int n = 0; n < indentation; n++)
				{
					stream.Append('\t');
				}

			}
			wasln = true;
		}

		public void BeginAttribute(String name)
		{
			indentation++;
			Lntabs();
			Append('(');
			Append(name);
		}

		private void Append(string name)
		{
			stream.Append(name);
		}

		private void Append(char v)
		{
			stream.Append(v);
		}

		public void BeginDocument()
		{
			// indentation++;
			Append('(');
		}


		public void BeginElement(String name)
		{
			indentation++;
			//wasln = false;
			Lntabs();
			Append('(');
			Append(name);
		}


		public void EndAttribute(String name)
		{
			Append(')');
			indentation--;
		}

		public void EndDocument()
		{
			Append(')');
			Close();
		}

		private void Close()
		{
			
			string s = stream.ToString();
			Console.WriteLine(s);
			//System.IO.File.WriteAllText(filepath, stream.ToString());
		}

		public void EndElement(String name)
		{
			Append(')');
			wasln = false;
			indentation--;
		}

		public void Primitive(Object value)
		{
			Append(' ');
			if (value == UNLIMITED)
			{
				Append('*');
			}
			else if (value.GetType() == typeof( string)) {
				string str = (string)value;
				Append('\'');
				foreach (char ch in (string)value)
				{
					if (ch == '\'') Append('\'');
					Append(ch);
				}
				Append('\'');
			} else if (value.GetType() == typeof(bool) || Number.IsNumber(value)) {
				Append(value.ToString());
			}
		}

		public void Reference(int index)
		{
				stream.Append(" (ref: "); // must prepend space!
				stream.Append(index);
				stream.Append(')');
		}

		public void Reference(String name)
		{
				stream.Append(" (ref: "); // must prepend space!
				stream.Append(name);
				stream.Append(')');
		}

		public void Serial(int index)
		{
				stream.Append(" (id: "); // must prepend space!
				stream.Append(index);
				stream.Append(')');
		}

	}
}
