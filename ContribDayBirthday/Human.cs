using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContribDayBirthday
{
    class Human
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }


        public Human()
        {
            

        }

        public Human(string? name, string? lastname, DateTime dateb)
        {
            this.FirstName = name;
            LastName = lastname;
            this.Birthday = dateb;
        }

        public Human(int value, string first, string second, DateTime inputtedDate)
        {
            Id = value;
            FirstName = first;
            LastName = second;
            Birthday = inputtedDate;
        }
    }
}
