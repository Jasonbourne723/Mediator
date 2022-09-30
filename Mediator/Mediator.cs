using Microsoft.Extensions.DependencyInjection;

namespace Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Mediator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

       

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(IRequest<TResponse>), typeof(TResponse));
            var requestHandler = scope.ServiceProvider.GetRequiredService(requestHandlerType);
            var handleMethod = requestHandlerType.GetMethod("handle");
            if (handleMethod == null)
            {
                throw new NotImplementedException($"{requestHandlerType.Name} not implement method handle ");
            }
            var result = handleMethod.Invoke(requestHandler, new object[] { request, cancellationToken }) as Task<TResponse>;
            if (result == null)
            {
                throw new Exception($" {requestHandler.GetType().Name}`s Method Handle return Type is wrong");
            }
            else
            {
                return await result;
            }
        }
    }

}