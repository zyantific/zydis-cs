using System.Runtime.InteropServices;
using System.Text;

using ZyanStatus = System.UInt32;
using ZyanU64 = System.UInt64;
using ZyanUSize = System.UIntPtr;

namespace Zyantific.Zydis.Native
{
    public enum FormatterStyle
    {
        ATT,
        INTEL,
        INTEL_MASM,
        MAX_VALUE = INTEL_MASM
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Formatter
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] Data;

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterInit")]
        public static extern ZyanStatus Init(ref Formatter formatter, FormatterStyle style);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true, CharSet = CharSet.Ansi,
            EntryPoint = "ZydisFormatterFormatInstruction")]
        public static extern ZyanStatus FormatInstruction(ref Formatter formatter,
            ref DecodedInstruction instruction,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, ZyanUSize length,
            ZyanU64 runtimeAddress);
    }
}