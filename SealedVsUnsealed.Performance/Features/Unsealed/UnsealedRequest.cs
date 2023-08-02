using MediatR;
using SealedVsUnsealed.Performance.Models.Unsealed;

namespace SealedVsUnsealed.Performance.Features.Unsealed
{
    public class UnsealedRequest : IRequest<int>
    {
        public UnsealedModel UnsealedModel;

        public UnsealedRequest(UnsealedModel unsealedModel)
        {
            UnsealedModel = unsealedModel;
        }
    }
}
