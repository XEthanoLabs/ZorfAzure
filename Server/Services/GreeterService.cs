using Grpc.Core;
using Grpc3.Adventure;
using Grpc3;
using Zorf;

namespace Grpc3.Services
{
    public class GreeterService : ZorfService.ZorfServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
         
        public override Task<ZorfReply> DoCommand(ZorfCommand request, ServerCallContext context)
        {
            AdventureEngine ae = AdventureEngine.s_pEngine;
            string szId = context.GetHttpContext().Connection.Id;

            return Task.FromResult(new ZorfReply
            {
                Message = ae.Command(szId, request.Command)
            });
        }
    }
}
