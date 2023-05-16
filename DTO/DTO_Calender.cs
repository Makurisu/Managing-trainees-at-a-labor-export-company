using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Calender
    {
        private String calender_schedule;
        private String calender_event;

        public String Calender_schedule { get { return calender_schedule; } set { calender_schedule = value; } }
        public String Calender_event { get { return calender_event; } set { calender_event = value; } }
        public DTO_Calender() { }
        public DTO_Calender(String calender_schedule, String calender_event)
        {
            this.Calender_schedule = calender_schedule;
            this.Calender_event = calender_event;
        }

    }
}
