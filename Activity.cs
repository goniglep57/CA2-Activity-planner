using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_Activity_planner
{
    class Activity:IComparable
    {
        public string Name { get; set; }
       
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }


        //
        public Activity(string name, int year, int month, int day, string desc,  int cost )
        {
            Name = name;
            Date = new DateTime(year,month,day);
            Description = desc;
            Cost = cost;
            
            

        }
        public int CompareTo(object o)
        {
            Activity temporary = (Activity)o;
            return temporary.Date.CompareTo(this.Date);
        }

        public override string ToString()
        {
            return $"{Name} -- {Date.ToShortDateString()}";
        }
    }
}
