using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class ProximoEventData
    {
        private string activityType;
        private int id;

        public  ProximoEventData( string activityType, int id)
        {
            this.activityType = activityType;
            this.id = id; 
        }






        public string ActivityType
        {
            get
            {
                return activityType;
            }

            set
            {
                activityType = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
