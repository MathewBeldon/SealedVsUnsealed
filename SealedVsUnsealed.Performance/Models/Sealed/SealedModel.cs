﻿namespace SealedVsUnsealed.Performance.Models.Sealed
{
    public sealed class SealedModel : BaseModel
    {
        public SealedModel() { }

        public int Normal() => 1;

        public override int Virtual() => 2;
    }
}
