using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModel;

namespace App1.Model
{
    public class Event
    {
        private string _name;
        private string _description;
        public int ID { get; set; }

        public string Name
        {
            get { return _name; }
            set
            { 
                _name = value;
                if (_name == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "The name field must be filled");
                }
                
                if(_name.Length <= 15 && _name.Length >=1)
                _name = value;
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),"The name must be less than 15 characters long");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                if (_description == null)
                {
                    throw new ArgumentNullException(nameof(Description), "The Description field must be filled");
                }
            }
        }

        public string Place { get; set; }
        public DateTime Time { get; set; }

        public Event()
        {
        }

        public override string ToString()
        {
            return string.Format("The {0} event(ID: {1}) will take place on {2}, at {3}. Description: {4}", Name, ID,
                Time, Place, Description);
        }
    }
}
