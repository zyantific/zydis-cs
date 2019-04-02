using System;
using System.Runtime.CompilerServices;

using ZyanStatus = System.UInt32;

namespace Zyantific.Zycore.Native
{
    public class StatusModule
    {
        public const int ZYCORE = 0x001;

        public const int USER   = 0x3FF;
    }

    public class Status
    {
        public const ZyanStatus SUCCESS =
            unchecked((ZyanStatus)(((0) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x00) & 0xFFFFF));

        public const ZyanStatus FAILED =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x01) & 0xFFFFF));

        public const ZyanStatus TRUE =
            unchecked((ZyanStatus)(((0) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x02) & 0xFFFFF));

        public const ZyanStatus FALSE =
            unchecked((ZyanStatus)(((0) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x03) & 0xFFFFF));

        public const ZyanStatus INVALID_ARGUMENT =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x04) & 0xFFFFF));

        public const ZyanStatus INVALID_OPERATION =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x05) & 0xFFFFF));

        public const ZyanStatus NOT_FOUND =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x06) & 0xFFFFF));

        public const ZyanStatus OUT_OF_RANGE =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x07) & 0xFFFFF));

        public const ZyanStatus INSUFFICIENT_BUFFER_SIZE =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x08) & 0xFFFFF));

        public const ZyanStatus NOT_ENOUGH_MEMORY =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x09) & 0xFFFFF));

        public const ZyanStatus BAD_SYSTEMCALL =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x0A) & 0xFFFFF));

        public const ZyanStatus OUT_OF_RESOURCES =
            unchecked((ZyanStatus)(((1) & 0x01) << 31) | (((1) & 0x7FF) << 20) | ((0x0B) & 0xFFFFF));

        public static ZyanStatus MakeStatus(bool error, uint module, uint code)
        {
            return ((Convert.ToUInt32(error) & 0x01) << 31) | (((module) & 0x7FF) << 20) | ((code) & 0xFFFFF);
        }

        public static uint GetModule(ZyanStatus status)
        {
            return ((status >> 20) & 0x7FF);
        }

        public static uint GetCode(ZyanStatus status)
        {
            return (status & 0xFFFFF);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Success(ZyanStatus status)
        {
            return !Convert.ToBoolean((status) & 0x80000000);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Failed(ZyanStatus status)
        {
            return Convert.ToBoolean((status) & 0x80000000);
        }
    }
}
