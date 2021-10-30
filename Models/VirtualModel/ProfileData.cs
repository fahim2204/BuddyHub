using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Models.VM
{
    public class ProfileData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string PImage { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}