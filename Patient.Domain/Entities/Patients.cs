using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.Entities 
{
    public class Patients 
    {
        public int Id { get; set; }

        public string PatientId { get; set; } 

        public string Name { get;  set; }
        
        public  string PhoneNumber { get;  set; } 

        public string DiseaseName { get;  set; } 

        public DateTime DateOfBirth { get; set; }
    }
}
