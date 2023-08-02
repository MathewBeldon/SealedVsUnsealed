using BenchmarkDotNet.Attributes;
using SealedVsUnsealed.Benchmark.Models.Sealed;
using SealedVsUnsealed.Benchmark.Models.Unsealed;
using System.Runtime.CompilerServices;

namespace PdfConcat.Benchmark
{

    public class BenchmarkHelper
    {
        private SealedModel _sealedModel = new();
        private UnsealedModel _unsealedModel = new();
        private object _stringObject = "object";

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Sealed Benchmark")]
        public int RunSealed()
        {
            return _sealedModel.Normal() + 20;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Unsealed Benchmark")]
        public int RunUnsealed()
        {
            return _unsealedModel.Normal() + 20;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Sealed Virtual Benchmark")]
        public int RunVirtualSealed()
        {
            return _sealedModel.Virtual() + 20;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Unsealed Virtual Benchmark")]
        public int RunVirtualUnsealed()
        {
            return _unsealedModel.Virtual() + 20;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Sealed Is Type Benchmark")]
        public bool RunIsTypeSealed()
        {
            return _stringObject is SealedModel;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Unsealed Is Type Benchmark")]
        public bool RunIsTypeUnsealed()
        {
            return _stringObject is UnsealedModel;
        }
    }
}