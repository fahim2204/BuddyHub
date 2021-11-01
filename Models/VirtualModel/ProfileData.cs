using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DOB { get; set; }
        public string Relationship { get; set; }
        public string Religion { get; set; }
        public string Username { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
    }
}