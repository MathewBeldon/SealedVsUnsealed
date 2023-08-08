namespace SealedVsUnsealed.Performance.Models.Unsealed
{
    public class UnsealedModel : BaseModel
    {
        public UnsealedModel() { }

        public int Normal() => 1;       

        public override int Virtual() => 2;
    }
}
