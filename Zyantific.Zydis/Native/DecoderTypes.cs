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
        INVALID,
        MEM,
        AGEN,
        MIB,

        MAX_VALUE = MIB,
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
        NONE,
        TESTED,
        TESTED_MODIFIED,
        MODIFIED,
        SET_0,
        SET_1,
        UNDEFINED,

        MAX_VALUE = UNDEFINED
    }

    public enum CPUFlag
    {
        CF,
        PF,
        AF,
        ZF,
        SF,
        TF,
        IF,
        DF,
        OF,
        IOPL,
        NT,
        RF,
        VM,
        AC,
        VIF,
        VIP,
        ID,
        C0,
        C1,
        C2,
        C3,

        MAX_VALUE = C3
    }

    public enum BranchType
    {
        NONE,
        SHORT,
        NEAR,
        FAR,

        MAX_VALUE = FAR
    }

    public enum ExceptionClass
    {
        NONE,
        SSE1,
        SSE2,
        SSE3,
        SSE4,
        SSE5,
        SSE7,
        AVX1,
        AVX2,
        AVX3,
        AVX4,
        AVX5,
        AVX6,
        AVX7,
        AVX8,
        AVX11,
        AVX12,
        E1,
        E1NF,
        E2,
        E2NF,
        E3,
        E3NF,
        E4,
        E4NF,
        E5,
        E5NF,
        E6,
        E6NF,
        E7NM,
        E7NM128,
        E9NF,
        E10,
        E10NF,
        E11,
        E11NF,
        E12,
        E12NP,
        K20,
        K21,

        MAX_VALUE = K21
    }

    public enum MaskMode
    {
        INVALID,
        DISABLED,
        MERGING,
        ZEROING,
        CONTROL,
        CONTROL_ZEROING,

        MAX_VALUE = CONTROL_ZEROING
    }

    public enum BroadcastMode
    {
        MODE_INVALID,
        MODE_1_TO_2,
        MODE_1_TO_4,
        MODE_1_TO_8,
        MODE_1_TO_16,
        MODE_1_TO_32,
        MODE_1_TO_64,
        MODE_2_TO_4,
        MODE_2_TO_8,
        MODE_2_TO_16,
        MODE_4_TO_8,
        MODE_4_TO_16,
        MODE_8_TO_16,

        MAX_VALUE = MODE_8_TO_16
    }

    public enum RoundingMode
    {
        INVALID,
        RN,
        RD,
        RU,
        RZ,

        MAX_VALUE = RZ
    }

    public enum SwizzleMode
    {
        INVALID,
        DCBA,
        CDAB,
        BADC,
        DACB,
        AAAA,
        BBBB,
        CCCC,
        DDDD,

        MAX_VALUE = DDDD
    }

    public enum ConversionMode
    {
        INVALID,
        FLOAT16,
        SINT8,
        UINT8,
        SINT16,
        UINT16,

        MAX_VALUE = UINT16
    }

    public enum PrefixType
    {
        IGNORED,
        EFFECTIVE,
        MANDATORY,

        MAX_VALUE = MANDATORY
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
            [MarshalAs(UnmanagedType.I1)]
            public bool HasDisplacement;

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

            [FieldOffset(0)]
            public ZyanI64 S;
        }

        public struct Imm
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool IsSigned;

            [MarshalAs(UnmanagedType.I1)]
            public bool IsRelative;

            public Value value;
        }

        public ZyanU8 Id;

        public OperandType Type;

        public OperandVisibility Visibility;

        public OperandActions Actions;

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

            [MarshalAs(UnmanagedType.I1)]
            public bool HasSae;

            [MarshalAs(UnmanagedType.I1)]
            public bool HasEvictionHint;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Meta
        {
            public InstructionCategory category;

            public ISASet isa_set;

            public ISAExt isa_ext;

            public BranchType branch_type;

            public ExceptionClass exception_class;
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

                    [FieldOffset(0)]
                    public ZyanI64 s;
                }

                [MarshalAs(UnmanagedType.I1)]
                public bool is_signed;

                [MarshalAs(UnmanagedType.I1)]
                public bool is_relative;

                public Value value;

                public ZyanU8 size;

                public ZyanU8 offset;
            }

            public ZyanU8 prefix_count;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_INSTRUCTION_LENGTH)]
            public Prefixes[] prefixes;

            public REX rex;

            public XOP xop;

            public VEX vex;

            public EVEX evex;

            public MVEX mvex;

            public ModRM modrm;

            public SIB sib;

            public DISP disp;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_OPERAND_COUNT)]
        public DecodedOperand[] Operands;

        public ZydisInstructionAttributes Attributes;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)CPUFlag.MAX_VALUE + 1)]
        public AccessedFlags[] accessed_flags;

        public Avx avx;

        public Meta meta;

        public Raw raw;
    }
}