namespace SealedVsUnsealed.Benchmark.Models.Sealed
{
    public sealed class SealedModel : BaseModel
    {
        public int Normal() => 1;

        public override int Virtual() => 2;
    }
}
