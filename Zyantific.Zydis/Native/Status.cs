using ZyanStatus = System.UInt32;

namespace Zyantific.Zydis.Native
{
    public class StatusModule : Zycore.Native.StatusModule
    {
        public const int ZYDIS = 0x002;
    }

    public class Status : Zycore.Native.Status
    {
        public const ZyanStatus NO_MORE_DATA =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x00) & 0xFFFFF));

        public const ZyanStatus DECODING_ERROR =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x01) & 0xFFFFF));

        public const ZyanStatus INSTRUCTION_TOO_LONG =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x02) & 0xFFFFF));

        public const ZyanStatus BAD_REGISTER =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x03) & 0xFFFFF));

        public const ZyanStatus ILLEGAL_LOCK =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x04) & 0xFFFFF));

        public const ZyanStatus ILLEGAL_LEGACY_PFX =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x05) & 0xFFFFF));

        public const ZyanStatus ILLEGAL_REX =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x06) & 0xFFFFF));

        public const ZyanStatus INVALID_MAP =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x07) & 0xFFFFF));

        public const ZyanStatus MALFORMED_EVEX =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x08) & 0xFFFFF));

        public const ZyanStatus MALFORMED_MVEX =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x09) & 0xFFFFF));

        public const ZyanStatus INVALID_MASK =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((2) & 0x7FF) << 20) | ((0x0A) & 0xFFFFF));
    }
}