using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Timetable
    {

        //Properties
        public Activity Activity { get; set; }
        public Supervisor Supervisor { get; set; }
        public DateTime Date { get; set; }

        //Calculated Property, converts date to string
        public string StringDate
        {
            get
            {
                return String.Format($"{Date.Year}-{Date.Month}-{Date.Day}");
            }
        }

        public DateTime StartTime { get; set; }

        //Calculated Property, converts time to string
        public string StringStartTime
        {
            get
            {
                return String.Format($"{Date.Hour}:{Date.Minute}");
            }
        }
        public DateTime EndTime { get; set; }

        //Calculated Property, converts time to string
        public string StringEndTime
        {
            get
            {
                return String.Format($"{Date.Hour}:{Date.Minute}");
            }
        }

        public Timetable() { } //default constructor

        //Constructor using all Properties, uses other constructor
        public Timetable(Activity activity, Supervisor supervisor, DateTime date, DateTime startTime, DateTime endTime)
            : this (activity, date, startTime, endTime)
        {
            Supervisor = supervisor;
        }

        //Constructor thats sets supervisor as the non-supervisor
        public Timetable(Activity activity, DateTime date, DateTime startTime, DateTime endTime)
        {
            Activity = activity;
            Supervisor = new Supervisor(0, "blank", "blank");
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
