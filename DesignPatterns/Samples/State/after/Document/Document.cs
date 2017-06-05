using System;

namespace StatePattern
{
    public class Document : IDocument
    {
        public bool Open()
        {
            Console.WriteLine("Opening document");
            return true;
        }

        public bool Close()
        {
            Console.WriteLine("Closing document");
            return true;
        }
    }
}