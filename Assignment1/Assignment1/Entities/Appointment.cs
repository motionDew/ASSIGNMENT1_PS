using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    class Appointment
    {
        private String _date;
        private String _hour;
        private String _clientName;
        private String _telephoneNo;
        private String _carBrand;
        private String _description;
        private String _id;
        private String _status;

        public Appointment() { }

        public Appointment(string id, string date, string hour, string clientName, string telephoneNo, string carBrand, string description,string status)
        {
            Id = id;
            Date = date;
            Hour = hour;
            ClientName = clientName;
            TelephoneNo = telephoneNo;
            CarBrand = carBrand;
            Description = description;
            Status = status;
        }

        public string Id { get => _id; set => _id = value; }
        public string Date { get => _date; set => _date = value; }
        public string Hour { get => _hour; set => _hour = value; }
        public string ClientName { get => _clientName; set => _clientName = value; }
        public string TelephoneNo { get => _telephoneNo; set => _telephoneNo = value; }
        public string CarBrand { get => _carBrand; set => _carBrand = value; }
        public string Description { get => _description; set => _description = value; }
        public string Status { get => _status; set => _status = value; }
    }
}
