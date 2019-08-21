using System;
using System.Runtime.InteropServices;

namespace Zyantific.Zycore.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ZyanAllocator
    {
        private readonly IntPtr Allocate;

        private readonly IntPtr Reallocate;

        private readonly IntPtr Deallocate;
    }
}