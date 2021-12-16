﻿using AutoMapper;
using BOL;
using BOL.Dto;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;


namespace BLL
{
    public class ProfileService
    {
        public static IEnumerable<ProfileDto> GetAllProfile()
        {
            return DataAccessFactory.ProfileDataAccess().Get().Select(Mapper.Map<BOL.Profile,ProfileDto>);
        }

        public static ProfileDto GetProfileById(int id)
        {
            var _Profile = DataAccessFactory.ProfileDataAccess().Get(id);
            if (_Profile != null )
            {
                return Mapper.Map<BOL.Profile, ProfileDto>(_Profile);
            }
            else
            {
                return null;

            }
        }

        public static bool RegisterProfile(ProfileDto user)
        {
            if(user == null) { return false; }
            else
            {
                DataAccessFactory.ProfileDataAccess().Add(Mapper.Map<ProfileDto, BOL.Profile>(user));
                return true;
            }
        }

        public static bool DeleteProfileById(int id)
        {
            var _Profile = DataAccessFactory.ProfileDataAccess().Get(id);
            if (_Profile == null) { return false; }
            else
            {
                DataAccessFactory.ProfileDataAccess().Delete(id);
                return true;
            }
        }

        public static bool EditProfile(int id, ProfileDto user)
        {
            var _Profile = DataAccessFactory.ProfileDataAccess().Get(id);

            if (_Profile == null) { return false; }
            else
            {
                DataAccessFactory.ProfileDataAccess().Edit(id, Mapper.Map<ProfileDto, BOL.Profile>(user));
                return true;
            }
        }
    }
}