using System.Runtime.InteropServices;
using System.Text;

using ZyanStatus = System.UInt32;
using ZyanU64 = System.UInt64;
using ZyanUSize = System.UIntPtr;
using ZyanU8 = System.Byte;
using ZyanUPointer = System.UInt64; // this may cause issues because ZyanUPtr is defined as uintptr_t 

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
        PROP_FORCE_SIZE,
        PROP_FORCE_SEGMENT,
        PROP_FORCE_RELATIVE_BRANCHES,
        PROP_FORCE_RELATIVE_RIPREL,
        PROP_PRINT_BRANCH_SIZE,
        PROP_DETAILED_PREFIXES,
        PROP_ADDR_BASE,
        PROP_ADDR_SIGNEDNESS,
        PROP_ADDR_PADDING_ABSOLUTE,
        PROP_ADDR_PADDING_RELATIVE,
        PROP_DISP_BASE,
        PROP_DISP_SIGNEDNESS,
        PROP_DISP_PADDING,
        PROP_IMM_BASE,
        PROP_IMM_SIGNEDNESS,
        PROP_IMM_PADDING,
        PROP_UPPERCASE_PREFIXES,
        PROP_UPPERCASE_MNEMONIC,
        PROP_UPPERCASE_REGISTERS,
        PROP_UPPERCASE_TYPECASTS,
        PROP_UPPERCASE_DECORATORS,
        PROP_DEC_PREFIX,
        PROP_DEC_SUFFIX,
        PROP_HEX_UPPERCASE,
        PROP_HEX_PREFIX,
        PROP_HEX_SUFFIX,
        PROP_MAX_VALUE,
        PROP_REQUIRED_BITS,
    }

    public enum NumericBase
    {
        NUMERIC_BASE_DEC,
        NUMERIC_BASE_HEX,
        NUMERIC_BASE_MAX_VALUE = NUMERIC_BASE_HEX,
        NUMERIC_BASE_REQUIRED_BITS // value needs to be set
    }

    public enum Signedness
    {
        SIGNEDNESS_AUTO,
        SIGNEDNESS_SIGNED,
        SIGNEDNESS_UNSIGNED,
        SIGNEDNESS_MAX_VALUE = SIGNEDNESS_UNSIGNED,
    }

    public enum Padding
    {
        PADDING_DISABLED = 0,
        PADDING_AUTO = -1,
        PADDING_MAX_VALUE = PADDING_AUTO,
    }

    public enum FormatterFunction
    {
        FUNC_PRE_INSTRUCTION,
        FUNC_POST_INSTRUCTION,
        FUNC_FORMAT_INSTRUCTION,
        FUNC_PRE_OPERAND,
        FUNC_POST_OPERAND,
        FUNC_FORMAT_OPERAND_REG,
        FUNC_FORMAT_OPERAND_MEM,
        FUNC_FORMAT_OPERAND_PTR,
        FUNC_FORMAT_OPERAND_IMM,
        FUNC_PRINT_MNEMONIC,
        FUNC_PRINT_REGISTER,
        FUNC_PRINT_ADDRESS_ABS,
        FUNC_PRINT_ADDRESS_REL,
        FUNC_PRINT_DISP,
        FUNC_PRINT_IMM,
        FUNC_PRINT_TYPECAST,
        FUNC_PRINT_SEGMENT,
        FUNC_PRINT_DECORATOR,
        FUNC_MAX_VALUE = FUNC_PRINT_DECORATOR,
    }

    public enum Decorator
    {
        DECORATOR_INVALID,
        DECORATOR_MASK,
        DECORATOR_BC,
        DECORATOR_RC,
        DECORATOR_SAE,
        DECORATOR_SWIZZLE,
        DECORATOR_CONVERSION,
        DECORATOR_EH,
        DECORATOR_MAX_VALUE = DECORATOR_EH,
    }

    public struct FormatterContext
    {
        readonly DecodedInstruction instruction;
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
        public static extern ZyanStatus SetProperty(ref Formatter formatter, FormatterProperty property, ZyanUPointer value);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true, CharSet = CharSet.Ansi,
            EntryPoint = "ZydisFormatterFormatInstruction")]
        public static extern ZyanStatus FormatInstruction(ref Formatter formatter,
            ref DecodedInstruction instruction,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, ZyanUSize length,
            ZyanU64 runtimeAddress);

        // The use of UIntPtr as a replacement of size_t may cause issues. There may also be an issue with replacing void* with IntPtrs.
        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatInstructionEx")]
        public static extern ZyanStatus FormatInstructionEx(ref Formatter formatter, ref DecodedInstruction instruction, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length, ZyanU64 runtimeAddress, ref System.IntPtr userData);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatOperand")]
        public static extern ZyanStatus FormatOperand(ref Formatter formatter, ref DecodedInstruction instruction, ZyanU8 index, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length, ZyanU64 runtimeAddress);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterFormatOperandEx")]
        public static extern ZyanStatus FormatOperandEx(ref Formatter formatter, ref DecodedInstruction instruction, ZyanU8 index, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, System.UIntPtr length, ZyanU64 runtimeAddress, System.IntPtr userData);
    }
}
