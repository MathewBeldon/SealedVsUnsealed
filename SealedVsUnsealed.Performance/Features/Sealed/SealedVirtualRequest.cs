using MediatR;
using SealedVsUnsealed.Performance.Models.Sealed;

namespace SealedVsUnsealed.Performance.Features.Sealed
{
    public sealed class SealedVirtualRequest : IRequest<int>
    {
        public SealedModel SealedModel;

        public SealedVirtualRequest(SealedModel sealedModel)
        {
            SealedModel = sealedModel;
        }
    }
}