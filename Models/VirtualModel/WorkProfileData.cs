using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuddyHub.Models.VirtualModel
{
    public class WorkProfileData
    {
        public int Id { get; set; }
        [Required]
        public string Institution { get; set; }
        public Nullable<System.DateTime> StartYear { get; set; }
        public Nullable<System.DateTime> EndYear { get; set; }
        [Required]
        public string Position { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
    }
}