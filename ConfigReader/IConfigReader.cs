using System;

namespace ConfigReader
{
    public interface IConfigReader: IDisposable
    {
        string Read(string prop);
        void Write(string prop, string value);
    }
}