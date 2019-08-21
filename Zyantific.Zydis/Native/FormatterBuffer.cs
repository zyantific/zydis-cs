using System;
using System.Runtime.InteropServices;
using Zyantific.Zycore.Native;
using ZyanStatus = System.UInt32;
using ZyanU8 = System.Byte;
using ZyanUPointer = System.UIntPtr;

using ZyanUSize = System.UIntPtr;
using ZydisTokenType = System.Byte;

namespace Zyantific.Zydis.Native
{
    using FormatterTokenConst = FormatterToken;

    [StructLayout(LayoutKind.Sequential)]
    public struct FormatterToken
    {
        private readonly ZydisTokenType type;

        private readonly ZyanU8 next;

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterTokenGetValue")]
        public static extern ZyanStatus TokenGetValue(ref FormatterToken token, ref ZydisTokenType type,
            [MarshalAs(UnmanagedType.LPStr)]ref String value);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterTokenNext")]
        public static extern ZyanStatus TokenNext([MarshalAs(UnmanagedType.LPStruct)] ref FormatterTokenConst token);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FormatterBuffer
    {
        [MarshalAs(UnmanagedType.I1)]
        private readonly bool IsTokenList;

        private readonly ZyanUSize Capacity;

        private readonly ZyanString String;

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterBufferGetToken")]
        public static extern ZyanStatus GetToken(ref FormatterBuffer buffer,
            [MarshalAs(UnmanagedType.LPStruct)] ref FormatterTokenConst token);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterBufferGetString")]
        public static extern ZyanStatus GetString(ref FormatterBuffer buffer,
            [MarshalAs(UnmanagedType.LPStruct)] ref ZyanString @string);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterBufferAppend")]
        public static extern ZyanStatus Append(ref FormatterBuffer buffer, ZydisTokenType type);

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisFormatterBufferRemember")]
        public static extern ZyanStatus Remember(ref FormatterBuffer buffer, ref ZyanUPointer state);
    }
}