using MediatR;

namespace SealedVsUnsealed.Performance.Features.Unsealed
{
    public class UnealedRequestHandler : IRequestHandler<UnsealedRequest, int>
    {
        public Task<int> Handle(UnsealedRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.UnsealedModel.Value + 10);
        }
    }
}
