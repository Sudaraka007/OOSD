using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Sales
{
    class Activity
    {
        private ActivityType type;
        private DateTime activityDate;
        private string activityDetails;

        public string ActivityDetails
        {
            get { return activityDetails; }
            set { activityDetails = value; }
        }
        public DateTime ActivityDate
        {
            get { return activityDate; }
            set { activityDate = value; }
        }       
        public ActivityType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Activity(ActivityType type)
        {
            this.type = type;
            this.activityDate = new DateTime(1, 1, 1);
            this.activityDetails = "";
        }
        
    }
}
