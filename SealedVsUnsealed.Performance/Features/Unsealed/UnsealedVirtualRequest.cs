using MediatR;
using SealedVsUnsealed.Performance.Models.Unsealed;

namespace SealedVsUnsealed.Performance.Features.Unsealed
{
    public class UnsealedVirtualRequest : IRequest<int>
    {
        public UnsealedModel UnsealedModel;

        public UnsealedVirtualRequest(UnsealedModel unsealedModel)
        {
            UnsealedModel = unsealedModel;
        }
    }
}
