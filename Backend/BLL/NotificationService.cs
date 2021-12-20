using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NotificationService
    {
        public static void AddNotification(int userId, int notifierId, string msg, string link)
        {
            var noti = new Notification()
            {
                FK_Users_Id = userId,
                FK_Notifier_Users_Id = notifierId,
                Message = msg,
                CreatedAt = DateTime.Now,
                GotoLink = link
            };
            DataAccessFactory.NotificationDataAccess().Add(noti);
        }
    }
}
