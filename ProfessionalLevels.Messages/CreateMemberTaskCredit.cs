using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalLevels.Messages
{
    public class CreateMemberTaskCredit : IMessage
    {
        public string OrderId { get; set; }
        //public string TrainingID { get; set; }
        //public string CAPID { get; set; }
        //public string TrainingName { get; set; }
        //public string TrainingCompletedOn { get;set;}
        //public string InputUserID { get; set; }
    }
}
