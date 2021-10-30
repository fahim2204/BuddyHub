using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public class ProfileRepository
    {
        static buddyhubEntities db;
        static ProfileRepository()
        {
            db = new buddyhubEntities();
        }
        public List<ProfileData> GetProfileData()
        {
            var test = (from u in db.Users
                        join u2 in db.Profiles on u.Id equals u2.FK_Users_Id
                        select new ProfileData()
                        {
                            Name = u.Name,
                            Type = u.Type,
                            Email = u2.Email,
                            Contact = u2.Contact,
                            PImage = u2.ProfileImage,
                            Address = u2.Address,
                            Gender = u2.Gender
                        }).ToList();
            //ProfileData data = new ProfileData()
            //{
            //    Name = test.ToList().First().Name,
            //    Type = test.ToList().First().Type,
            //    Email = test.ToList().First().Email,
            //    Contact = test.ToList().First().Contact,
            //    PImage = test.ToList().First().PImage,
            //    Address = test.ToList().First().Address,
            //    Gender = test.ToList().First().Gender

            //};
            return test;

        }
        
        
    }
}