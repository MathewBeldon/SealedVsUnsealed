using BenchmarkDotNet.Attributes;
using SealedVsUnsealed.Benchmark.Models;
using SealedVsUnsealed.Benchmark.Models.Sealed;
using SealedVsUnsealed.Benchmark.Models.Unsealed;
using System.Runtime.CompilerServices;

namespace PdfConcat.Benchmark
{

    public class BenchmarkHelper
    {
        private BaseModel _baseModel = new();
        private SealedSubModel _sealedSubModel = new();
        private UnsealedSubModel _unsealedSubModel = new();
        private SealedModel _sealedModel = new();
        private UnsealedModel _unsealedModel = new();
        private object _stringObject = "object";

        [MethodImpl(MethodImplOptions.NoInlining)]
        [Benchmark(Description = "Base Benchmark")]
        public int RunBase()
        {
            return _baseModel.Virtual() + 20;
        }

        [Benchmark(Description = "Sealed Benchmark")]
        public int RunSealed()
        {
           return _sealedModel.Normal() + 20;
        }

        [Benchmark(Description = "Unsealed Benchmark")]
        public int RunUnsealed()
        {
           return _unsealedModel.Normal() + 20;
        }

        [Benchmark(Description = "Sealed BaseModel Benchmark")]
        public int RunSealedSub()
        {
            return _sealedSubModel.Normal() + 20;
        }

        [Benchmark(Description = "Unsealed BaseModel Benchmark")]
        public int RunUnsealedSub()
        {
            return _unsealedSubModel.Normal() + 20;
        }

        [Benchmark(Description = "Sealed Virtual Benchmark")]
        public int RunVirtualSealed()
        {
           return _sealedModel.Virtual() + 20;
        }

        [Benchmark(Description = "Unsealed Virtual Benchmark")]
        public int RunVirtualUnsealed()
        {
           return _unsealedModel.Virtual() + 20;
        }

        [Benchmark(Description = "Sealed Is Type Benchmark")]
        public bool RunIsTypeSealed()
        {
           return _stringObject is SealedModel;
        }

        [Benchmark(Description = "Unsealed Is Type Benchmark")]
        public bool RunIsTypeUnsealed()
        {
           return _stringObject is UnsealedModel;
        }
    }
}