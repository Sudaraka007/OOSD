using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Sales
{
    public enum ActivityType :byte
    {
        SalesIssue = 0,
        CustomerConfirm = 1,
        AgreementSign = 2,
        DSP = 3,
        BillIssue = 4,
        SalesClose = 5,
        Disconect = 6
    }
}
