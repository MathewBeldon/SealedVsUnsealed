using MediatR;

namespace SealedVsUnsealed.Performance.Features.Sealed
{
    public class SealedVirtualRequestHandler : IRequestHandler<SealedVirtualRequest, int>
    {
        public Task<int> Handle(SealedVirtualRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.SealedModel.Virtual() + 10);
        }
    }
}
