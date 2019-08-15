using System.Runtime.InteropServices;
using Zyantific.Zydis.Generated;
using ZyanBool = System.Byte;
using ZyanI64 = System.Int64;
using ZyanU16 = System.UInt16;
using ZyanU32 = System.UInt32;
using ZyanU64 = System.UInt64;

using ZyanU8 = System.Byte;
using ZydisElementSize = System.UInt16;
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
        CPUFLAG_ACTION_NONE,
        CPUFLAG_ACTION_TESTED,
        CPUFLAG_ACTION_TESTED_MODIFIED,
        CPUFLAG_ACTION_MODIFIED,
        CPUFLAG_ACTION_SET_0,
        CPUFLAG_ACTION_SET_1,
        CPUFLAG_ACTION_UNDEFINED,

        CPUFLAG_ACTION_MAX_VALUE = CPUFLAG_ACTION_UNDEFINED
    }

    public enum CPUFlag
    {
        CPUFLAG_CF,
        CPUFLAG_PF,
        CPUFLAG_AF,
        CPUFLAG_ZF,
        CPUFLAG_SF,
        CPUFLAG_TF,
        CPUFLAG_IF,
        CPUFLAG_DF,
        CPUFLAG_OF,
        CPUFLAG_IOPL,
        CPUFLAG_NT,
        CPUFLAG_RF,
        CPUFLAG_VM,
        CPUFLAG_AC,
        CPUFLAG_VIF,
        CPUFLAG_VIP,
        CPUFLAG_ID,
        CPUFLAG_C0,
        CPUFLAG_C1,
        CPUFLAG_C2,
        CPUFLAG_C3,
    }

    public enum BranchType
    {
        BRANCH_TYPE_NONE,
        BRANCH_TYPE_SHORT,
        BRANCH_TYPE_NEAR,
        BRANCH_TYPE_FAR,

        BRANCH_TYPE_MAX_VALUE = BRANCH_TYPE_FAR
    }

    public enum ExceptionClass
    {
        EXCEPTION_CLASS_NONE,
        EXCEPTION_CLASS_SSE1,
        EXCEPTION_CLASS_SSE2,
        EXCEPTION_CLASS_SSE3,
        EXCEPTION_CLASS_SSE4,
        EXCEPTION_CLASS_SSE5,
        EXCEPTION_CLASS_SSE7,
        EXCEPTION_CLASS_AVX1,
        EXCEPTION_CLASS_AVX2,
        EXCEPTION_CLASS_AVX3,
        EXCEPTION_CLASS_AVX4,
        EXCEPTION_CLASS_AVX5,
        EXCEPTION_CLASS_AVX6,
        EXCEPTION_CLASS_AVX7,
        EXCEPTION_CLASS_AVX8,
        EXCEPTION_CLASS_AVX11,
        EXCEPTION_CLASS_AVX12,
        EXCEPTION_CLASS_E1,
        EXCEPTION_CLASS_E1NF,
        EXCEPTION_CLASS_E2,
        EXCEPTION_CLASS_E2NF,
        EXCEPTION_CLASS_E3,
        EXCEPTION_CLASS_E3NF,
        EXCEPTION_CLASS_E4,
        EXCEPTION_CLASS_E4NF,
        EXCEPTION_CLASS_E5,
        EXCEPTION_CLASS_E5NF,
        EXCEPTION_CLASS_E6,
        EXCEPTION_CLASS_E6NF,
        EXCEPTION_CLASS_E7NM,
        EXCEPTION_CLASS_E7NM128,
        EXCEPTION_CLASS_E9NF,
        EXCEPTION_CLASS_E10,
        EXCEPTION_CLASS_E10NF,
        EXCEPTION_CLASS_E11,
        EXCEPTION_CLASS_E11NF,
        EXCEPTION_CLASS_E12,
        EXCEPTION_CLASS_E12NP,
        EXCEPTION_CLASS_K20,
        EXCEPTION_CLASS_K21,

        EXCEPTION_CLASS_MAX_VALUE = EXCEPTION_CLASS_K21
    }

    public enum MaskMode
    {
        MASK_MODE_INVALID,
        MASK_MODE_DISABLED,
        MASK_MODE_MERGING,
        MASK_MODE_ZEROING,
        MASK_MODE_CONTROL,
        MASK_MODE_CONTROL_ZEROING,

        MASK_MODE_MAX_VALUE = MASK_MODE_CONTROL_ZEROING
    }

    public enum BroadcastMode
    {
        BROADCAST_MODE_INVALID,
        BROADCAST_MODE_1_TO_2,
        BROADCAST_MODE_1_TO_4,
        BROADCAST_MODE_1_TO_8,
        BROADCAST_MODE_1_TO_16,
        BROADCAST_MODE_1_TO_32,
        BROADCAST_MODE_1_TO_64,
        BROADCAST_MODE_2_TO_4,
        BROADCAST_MODE_2_TO_8,
        BROADCAST_MODE_2_TO_16,
        BROADCAST_MODE_4_TO_8,
        BROADCAST_MODE_4_TO_16,
        BROADCAST_MODE_8_TO_16,

        BROADCAST_MODE_MAX_VALUE = BROADCAST_MODE_8_TO_16
    }

    public enum RoundingMode
    {
        ROUNDING_MODE_INVALID,
        ROUNDING_MODE_RN,
        ROUNDING_MODE_RD,
        ROUNDING_MODE_RU,
        ROUNDING_MODE_RZ,

        ROUNDING_MODE_MAX_VALUE = ROUNDING_MODE_RZ
    }

    public enum SwizzleMode
    {
        SWIZZLE_MODE_INVALID,
        SWIZZLE_MODE_DCBA,
        SWIZZLE_MODE_CDAB,
        SWIZZLE_MODE_BADC,
        SWIZZLE_MODE_DACB,
        SWIZZLE_MODE_AAAA,
        SWIZZLE_MODE_BBBB,
        SWIZZLE_MODE_CCCC,
        SWIZZLE_MODE_DDDD,

        SWIZZLE_MODE_MAX_VALUE = SWIZZLE_MODE_DDDD
    }

    public enum ConversionMode
    {
        CONVERSION_MODE_INVALID,
        CONVERSION_MODE_FLOAT16,
        CONVERSION_MODE_SINT8,
        CONVERSION_MODE_UINT8,
        CONVERSION_MODE_SINT16,
        CONVERSION_MODE_UINT16,

        CONVERSION_MODE_MAX_VALUE = CONVERSION_MODE_UINT16
    }

    public enum PrefixType
    {
        PREFIX_TYPE_IGNORED,
        PREFIX_TYPE_EFFECTIVE,
        PREFIX_TYPE_MANDATORY,

        PREFIX_TYPE_MAX_VALUE = PREFIX_TYPE_MANDATORY
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedOperand
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Reg
        {
            public Register value;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Disp
        {
            public ZyanBool HasDisplacement;

            public ZyanI64 value;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Mem
        {
            public MemoryOperandType Type;

            public Register Sement;

            public Register Base;

            public Register index;

            public ZyanU8 scale;

            public Disp Disp;
        }

        public struct Ptr
        {
            public ZyanU16 segment;

            public ZyanU32 offset;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Value
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

            public Value value;
        }

        public ZyanU8 Id;

        public OperandType Type;

        public OperandVisibility Visibility;

        public OperandAction Action;

        public OperandEncoding Encoding;

        public ZyanU16 Size;

        public ElementType ElementType;

        public ZydisElementSize ElementSize;

        public ZyanU16 ElementCount;

        public Reg reg;

        public Mem mem;

        public Ptr ptr;

        public Imm imm;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DecodedInstruction
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct AccessedFlags
        {
            public CPUFlagAction Action;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Avx
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Mask_
            {
                public MaskMode MaskMode;

                public Register Reg;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Broadcast_
            {
                public ZyanBool IsStatic;

                public BroadcastMode BroadcastMode;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Rounding_
            {
                public RoundingMode RoundingMode;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Swizzle_
            {
                public SwizzleMode SwizzleMode;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Conversion_
            {
                public ConversionMode ConversionMode;
            }

            public ZyanU16 VectorLength;

            public Mask_ Mask;

            public Broadcast_ Broadcast;

            public Rounding_ Rounding;

            public Swizzle_ Swizzle;

            public Conversion_ Conversion;

            public ZyanBool HasSae;

            public ZyanBool HasEvictionHint;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Meta
        {
            public InstructionCategory InstructionCategory;

            public ISASet IsASet;

            public BranchType BranchType;

            public ExceptionClass ExceptionClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Raw
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Prefixes
            {
                public PrefixType type;

                public ZyanU8 value;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct REX
            {
                public ZyanU8 W;

                public ZyanU8 R;

                public ZyanU8 X;

                public ZyanU8 B;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct XOP
            {
                public ZyanU8 R;

                public ZyanU8 X;

                public ZyanU8 B;

                public ZyanU8 m_mmmm;

                public ZyanU8 W;

                public ZyanU8 vvvv;

                public ZyanU8 L;

                public ZyanU8 pp;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct VEX
            {
                public ZyanU8 R;

                public ZyanU8 X;

                public ZyanU8 B;

                public ZyanU8 m_mmmm;

                public ZyanU8 W;

                public ZyanU8 vvvv;

                public ZyanU8 L;

                public ZyanU8 pp;

                public ZyanU8 offset;

                public ZyanU8 size;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct EVEX
            {
                public ZyanU8 R;

                public ZyanU8 X;

                public ZyanU8 B;

                public ZyanU8 R2;

                public ZyanU8 Mn;

                public ZyanU8 W;

                public ZyanU8 vvvv;

                public ZyanU8 pp;

                public ZyanU8 z;

                public ZyanU8 L2;

                public ZyanU8 L;

                public ZyanU8 b;

                public ZyanU8 V2;

                public ZyanU8 aaa;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MVEX
            {
                public ZyanU8 R;

                public ZyanU8 X;

                public ZyanU8 B;

                public ZyanU8 R2;

                public ZyanU8 mmmm;

                public ZyanU8 W;

                public ZyanU8 vvvv;

                public ZyanU8 pp;

                public ZyanU8 E;

                public ZyanU8 SSS;

                public ZyanU8 V2;

                public ZyanU8 kkk;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ModRM
            {
                public ZyanU8 mod;

                public ZyanU8 reg;

                public ZyanU8 rm;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct SIB
            {
                public ZyanU8 scale;

                public ZyanU8 index;

                public ZyanU8 @base;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DISP
            {
                public ZyanI64 value;

                public ZyanU8 size;

                public ZyanU8 offset;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct IMM
            {
                [StructLayout(LayoutKind.Explicit)]
                public struct Value
                {
                    [FieldOffset(0)]
                    public ZyanU64 u;

                    [FieldOffset(1)]
                    public ZyanI64 s;
                }

                public ZyanBool is_signed;

                public ZyanBool is_relative;

                public Value value;

                public ZyanU8 size;

                public ZyanU8 offset;
            }

            public ZyanU8 prefix_count;

            //   DecodedInstructionRawPrefixes[] RawPrefixes; // this HAS to be an array because it will mess up the struct otherwise.
            [MarshalAs(UnmanagedType.ByValArray,
            ArraySubType = UnmanagedType.ByValArray, SizeConst = Constants.MAX_INSTRUCTION_LENGTH)]
            public Prefixes[] prefixes;

            public REX rex;

            public XOP xop;

            public VEX vex;

            public EVEX evex;

            public MVEX mvex;

            public ModRM modrm;

            public SIB sib;

            public DISP disp;

            //   DecodedInstructionRawImm RawImm; // this should be an array of 2
            [MarshalAs(UnmanagedType.ByValArray,
            ArraySubType = UnmanagedType.ByValArray, SizeConst = 2)]
            public IMM[] imm;
        }

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

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValArray,
            SizeConst = Constants.MAX_OPERAND_COUNT)]
        public DecodedOperand[] Operands;

        //   public DecodedOperand operand; // This has to be a fixed length array.

        public ZydisInstructionAttributes Attributes;

        [MarshalAs(UnmanagedType.ByValArray,
ArraySubType = UnmanagedType.ByValArray, SizeConst = 21)]
        public AccessedFlags[] accessed_flags;

        // public DecodedInstructionAccessedFlags AccessedFlags; // might need to be an array too

        public Avx avx;

        public Meta meta;

        public Raw raw;

        /*
        // Only for testing ..
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] Data;
        */
    }
}