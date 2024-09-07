using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities;
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldTypeAttribute : Attribute
    {
        public string Type { get; }

        public FieldTypeAttribute(string type)
        {
            Type = type;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationRuleAttribute : Attribute
    {
        public string Constraints { get; }

        public ValidationRuleAttribute(string constraints)
        {
            Constraints = constraints;
        }
    }


