﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSEvents1.Models
{
    public partial class StrictlyCompetitors
    {
        public override string ToString()
        {
            return ParticipantID + " " + StrictlyRole + " " + StrictlyDivision + " " + PartnerID + " " + PartnerFirstName + " " + PartnerLastName;
        }
    }
}
