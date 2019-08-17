using System;
using System.Collections.Generic;
using System.Text;

namespace Zyantific.Zycore.Native
{
    struct ZyanAllocator
    {
        IntPtr Allocate;

        IntPtr Reallocate;

        IntPtr Deallocate;
    }
}
