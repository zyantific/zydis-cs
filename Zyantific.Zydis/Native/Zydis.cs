using System.Runtime.InteropServices;

using ZyanStatus = System.UInt32;
using ZyanU64 = System.UInt64;

namespace Zyantific.Zydis.Native
{
    public enum ZydisFeature
    {
        ZYDIS_FEATURE_AVX512,
        ZYDIS_FEATURE_KNC,
        ZYDIS_FEATURE_MAX_VALUE = ZYDIS_FEATURE_KNC,
    }

    [StructLayout(LayoutKind.Sequential)]
#if ZYDIS_UNSAFE
    unsafe public struct Zydis
#else
    public struct Zydis
#endif
    {
        private const string ImportNameGetVersion = "ZydisGetVersion";
        private const string ImportNameFeatureEnabled = "ZydisIsFeatureEnabled";

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = ImportNameGetVersion)]
        public static extern ZyanU64 GetVersion();

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = ImportNameGetVersion)]
        public static extern ZyanStatus FeatureEnabled(ZydisFeature feature);

    }
}
