
using Zorf;
using Grpc.Net.Client;
using FiligreeClient;

var channel = GrpcChannel.ForAddress("https://localhost:7267");
// var channel = GrpcChannel.ForAddress("https://zorf.azurewebsites.net");
var client = new ZorfService.ZorfServiceClient(channel);

ZorfClient z = new ZorfClient(channel, client);
z.MainLoop();
