using Newtonsoft.Json;
using NServiceBus;
using ProfessionalLevels.Messages;
using System;
using System.Threading.Tasks;

namespace ProfessionalLevels.ServiceBus
{
    class Program
    {
        static string connectionString = @"Data Source=.\SqlExpress;Database=ServiceBus;Integrated Security=True;Max Pool Size=100";
        static async Task Main()
        {
            Console.Title = "ProfessionalLevels";

            var endpointConfiguration = new EndpointConfiguration("ProfessionalLevels.ServiceBus");

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);
            transport.ConnectionString(connectionString);
            endpointConfiguration.UseSerialization<NewtonsoftSerializer>()
                .Settings(new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    SerializationBinder = new SkipAssemblyNameForMessageTypesBinder(new[] { typeof(CreateMemberTaskCredit) })
                });

            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.SendFailedMessagesTo("error");
            SqlHelper.EnsureDatabaseExists(connectionString);

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
