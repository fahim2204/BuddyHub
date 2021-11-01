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

       
        public static void UpdateName(int UserId,string name)

        {
            var user = (from u in db.Users
                        where u.Id == UserId
                        select u).FirstOrDefault();
            user.Name =name;
            db.SaveChanges();
        }
        public static void UpdateProfile(int UserId,ProfileData pd)
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
        public static List<ProfileData> GetAllProfileData()
        {

            var AllProfile = (from u in db.Users
                        join u2 in db.Profiles on u.Id equals u2.FK_Users_Id
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
                            Status = u.Status,
                            Religion = u2.Religion,
                            Relationship = u2.Relationship,
                            Username = u.Username


                        }).ToList();
            return AllProfile;
        }
        public static ProfileData GetProfileData(string UserName)
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
                            Status = u.Status,
                            DOB = (DateTime)u2.DOB,
                            Religion = u2.Religion,
                            Relationship = u2.Relationship,
                            Username = u.Username,
                            FK_Users_Id = u2.FK_Users_Id

                        }).FirstOrDefault();
            return test;
        }
        public static ProfileData GetProfileData(int UserId)
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
                            Status = u.Status,
                            DOB = (DateTime)u2.DOB,
                            Religion = u2.Religion,
                            Relationship = u2.Relationship,
                            Username = u.Username,
                            FK_Users_Id = u2.FK_Users_Id

                        }).FirstOrDefault();
            return test;
        }



    }
}