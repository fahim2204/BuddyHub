import axios from 'axios';
import moment from 'moment';
import React, { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import { apiUrl } from '../Config';

function EditProfile() {
    let params = useParams();

    useEffect(() => {
        document.title = "BuddyHub - Profile";
        GetProfileData();
    }, []);

    var [profileInfo, SetprofileInfo] = useState({
        Username: "",
        Name: "",
        Contact: "",
        Email: "",
        Address: "",
        ProfileImage: "",
        DOB: "",
        Gender: "",
        Religion: "",
        Relationship: "",
        Status: ""
    });

    const GetProfileData = () => {
        console.log("Getting Data");

        axios.get(`${apiUrl}/profile/${params.id}`)
            .then(res => {
                console.log(res.data)
                SetprofileInfo(
                    {
                        ...profileInfo,
                        Username: res.data.Username,
                        ProfileImage: res.data.ProfileImage,
                        Name: res.data.Name,
                        Contact: res.data.Contact,
                        Email: res.data.Contact,
                        Address: res.data.Address,
                        DOB: res.data.DOB,
                        Gender: res.data.Gender,
                        Religion: res.data.Religion,
                        Relationship: res.data.Relationship,
                        Status: res.data.Status
                    }
                )
            })
            .catch(err => {
                console.log(err);
            })
    }
    return (
        <>
            <div className="container">
                <div className="row">
                    <div className="col-3">
                        <div className="row border rounded-3 mb-2 ms-2 p-1 shadow-sm">
                            <div className="dashboard-nav bg-secondary rounded-3">
                                <nav className="dashboard-nav-list">
                                    <Link to={"/profile/" + sessionStorage.getItem('Id')} className="dashboard-nav-item active"><i className="fa fa-user-circle" /> My Profile</Link>
                                    <Link to="/Follower/ShowFollowers" className="dashboard-nav-item"><i className="fa fa-users" /> Followers </Link>
                                    <Link to="/Follower/ShowFollowing" className="dashboard-nav-item"><i className="fa fa-user" /> Following </Link>
                                    <Link to="/Save/ShowSavePost" className="dashboard-nav-item"><i className="fa fa-heartbeat" /> Favourite Post </Link>
                                    <Link to="/post/MyPost" className="dashboard-nav-item"><i className="fa fa-book" /> My Posts </Link>
                                    <Link to="/Password/CheckingChangingPassword" className="dashboard-nav-item"><i className="fa fa-key" /> Change Password </Link>
                                    <div className="nav-item-divider" />
                                    <Link to="/logout" className="dashboard-nav-item"><i className="fa fa-sign-out" /> Logout </Link>
                                </nav>
                            </div>
                        </div>
                    </div>
                    <div className="col-9">
                        <div className="row shadow p-3 mx-1 rounded-3">
                            <div className="col-12 d-flex justify-content-center">
                                <img className="rounded-circle border border-2 border-success shadow" src={profileInfo.ProfileImage} alt="user" style={{ height: '100px', width: '100px' }} />
                            </div>
                            <div className="col-12 d-flex justify-content-center align-items-center my-1">
                                <h5 className="d-inline-block">{profileInfo.Username}</h5>
                                <h6 className="d-inline-block ms-2 text-muted">
                                    {profileInfo.Status === 1 && <>(Active)</>}
                                    {profileInfo.Status === 2 && <>(Disabled)</>}
                                </h6>
                            </div>
                            <div className="col-12 my-4">
                                <div className="row">
                                    <div className="my-2 col-5">
                                        <label htmlFor="Name" className="form-label">Full Name :</label>
                                        <input type="text" className="form-control" id="Name" value={profileInfo.Name} />
                                    </div>
                                    <div className="col-2"></div>
                                    <div className="my-2 col-5">
                                        <label htmlFor="dob" className="form-label">Date of Birth :</label>
                                        <input type="date" className="form-control" id="dob" value={moment(profileInfo.DOB).format('YYYY-MM-DD')} />
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Contact :</span>
                                        <span className="profile1">{profileInfo.Contact}</span>
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Gender :</span>
                                        <span className="profile1">{profileInfo.Gender}</span>
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Email :</span>
                                        <span className="profile1">{profileInfo.Email}</span>
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Religion :</span>
                                        <span className="profile1">{profileInfo.Religion}</span>
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Address :</span>
                                        <span className="profile1">{profileInfo.Address}</span>
                                    </div>
                                    <div className="my-2 col-6 d-flex justify-content-start align-items-center">
                                        <span className="profile me-2">Relationship :</span>
                                        <span className="profile1">{profileInfo.Relationship}</span>
                                    </div>
                                </div>
                            </div>
                            <div className="col-12 d-flex justify-content-end">
                                <Link to={"/profile/" + params.id} className='btn btn-danger btn-sm me-4'>Cancel</Link>
                                <button className='btn btn-primary btn-sm me-4'>Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </>
    )
}

export default EditProfile
