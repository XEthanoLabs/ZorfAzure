using Grpc.Core;
using Zorf.Adventure;

namespace Zorf.Services
{
    public class ZorfService : Zorf.ZorfService.ZorfServiceBase
    {
        private readonly ILogger<ZorfService> _logger;
        public ZorfService(ILogger<ZorfService> logger)
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
