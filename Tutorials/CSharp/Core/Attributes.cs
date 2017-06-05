using System;

namespace CSharp.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    class Attributes : Attribute
    {
        private bool _executable;

        public Attributes(bool executable = true)
        {
            _executable = executable;
        }
    }
}
