import React, { useEffect, useState } from "react";
import './ProfileCard.css';
import axios from "axios";
import { apiUrl } from '../Config';
import { Link, useNavigate } from 'react-router-dom';
import { isLoggedIn } from '../Config';

const ProfileCard = () => {
    const navigate = useNavigate();
    useEffect(() => { 
        document.title = "BuddyHub - Profile";
        GetProfileData();
}, []);
    var [profileInfo, SetprofileInfo] = useState({
        UserName: "",
        FullName: "",
        Contact: "",
        Email: "",
        Address: "",
        ProfileImage: "",
        DateOFBirth: "",
        Gender: "",
        Religion: "",
        Relationship: "",
    });

    const GetProfileData = () => {
        console.log("Getting Data");
        axios.get(`${apiUrl}/profile/28`)
            .then(res => {
                console.log(res.data)
                SetprofileInfo(
                    {
                        ...profileInfo,
                        UserName: res.data.UserName,
                        ProfileImage: res.data.ProfileImage,
                        FullName: res.data.FullName,
                        Contact: res.data.Contact,
                        Email: res.data.Contact,
                        Address: res.data.Address,
                        DateOFBirth: res.data.DOB,
                        Gender: res.data.Gender,
                        Religion: res.data.Religion,
                        Relationship: res.data.Relationship,
                    }
                )
            })
            .catch(err => {
                console.log(err);
            })


    }
    return (
        <>
            {/* <div className="ProfileCard">
                <div className="upper-container">
                    <div className="img-container">
                        <img src="" alt="" height="100px" width="100px" />
                    </div>
                </div>
                <div className="lower-container">
                    <h1>{name}</h1>
                    <h3>{age}</h3>

                </div>

            </div> */}
                <div className="row shadow p-3 mx-1 rounded-3">
                    <div className="col-8 d-flex justify-content-center">
                        <img className="rounded-circle border border-2 border-secondary shadow" src={profileInfo.ProfileImage} style={{ height: '100px', width: '100px' }} />
                    </div>
                    <div className="col-12 d-flex justify-content-center align-items-center my-1">
                        <h5 className="d-inline-block">{profileInfo.UserName}</h5>
                        <h6 className="d-inline-block">
                            {/* (@if (Model.Status == 1)
                            {'{'}@Html.Raw("Active"){'}'}
                            else
                            {'{'}@Html.Raw("Disabled"){'}'}) */}
                        </h6>
                    </div>
                    <div className="col-3 d-flex justify-content-center my-1">
                    </div>
                    <div className="col-6 d-flex justify-content-center my-1">
                        <div className="row shadow-sm rounded-3 d-flex justify-content-center">
                            <div className="col-3 d-flex flex-column align-items-center me-3">
                                <h6 className="my-0">Posts</h6>
                                <h6 className></h6>
                            </div>
                            <div className="col-3 d-flex flex-column align-items-center ms-3">
                                <h6 className="my-0">Followers</h6>
                                <h6 className></h6>
                            </div>
                        </div>
                    </div>
                    <div className="col-3 d-flex justify-content-center my-1">
                        {/* @if ((string)Session["Username"] == Model.Username.Replace(" ", ""))
                        {'{'}
                        <a className="btn btn-outline-primary" href="/Profile/Edit/@Model.Username">Edit Profile</a>
                        {'}'}
                        else
                        {'{'}
                        <a className="btn btn-outline-primary" href="/Follower/DoFollow/@Model.FK_Users_Id">Follow/Unfollow</a>
                        {'}'} */}
                    </div>
                    <div className="col-8 my-2">
                        <div className="row">
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Full Name : </span>
                                <span className="profile1">{profileInfo.FullName}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Date of Birth : </span>
                                <span className="profile1">{profileInfo.DateOFBirth.toString()}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Contact :</span>
                                <span className="profile1">{profileInfo.Contact}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Gender :</span>
                                <span className="profile1">{profileInfo.Gender}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Email :</span>
                                <span className="profile1">{profileInfo.Email}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Religion :</span>
                                <span className="profile1">{profileInfo.Religion}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Address :</span>
                                <span className="profile1">{profileInfo.Address}</span>
                            </div>
                            <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                <span className="profile">Relationship :</span>
                                <span className="profile1">{profileInfo.Relationship}</span>
                            </div>
                        </div>
                    </div>
                </div>

        </>
    )

}
export default ProfileCard;
