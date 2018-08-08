namespace Microshaoft
{
    using Grpc.Core;
    using System;
    using System.Threading.Tasks;
    class gRPCImpl : HelloWorldService.HelloWorldServiceBase
    {
        // 实现SayHello方法
        public override Task<HelloReply> SayHello
                    (
                        HelloRequest request
                        , ServerCallContext context
                    )
        {
            return
                Task
                    .FromResult
                        (
                            new HelloReply
                            {
                                Message = "Hello " + request.Name
                            }
                        );
        }
    }

    class TestServer
    {
        const int Port = 9007;
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services =
                {
                    HelloWorldService
                        .BindService(new gRPCImpl())
                }
                ,
                Ports =
                {
                    new ServerPort
                            (
                                "localhost"
                                , Port
                                , ServerCredentials.Insecure
                            )
                }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}