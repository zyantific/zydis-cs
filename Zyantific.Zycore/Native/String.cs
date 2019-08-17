using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using ZyanStringFlags = System.Byte;

namespace Zyantific.Zycore.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ZyanString
    {
        public ZyanStringFlags Flags;

        public ZyanVector Vector;
    }
}
