using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSEvents1.Models
{
    public partial class JnJCompetitors
    {
        public override string ToString()
        {
            return ParticipantID + " " + WsdcNumber + " " + JnJDivision + " " + JnJRole;
        }
    }
}
