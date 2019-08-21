using System;
using System.Runtime.InteropServices;

namespace Zyantific.Zycore.Native
{
    [Flags]
    public enum ZyanStringFlags : byte
    {
        HAS_FIXED_CAPACITY = 0x01
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ZyanString
    {
        private readonly ZyanStringFlags Flags;

        private readonly ZyanVector Vector;
    }
}