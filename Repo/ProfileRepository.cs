using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public static class ProfileRepository
    {
        static buddyhubEntities db;
        static ProfileRepository()
        {
            db = new buddyhubEntities();
        }
        /*
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
        */

       
        public void UpdateName(int UserId,string name)

        {
            var user = (from u in db.Users
                        where u.Id == UserId
                        select u).FirstOrDefault();
            user.Name =name;
            db.SaveChanges();
        }
        public void UpdateProfile(int UserId,ProfileData pd)
        {
            var profile = (from p in db.Profiles
                        where p.FK_Users_Id == UserId
                        select p).FirstOrDefault();
            profile.Contact = pd.Contact;
            profile.Email = pd.Email;
            profile.Address = pd.Address;
            profile.Gender = pd.Gender;
            profile.DOB = pd.DOB;
            profile.Religion = pd.Religion;
            profile.Relationship = pd.Relationship;
            db.SaveChanges();

        }
        public ProfileData GetProfileData(string UserName)
        {
            
            var test = (from u in db.Users
                        join u2 in db.Profiles on u.Id equals u2.FK_Users_Id
                        where u.Username == UserName
                        select new ProfileData()
                        {
                            Name = u.Name,
                            Type = u.Type,
                            Email = u2.Email,
                            Contact = u2.Contact,
                            PImage = u2.ProfileImage,
                            Address = u2.Address,
                            Gender = u2.Gender,
                            DOB = (DateTime)u2.DOB,
                            Religion = u2.Religion,
                            Relationship = u2.Relationship,
                            Username = u.Username


                        }).FirstOrDefault();
            return test;
        }
        public ProfileData GetProfileData(int UserId)
        {

            var test = (from u in db.Users
                        join u2 in db.Profiles on u.Id equals u2.FK_Users_Id
                        where u.Id == UserId
                        select new ProfileData()
                        {
                            Name = u.Name,
                            Type = u.Type,
                            Email = u2.Email,
                            Contact = u2.Contact,
                            PImage = u2.ProfileImage,
                            Address = u2.Address,
                            Gender = u2.Gender,
                            DOB = (DateTime)u2.DOB,
                            Religion = u2.Religion,
                            Relationship = u2.Relationship,
                            Username = u.Username


                        }).FirstOrDefault();
            return test;
        }



    }
}