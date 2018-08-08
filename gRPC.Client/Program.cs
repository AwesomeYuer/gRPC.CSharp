namespace Microshaoft
{
    using Grpc.Core;
    //using Microshaoft;
    using System;
    class TestClient
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel
                                    (
                                        "127.0.0.1:9007"
                                        , ChannelCredentials.Insecure
                                    );

            var client = new HelloWorldService.HelloWorldServiceClient(channel);
            var reply = client
                            .SayHello
                                (
                                    new HelloRequest
                                    {
                                        Name = "Foo Bar"
                                    }
                                );
            Console.WriteLine("来自" + reply.Message);
            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}