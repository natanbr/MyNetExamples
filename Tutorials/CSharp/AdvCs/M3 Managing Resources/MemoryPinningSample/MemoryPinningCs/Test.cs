using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MemoryPinningSample
{
    class Test
    {
        private object[] _objs;

        public Test()
        {
            CreateObjects();
        }

        unsafe public void Run()
        {
            //Run(FillUsingGCHandle, 52);
            //Run(FillAsyncPinning, 34);
            //Run(FillUsingFixed, 2);
            Run(FillNoFixed, 12);
        }

        private void Run(Action<byte[], int> func, int value, bool expectedFail = false)
        {
            byte[] data = new byte[100];

            try
            {
                Console.Write(func.Method.Name);

                func(data, value);
                CheckValue(data, value);

                Console.WriteLine(expectedFail ? "  FAILED" : "  PASSED");
            }
            catch (Exception e)
            {
                if (expectedFail)
                    Console.WriteLine("  PASSED");
                else
                    Console.WriteLine("  FAILED {0}", e);
            }
        }

        private void FillUsingGCHandle(byte[] data, int value)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Normal);
            API.Fill(handle.AddrOfPinnedObject(), value, data.Length);

            handle.Free();
        }

        private void FillAsyncPinning(byte[] data, int value)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            API.FillAsync(handle.AddrOfPinnedObject(), value, data.Length);

            CollectObjects();

            Thread.Sleep(2000);

            handle.Free();
        }

        private unsafe void FillUsingFixed(byte[] data, int value)
        {
            fixed (byte* pData = data)
            {
                API.Fill((IntPtr)pData, value, data.Length);
            }
        }

        private unsafe void FillNoFixed(byte[] data, int value)
        {
            IntPtr address = IntPtr.Zero;

            fixed (byte* pData = data)
            {
                address = (IntPtr)pData;
            }

            CollectObjects();

            API.Fill(address, value, data.Length);
        }

        private void CheckValue(byte[] data, int value)
        {
            foreach (byte b in data)
            {
                if (b != value)
                {
                    throw new Exception("Value");
                }
            }
        }

        private void CreateObjects()
        {
            _objs = new object[100000];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new Object();
            }
        }

        private void CollectObjects()
        {
            _objs = null;
            GC.Collect();
        }
    }
}