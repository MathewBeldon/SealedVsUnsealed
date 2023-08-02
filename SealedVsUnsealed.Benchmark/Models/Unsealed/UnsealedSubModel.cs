namespace SealedVsUnsealed.Benchmark.Models.Unsealed
{
    public class UnsealedSubModel : BaseModel
    {
        public int Normal() => 1;

        public override int Virtual() => 2;
    }
}
