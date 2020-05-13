using NServiceBus;
using NServiceBus.Logging;
using ProfessionalLevels.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalLevels.ServiceBus.MessageHandlers
{
    public class CreateMemberTaskCreditHandler : IHandleMessages<CreateMemberTaskCredit>
    {
        static ILog log = LogManager.GetLogger<CreateMemberTaskCreditHandler>();
        public Task Handle(CreateMemberTaskCredit message, IMessageHandlerContext context)
        {
            log.Info($"Legacy order with id {message.OrderId} detected");
            //log.Info($"Received {message.GetType().ToString()}, " +
            //    $"TrainingID = {message.TrainingID}, " +
            //    $"CAPID = {message.CAPID}, " +
            //    $"TrainingName = {message.TrainingName}");

            //Business Logic goes here
            //throw new Exception("BOOM");

            return Task.CompletedTask;
        }
    }
}
