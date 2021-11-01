using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Models.VirtualModel
{
    public class NotificationData
    {
        public int Id { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
        public Nullable<int> FK_Notifier_Users_Id { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string Message { get; set; }
        public string GotoLink { get; set; }
    }
}