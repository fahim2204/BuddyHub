using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Models.VirtualModel
{
    public class PostData
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
    }
}