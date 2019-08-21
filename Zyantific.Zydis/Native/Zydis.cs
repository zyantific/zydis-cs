using System.Runtime.InteropServices;

using ZyanStatus = System.UInt32;
using ZyanU64 = System.UInt64;

namespace Zyantific.Zydis.Native
{
    public enum ZydisFeature
    {
        ZYDIS_FEATURE_DECODER,
        ZYDIS_FEATURE_FORMATTER,
        ZYDIS_FEATURE_AVX512,
        ZYDIS_FEATURE_KNC,

        ZYDIS_FEATURE_MAX_VALUE = ZYDIS_FEATURE_KNC
    }

    public static class Zydis
    {
        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisGetVersion")]
        public static extern ZyanU64 GetVersion();

        [DllImport(nameof(Zyantific.Zydis), ExactSpelling = true,
            EntryPoint = "ZydisIsFeatureEnabled")]
        public static extern ZyanStatus IsFeatureEnabled(ZydisFeature feature);
    }
}