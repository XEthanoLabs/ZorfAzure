
using Zorf;
using Grpc.Net.Client;
using FiligreeClient;

var channel = GrpcChannel.ForAddress("https://localhost:7267");
// var channel = GrpcChannel.ForAddress("https://zorf.azurewebsites.net");
var client = new ZorfService.ZorfServiceClient(channel);


// holy shit we have an adventure program going on.

ZorfClient z = new ZorfClient(client);
z.MainLoop();
