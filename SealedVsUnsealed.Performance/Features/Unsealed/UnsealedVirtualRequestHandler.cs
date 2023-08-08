using MediatR;

namespace SealedVsUnsealed.Performance.Features.Unsealed
{
    public class UnsealedVirtualRequestHandler : IRequestHandler<UnsealedVirtualRequest, int>
    {
        public Task<int> Handle(UnsealedVirtualRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.UnsealedModel.Virtual() + 10);
        }
    }
}
