using System;
using System.Text;
using Zyantific.Zydis.Native;

using Decoder = Zyantific.Zydis.Native.Decoder;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var decoder = new Decoder();
            if (!Status.Success(Decoder.Init(ref decoder, MachineMode.LONG_64, AddressWidth.WIDTH_64)))
            {
                throw new Exception("Failed to initialize instruction-decoder.");
            }
            if (!Status.Success(Decoder.EnableMode(ref decoder, DecoderMode.AMD_BRANCHES, false)))
            {
                throw new Exception("Failed to set decoder mode.");
            }

            var formatter = new Formatter();
            if (!Status.Success(Formatter.Init(ref formatter, FormatterStyle.INTEL)))
            {
                throw new Exception("Failed to initialize instruction-formatter.");
            }

            var data = new byte[] { 0xEB, 0x00, 0x90, 0xCC };
            var buffer = new byte[Constants.MAX_INSTRUCTION_LENGTH];
            var offset = 0;

            DecodedInstruction instruction = new DecodedInstruction();
            var formatBuffer = new StringBuilder(256);
            while (true)
            {
                var size = Math.Min(Constants.MAX_INSTRUCTION_LENGTH, data.Length - offset);
                Array.Copy(data, offset, buffer, 0, size);

                var status = Decoder.DecodeBuffer(ref decoder, buffer, (UIntPtr)size, ref instruction);
                if (status == Status.NO_MORE_DATA)
                {
                    break;
                }
                if (!Status.Success(status))
                {
                    Console.WriteLine("db ");
                    continue;
                }

                Formatter.FormatInstruction(ref formatter, ref instruction, formatBuffer,
                    (UIntPtr)formatBuffer.Capacity, 0x0000000000000000);
                Console.WriteLine(formatBuffer);

                offset += instruction.Length;
            }

            Console.ReadKey();
        }
    }
}