using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSEvents1.Models
{
    public partial class Participant
    {
        public override string ToString()
        {
            return ParticipantID + " " + LastName + ", " + FirstName + " WSDC number: " + WsdcNumber + " Workshop level: " + WorkshopLevel + " Comp level: " + CompLevel;
        }
    }
}
