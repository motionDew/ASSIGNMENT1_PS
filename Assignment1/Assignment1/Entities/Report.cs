using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    class Report
    {
        private String _startDate;
        private String _endDate;
        private List<Appointment> appointments;

        public Report(string startDate, string endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public string StartDate { get => _startDate; set => _startDate = value; }
        public string EndDate { get => _endDate; set => _endDate = value; }
    }
}
