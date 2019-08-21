using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ZyanUSize = System.UIntPtr;

namespace Zyantific.Zycore.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ZyanVector
    {
        public IntPtr Allocator;

        public float GrowthFactor;

        public float ShrinkThreshold;

        public ZyanUSize Size;

        public ZyanUSize Capacity;

        public ZyanUSize ElementSize;

        public IntPtr Destructor;

        public IntPtr data;
    }
}
