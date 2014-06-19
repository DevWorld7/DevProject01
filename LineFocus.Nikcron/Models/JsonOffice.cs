using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineFocus.Nikcron.Models
{
    public class JsonOffice
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
    }
}