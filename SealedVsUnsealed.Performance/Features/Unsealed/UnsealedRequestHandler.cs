using MediatR;

namespace SealedVsUnsealed.Performance.Features.Unsealed
{
    public class UnsealedRequestHandler : IRequestHandler<UnsealedRequest, int>
    {
        public Task<int> Handle(UnsealedRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.UnsealedModel.Normal() + 10);
        }
    }
}
