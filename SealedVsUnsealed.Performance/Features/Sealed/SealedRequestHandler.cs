using MediatR;

namespace SealedVsUnsealed.Performance.Features.Sealed
{
    public sealed class SealedRequestHandler : IRequestHandler<SealedRequest, int>
    {
        public Task<int> Handle(SealedRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.SealedModel.Normal() + 10);
        }
    }
}
