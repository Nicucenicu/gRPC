using Grpc.Net.Client;
using System;
using Part2;
using System.Threading.Tasks;
using GrpcServer;

namespace Sender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new GetData.GetDataClient(channel);
            while (true)
            {
                Console.WriteLine("Sender");
                Console.Write("Introduceti topicul: ");
                string topic = Console.ReadLine();
                Console.Write("Scrieti mesajul: ");
                string message = Console.ReadLine();
                var input = new ReceiveData { Topic = topic, Message = message };
                var reply = await client.GetDataInfoAsync(input);
                //Console.WriteLine($"{reply.Message}");
            }
            Console.ReadLine();
        }
    }
}
