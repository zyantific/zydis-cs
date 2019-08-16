using System;

namespace Zyantific.Zydis.Native
{
    public enum OperandType
    {
        UNUSED,
        REGISTER,
        MEMORY,
        POINTER,
        IMMEDIATE,

        MAX_VALUE = IMMEDIATE,
    }

    public enum OperandVisibility
    {
        INVALID,
        EXPLICIT,
        IMPLICIT,
        HIDDEN,

        MAX_VALUE = HIDDEN,
    }

    [Flags]
    public enum OperandActions : byte
    {
        READ               = 0x01,
        WRITE              = 0x02,
        CONDREAD           = 0x04,
        CONDWRITE          = 0x08,

        READWRITE          = READ | WRITE,
        CONDREAD_CONDWRITE = CONDREAD | CONDWRITE,
        READ_CONDWRITE     = READ | CONDWRITE,
        CONDREAD_WRITE     = CONDREAD | WRITE,
        MASK_READ          = READ | CONDREAD,
        MASK_WRITE         = WRITE | CONDWRITE,
    }

    public enum InstructionEncoding
    {
        LEGACY,
        AMD3DNOW,
        XOP,
        VEX,
        EVEX,
        MVEX,

        MAX_VALUE = MVEX,
    }

    public enum OpcodeMap
    {
        DEFAULT,
        MAP_0F,
        MAP_0F38,
        MAP_0F3A,
        MAP_0F0F,
        MAP_XOP8,
        MAP_XOP9,
        MAP_XOPA,

        MAP_MAX_VALUE = MAP_XOPA,
    }

    public enum OperandEncoding
    {
        NONE,
        MODRM_REG,
        MODRM_RM,
        OPCODE,
        NDSNDD,
        IS4,
        MASK,
        DISP8,
        DISP16,
        DISP32,
        DISP64,
        DISP16_32_64,
        DISP32_32_64,
        DISP16_32_32,
        UIMM8,
        UIMM16,
        UIMM32,
        UIMM64,
        UIMM16_32_64,
        UIMM32_32_64,
        UIMM16_32_32,
        SIMM8,
        SIMM16,
        SIMM32,
        SIMM64,
        SIMM16_32_64,
        SIMM32_32_64,
        SIMM16_32_32,
        JIMM8,
        JIMM16,
        JIMM32,
        JIMM64,
        JIMM16_32_64,
        JIMM32_32_64,
        JIMM16_32_32,

        MAX_VALUE = JIMM16_32_32,
    }

    public enum ElementType
    {
        INVALID,
        STRUCT,
        UINT,
        INT,
        FLOAT16,
        FLOAT32,
        FLOAT64,
        FLOAT80,
        LONGBCD,
        CC,

        MAX_VALUE = CC,
    }
}