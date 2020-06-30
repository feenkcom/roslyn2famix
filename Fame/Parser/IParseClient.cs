using System;

namespace Fame.Parser
{
    public interface IParseClient
    {
        void BeginAttribute(String name);

        void BeginDocument();

        void BeginElement(String name);

        void EndAttribute(String name);

        void EndDocument();

        void EndElement(String name);

        void Primitive(Object value);

        void Reference(int index);

        void Reference(String name);

        void Serial(int index);

    }
}
