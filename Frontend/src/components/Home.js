import React, { useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import './ProfileCard.css';
import { isLoggedIn } from '../Config';
import { useAlert } from 'react-alert';
import View from './Post/View';

function Home() {

    const navigate = useNavigate();
    const alert = useAlert();

    useEffect(() => {
        document.title = "BuddyHub - Home";
        console.log(isLoggedIn());
        if (!isLoggedIn()) {
            navigate("/login");
            alert.error("Please Login First!");
        }
    }, [navigate, alert])


    return (
        <>
            {isLoggedIn() && <>
                <div className="container">
                    <div className="row">
                        <div className="col-8">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title">Welcome to BuddyHub</h5>
                                    <p className="card-text">
                                        This is a platform for sharing your thoughts and experiences with others.
                                        You can share your thoughts and experiences with others.
                                        You can also share your experiences with others.
                                    </p>
                                </div>
                                <div>
                                    <View />
                                </div>
                                
                            </div>
                        </div>
                        <div className="col-4">
                            <div className="row border rounded-3 mb-2 ms-2 p-1 shadow-sm">
                                <div className="dashboard-nav bg-secondary rounded-3">
                                    <nav className="dashboard-nav-list">
                                        {sessionStorage.getItem('Type') === 'admin' && <>
                                            <Link to="/admin/home" className="dashboard-nav-item"><i className="fa fa-dashboard" /> Goto Admin Panel</Link>
                                        </>}
                                        <Link to={"/profile/"+sessionStorage.getItem('Id')} className="dashboard-nav-item"><i className="fa fa-user-circle" /> My Profile</Link>
                                        <Link to="/Follower/ShowFollowers" className="dashboard-nav-item"><i className="fa fa-users" /> Followers </Link>
                                        <Link to="/Follower/ShowFollowing" className="dashboard-nav-item"><i className="fa fa-user" /> Following </Link>
                                        <Link to="/Save/ShowSavePost" className="dashboard-nav-item"><i className="fa fa-heartbeat" /> Favourite Post </Link>
                                        <Link to="/post/MyPost" className="dashboard-nav-item"><i className="fa fa-book" /> My Posts </Link>
                                        <Link to="/Password/CheckingChangingPassword" className="dashboard-nav-item"><i className="fa fa-key" /> Change Password </Link>
                                        <Link to="/Password/SetRecoveryPassword" className="dashboard-nav-item"><i className="fa fa-clock" /> Recovery Password </Link>
                                        <div className="nav-item-divider" />
                                        <Link to="/logout" className="dashboard-nav-item"><i className="fa fa-sign-out" /> Logout </Link>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </>}
        </>

    )



}

export default Home
