using System;
using System.Runtime.InteropServices;

namespace MemoryPinningSample
{
    static class API
    {
        [DllImport("MemoryPinningCpp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Fill(IntPtr data, int value, int size);

        [DllImport("MemoryPinningCpp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FillAsync(IntPtr data, int value, int size);
   }
}