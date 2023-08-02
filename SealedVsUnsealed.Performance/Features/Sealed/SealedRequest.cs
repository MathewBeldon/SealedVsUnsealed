using MediatR;
using SealedVsUnsealed.Performance.Models.Sealed;

namespace SealedVsUnsealed.Performance.Features.Sealed
{
    public sealed class SealedRequest : IRequest<int>
    {
        public SealedModel SealedModel;

        public SealedRequest(SealedModel sealedModel)
        {
            SealedModel = sealedModel;
        }
    }
}
