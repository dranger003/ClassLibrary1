using System;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    [Guid("3EE167D4-16DC-48B6-B5A0-22E142266F73")]
    public interface IClass1
    {
        void Ping();
    }

    [Guid("D5633330-784B-4A82-93B4-DBDC4A86A128")]
    public class Class1 : IClass1
    {
        public void Ping()
        {
            Console.WriteLine("Ping()");
        }
    }
}
