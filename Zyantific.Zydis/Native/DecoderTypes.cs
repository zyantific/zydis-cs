using System.Runtime.InteropServices;

using ZyanU8 = System.Byte;
using ZyanU16 = System.UInt16;
using ZydisElementSize = System.UInt16;
using Zyantific.Zydis.Generated;
using ZyanBool = System.Byte;
using ZyanI64 = System.Int64;
using ZyanU32 = System.UInt32;
using ZyanU64 = System.UInt64;
using ZydisInstructionAttributes = System.UInt64;
namespace Zyantific.Zydis.Native
{

    public enum MemoryOperandType
    {
        MEMOP_TYPE_INVALID,
        MEMOP_TYPE_MEM,
        MEMOP_TYPE_AGEN,
        MEMOP_TYPE_MIB,
        MEMOP_TYPE_MAX_VALUE = MEMOP_TYPE_MIB,
    }
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

    public enum CPUFlagAction
    {
        ZYDIS_CPUFLAG_ACTION_NONE,
        ZYDIS_CPUFLAG_ACTION_TESTED,
        ZYDIS_CPUFLAG_ACTION_TESTED_MODIFIED,
        ZYDIS_CPUFLAG_ACTION_MODIFIED,
        ZYDIS_CPUFLAG_ACTION_SET_0,
        ZYDIS_CPUFLAG_ACTION_SET_1,
        ZYDIS_CPUFLAG_ACTION_UNDEFINED,
        ZYDIS_CPUFLAG_ACTION_MAX_VALUE = ZYDIS_CPUFLAG_ACTION_UNDEFINED,
    }

    public enum BranchType
    {
        ZYDIS_BRANCH_TYPE_NONE,
        ZYDIS_BRANCH_TYPE_SHORT,
        ZYDIS_BRANCH_TYPE_NEAR,
        ZYDIS_BRANCH_TYPE_FAR,
        ZYDIS_BRANCH_TYPE_MAX_VALUE = ZYDIS_BRANCH_TYPE_FAR,
    }

    public enum ExceptionClass
    {
        ZYDIS_EXCEPTION_CLASS_NONE,
        ZYDIS_EXCEPTION_CLASS_SSE1,
        ZYDIS_EXCEPTION_CLASS_SSE2,
        ZYDIS_EXCEPTION_CLASS_SSE3,
        ZYDIS_EXCEPTION_CLASS_SSE4,
        ZYDIS_EXCEPTION_CLASS_SSE5,
        ZYDIS_EXCEPTION_CLASS_SSE7,
        ZYDIS_EXCEPTION_CLASS_AVX1,
        ZYDIS_EXCEPTION_CLASS_AVX2,
        ZYDIS_EXCEPTION_CLASS_AVX3,
        ZYDIS_EXCEPTION_CLASS_AVX4,
        ZYDIS_EXCEPTION_CLASS_AVX5,
        ZYDIS_EXCEPTION_CLASS_AVX6,
        ZYDIS_EXCEPTION_CLASS_AVX7,
        ZYDIS_EXCEPTION_CLASS_AVX8,
        ZYDIS_EXCEPTION_CLASS_AVX11,
        ZYDIS_EXCEPTION_CLASS_AVX12,
        ZYDIS_EXCEPTION_CLASS_E1,
        ZYDIS_EXCEPTION_CLASS_E1NF,
        ZYDIS_EXCEPTION_CLASS_E2,
        ZYDIS_EXCEPTION_CLASS_E2NF,
        ZYDIS_EXCEPTION_CLASS_E3,
        ZYDIS_EXCEPTION_CLASS_E3NF,
        ZYDIS_EXCEPTION_CLASS_E4,
        ZYDIS_EXCEPTION_CLASS_E4NF,
        ZYDIS_EXCEPTION_CLASS_E5,
        ZYDIS_EXCEPTION_CLASS_E5NF,
        ZYDIS_EXCEPTION_CLASS_E6,
        ZYDIS_EXCEPTION_CLASS_E6NF,
        ZYDIS_EXCEPTION_CLASS_E7NM,
        ZYDIS_EXCEPTION_CLASS_E7NM128,
        ZYDIS_EXCEPTION_CLASS_E9NF,
        ZYDIS_EXCEPTION_CLASS_E10,
        ZYDIS_EXCEPTION_CLASS_E10NF,
        ZYDIS_EXCEPTION_CLASS_E11,
        ZYDIS_EXCEPTION_CLASS_E11NF,
        ZYDIS_EXCEPTION_CLASS_E12,
        ZYDIS_EXCEPTION_CLASS_E12NP,
        ZYDIS_EXCEPTION_CLASS_K20,
        ZYDIS_EXCEPTION_CLASS_K21,
        ZYDIS_EXCEPTION_CLASS_MAX_VALUE = ZYDIS_EXCEPTION_CLASS_K21,
    }

    public enum MaskMode
    {
        ZYDIS_MASK_MODE_INVALID,
        ZYDIS_MASK_MODE_DISABLED,
        ZYDIS_MASK_MODE_MERGING,
        ZYDIS_MASK_MODE_ZEROING,
        ZYDIS_MASK_MODE_CONTROL,
        ZYDIS_MASK_MODE_CONTROL_ZEROING,
        ZYDIS_MASK_MODE_MAX_VALUE = ZYDIS_MASK_MODE_CONTROL_ZEROING,
    }

    public enum BroadcastMode
    {
        ZYDIS_BROADCAST_MODE_INVALID,
        ZYDIS_BROADCAST_MODE_1_TO_2,
        ZYDIS_BROADCAST_MODE_1_TO_4,
        ZYDIS_BROADCAST_MODE_1_TO_8,
        ZYDIS_BROADCAST_MODE_1_TO_16,
        ZYDIS_BROADCAST_MODE_1_TO_32,
        ZYDIS_BROADCAST_MODE_1_TO_64,
        ZYDIS_BROADCAST_MODE_2_TO_4,
        ZYDIS_BROADCAST_MODE_2_TO_8,
        ZYDIS_BROADCAST_MODE_2_TO_16,
        ZYDIS_BROADCAST_MODE_4_TO_8,
        ZYDIS_BROADCAST_MODE_4_TO_16,
        ZYDIS_BROADCAST_MODE_8_TO_16,
        ZYDIS_BROADCAST_MODE_MAX_VALUE = ZYDIS_BROADCAST_MODE_8_TO_16,
    }

    public enum RoundingMode
    {
        ZYDIS_ROUNDING_MODE_INVALID,
        ZYDIS_ROUNDING_MODE_RN,
        ZYDIS_ROUNDING_MODE_RD,
        ZYDIS_ROUNDING_MODE_RU,
        ZYDIS_ROUNDING_MODE_RZ,
        ZYDIS_ROUNDING_MODE_MAX_VALUE = ZYDIS_ROUNDING_MODE_RZ,
    }

    public enum SwizzleMode
    {
        ZYDIS_SWIZZLE_MODE_INVALID,
        ZYDIS_SWIZZLE_MODE_DCBA,
        ZYDIS_SWIZZLE_MODE_CDAB,
        ZYDIS_SWIZZLE_MODE_BADC,
        ZYDIS_SWIZZLE_MODE_DACB,
        ZYDIS_SWIZZLE_MODE_AAAA,
        ZYDIS_SWIZZLE_MODE_BBBB,
        ZYDIS_SWIZZLE_MODE_CCCC,
        ZYDIS_SWIZZLE_MODE_DDDD,
        ZYDIS_SWIZZLE_MODE_MAX_VALUE = ZYDIS_SWIZZLE_MODE_DDDD,
    }

    public enum ConversionMode
    {
        ZYDIS_CONVERSION_MODE_INVALID,
        ZYDIS_CONVERSION_MODE_FLOAT16,
        ZYDIS_CONVERSION_MODE_SINT8,
        ZYDIS_CONVERSION_MODE_UINT8,
        ZYDIS_CONVERSION_MODE_SINT16,
        ZYDIS_CONVERSION_MODE_UINT16,
        ZYDIS_CONVERSION_MODE_MAX_VALUE = ZYDIS_CONVERSION_MODE_UINT16,
    }

    public enum PrefixType
    {
        ZYDIS_PREFIX_TYPE_IGNORED,
        ZYDIS_PREFIX_TYPE_EFFECTIVE,
        ZYDIS_PREFIX_TYPE_MANDATORY,
        ZYDIS_PREFIX_TYPE_MAX_VALUE = ZYDIS_PREFIX_TYPE_MANDATORY,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAccessedFlags
    {
        public CPUFlagAction Action;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvxMask
    {
        public MaskMode MaskMode;

        public Register Reg;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvxBroadcast
    {
        public ZyanBool IsStatic;

        public BroadcastMode BroadcastMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvxRounding
    {
        RoundingMode RoundingMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvxSwizzle
    {
        SwizzleMode SwizzleMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvxConversion
    {
        ConversionMode ConversionMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionAvx
    {
        ZyanU16 VectorLength;

        DecodedInstructionAvxMask AvxMask;

        DecodedInstructionAvxBroadcast AvxBroadcast;

        DecodedInstructionAvxRounding AvxRounding;

        DecodedInstructionAvxSwizzle AvxSwizzle;

        DecodedInstructionAvxConversion AvxConversion;

        ZyanBool HasSae;

        ZyanBool HasEvictionHint;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionMeta
    {
        InstructionCategory InstructionCategory;

        ISASet IsASet;

        BranchType BranchType;

        ExceptionClass ExceptionClass;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionRawPrefixes
    {
        PrefixType PrefixType;

        ZyanU8 Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionRawRex
    {
        ZyanU8 W;

        ZyanU8 R;

        ZyanU8 X;

        ZyanU8 B;

        ZyanU8 offset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionRawXop
    {
        ZyanU8 R;

        ZyanU8 X;

        ZyanU8 B;

        ZyanU8 m_mmmm;

        ZyanU8 W;

        ZyanU8 vvvv;

        ZyanU8 L;

        ZyanU8 pp;

        ZyanU8 offset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionRawVex
    {
        ZyanU8 R;

        ZyanU8 X;

        ZyanU8 B;

        ZyanU8 m_mmmm;

        ZyanU8 W;

        ZyanU8 vvvv;

        ZyanU8 L;

        ZyanU8 pp;

        ZyanU8 offset;

        ZyanU8 size;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstructionRaw
    {
        ZyanU8 PrefixCount;

        DecodedInstructionRawPrefixes RawPrefixes; // should be an array

        DecodedInstructionRawRex RawRex;

        DecodedInstructionRawXop RawXop;

        DecodedInstructionRawVex RawVex;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstruction
    {
        public MachineMode MachineMode;

        public Mnemonic Mnemonic;

        public ZyanU8 Length;

        public InstructionEncoding Encoding;

        public OpcodeMap OpcodeMap;

        public ZyanU8 Opcode;

        public ZyanU8 StackWidth;

        public ZyanU8 OperandWidth;

        public ZyanU8 AddressWidth;

        public ZyanU8 OperandCount;

        public DecodedOperand operand; // This probably needs to be an array but I couldn't figure out how to use an array in this case and it somehow works.

        public ZydisInstructionAttributes Attributes;

        public DecodedInstructionAccessedFlags AccessedFlags; // might need to be an array too

        
        // Only for testing ..
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] Data;
        
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Reg
    {
        public Register Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct Disp
    {
        ZyanBool HasDisplacement;

        ZyanI64 value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Mem
    {
        MemoryOperandType Type;

        Register Sement;

        Register Base;

        Register index;

        ZyanU8 scale;

        Disp Disp;
    }

    public struct Ptr
    {
        ZyanU16 segment;

        ZyanU32 offset;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Union
    {
        [FieldOffset(0)]
        public ZyanU64 U;

        [FieldOffset(1)]
        public ZyanI64 S;
    }

    public struct Imm
    {
        public ZyanBool IsSigned;

        public ZyanBool IsRelative;

        public Union Union;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedOperand
    {
        public ZyanU8 Id;

        public OperandType Type;

        public OperandVisibility Visibility;

        public OperandAction Action;

        public OperandEncoding Encoding;

        public ZyanU16 Size;

        public ElementType ElementType;

        public ZydisElementSize ElementSize;

        public ZyanU16 ElementCount;

        public Reg Reg;

        public Mem Mem;

        public Ptr Ptr;

        public Imm Imm;
    }
}
