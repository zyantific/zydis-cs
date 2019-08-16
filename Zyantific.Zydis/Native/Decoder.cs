using System.Runtime.InteropServices;

using ZyanStatus = System.UInt32;
using ZyanU8 = System.Byte;
using ZyanUSize = System.UIntPtr;

namespace Zyantific.Zydis.Native
{
    public enum DecoderMode
    {
        MINIMAL,
        AMD_BRANCHES,
        KNC,
        MPX,
        CET,
        LZCNT,
        TZCNT,
        WBNOINVD,
        CLDEMOTE,

        MAX_VALUE = CLDEMOTE
    }

    [StructLayout(LayoutKind.Sequential)]
#if ZYDIS_UNSAFE
    public unsafe struct Decoder
#else
    public struct Decoder
#endif
    {
        public MachineMode MachineMode;

        public AddressWidth AddressWidth;

#if ZYDIS_UNSAFE
        public fixed byte DecoderMode[(int)Native.DecoderMode.MAX_VALUE + 1];
#else
        [MarshalAs(UnmanagedType.ByValArray,
            ArraySubType = UnmanagedType.I1, SizeConst = (int)Native.DecoderMode.MAX_VALUE + 1)]
        public bool[] DecoderMode;
#endif

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisDecoderInit")]
        public static extern ZyanStatus Init(ref Decoder decoder, MachineMode machineMode, AddressWidth addressWidth);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisDecoderEnableMode")]
        public static extern ZyanStatus EnableMode(ref Decoder decoder, DecoderMode decoderMode,
            [MarshalAs(UnmanagedType.I1)] bool enabled);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisDecoderDecodeBuffer")]
        public static extern ZyanStatus DecodeBuffer(ref Decoder decoder,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] ZyanU8[] buffer,
            ZyanUSize length, ref DecodedInstruction instruction);
    }
}