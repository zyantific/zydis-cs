using System.Runtime.InteropServices;
using System.Text;
using ZyanStatus = System.UInt32;
using ZyanU64 = System.UInt64;
using ZyanU8 = System.Byte;
using ZyanUPointer = System.UIntPtr;

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

    public enum FormatterProperty
    {
        FORCE_SIZE,
        FORCE_SEGMENT,
        FORCE_RELATIVE_BRANCHES,
        FORCE_RELATIVE_RIPREL,
        PRINT_BRANCH_SIZE,
        DETAILED_PREFIXES,
        ADDR_BASE,
        ADDR_SIGNEDNESS,
        ADDR_PADDING_ABSOLUTE,
        ADDR_PADDING_RELATIVE,
        DISP_BASE,
        DISP_SIGNEDNESS,
        DISP_PADDING,
        IMM_BASE,
        IMM_SIGNEDNESS,
        IMM_PADDING,
        UPPERCASE_PREFIXES,
        UPPERCASE_MNEMONIC,
        UPPERCASE_REGISTERS,
        UPPERCASE_TYPECASTS,
        UPPERCASE_DECORATORS,
        DEC_PREFIX,
        DEC_SUFFIX,
        HEX_UPPERCASE,
        HEX_PREFIX,
        HEX_SUFFIX,

        MAX_VALUE = HEX_SUFFIX
    }

    public enum NumericBase
    {
        DEC,
        HEX,

        MAX_VALUE = HEX
    }

    public enum Signedness
    {
        AUTO,
        SIGNED,
        UNSIGNED,

        MAX_VALUE = UNSIGNED
    }

    public enum Padding
    {
        DISABLED = 0,
        AUTO = -1,

        MAX_VALUE = AUTO
    }

    public enum FormatterFunction
    {
        PRE_INSTRUCTION,
        POST_INSTRUCTION,
        FORMAT_INSTRUCTION,
        PRE_OPERAND,
        POST_OPERAND,
        FORMAT_OPERAND_REG,
        FORMAT_OPERAND_MEM,
        FORMAT_OPERAND_PTR,
        FORMAT_OPERAND_IMM,
        PRINT_MNEMONIC,
        PRINT_REGISTER,
        PRINT_ADDRESS_ABS,
        PRINT_ADDRESS_REL,
        PRINT_DISP,
        PRINT_IMM,
        PRINT_TYPECAST,
        PRINT_SEGMENT,
        PRINT_DECORATOR,

        MAX_VALUE = PRINT_DECORATOR
    }

    public enum Decorator
    {
        INVALID,
        MASK,
        BC,
        RC,
        SAE,
        SWIZZLE,
        CONVERSION,
        EH,

        MAX_VALUE = EH
    }

    public struct FormatterContext
    {
        private readonly DecodedInstruction instruction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Formatter
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] Data;

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterInit")]
        public static extern ZyanStatus Init(ref Formatter formatter, FormatterStyle style);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterSetProperty")]
        public static extern ZyanStatus SetProperty(ref Formatter formatter, FormatterProperty property,
            ZyanUPointer value);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true, CharSet = CharSet.Ansi,
            EntryPoint = "ZydisFormatterFormatInstruction")]
        public static extern ZyanStatus FormatInstruction(ref Formatter formatter, ref DecodedInstruction instruction,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, ZyanUSize length, ZyanU64 runtimeAddress);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatInstructionEx")]
        public static extern ZyanStatus FormatInstructionEx(ref Formatter formatter, ref DecodedInstruction instruction,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length, ZyanU64 runtimeAddress,
            ref System.IntPtr userData);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatOperand")]
        public static extern ZyanStatus FormatOperand(ref Formatter formatter, ref DecodedInstruction instruction,
            ZyanU8 index, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length,
            ZyanU64 runtimeAddress);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatOperandEx")]
        public static extern ZyanStatus FormatOperandEx(ref Formatter formatter, ref DecodedInstruction instruction,
            ZyanU8 index, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length,
            ZyanU64 runtimeAddress, System.IntPtr userData);
    }
}