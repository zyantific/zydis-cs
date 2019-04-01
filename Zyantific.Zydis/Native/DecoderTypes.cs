using System.Runtime.InteropServices;

using ZyanU8 = System.Byte;

namespace Zyantific.Zydis.Native
{
    public enum MachineMode
    {
        LONG_64,
        LONG_COMPAT_32,
        LONG_COMPAT_16,
        LEGACY_32,
        LEGACY_16,
        REAL_16,
        MAX_VALUE = REAL_16
    }

    public enum AddressWidth
    {
        WIDTH_16,
        WIDTH_32,
        WIDTH_64,
        MAX_VALUE = WIDTH_64
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstruction
    {
        public MachineMode MachineMode;

        public Mnemonic Mnemonic;

        public ZyanU8 Length;

        // Only for testing ..
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] Data;
    }
}