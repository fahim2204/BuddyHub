import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import NavBar from './NavBar';
import { isLoggedIn } from '../Config';
import userImg from '../images/user.png';
import '../App.css';

const Header = () => {
    const navigate = useNavigate();

    const logout = () => {
        console.log(sessionStorage.getItem('LoggedUser'));
        sessionStorage.clear();
        navigate("/login");
    }

    const notification = () => {
        alert("You are logged out!");
    }

    return (
        <>
            <nav className="navbar fixed-top">
                <div className="container d-flex flex-nowrap shadow-sm">
                    <div className="row w-100 d-flex align-items-center">
                        <div className="col-4 d-flex justify-content-start">
                            <Link className="text-decoration-none text-secondary" to="/">
                                <img className="img-fluid img-responsive mouse-hover"
                                    src="/Buddyhub-logo.png" alt="Logo" width="170" height="100" />
                            </Link>
                        </div>
                        <div className="col-4 d-flex justify-content-center"></div>
                        <div className="col-4 d-flex justify-content-end">
                            {isLoggedIn() && <>
                                <div className="d-flex align-items-center">
                                    <span className='me-2 border border-info rounded-circle mouse-hover'><img src={userImg} alt="user" width="35" height="35" className='rounded-circle m-0 p-0' /></span>
                                    <span className='me-4 fw-bold'>{sessionStorage.getItem('Name')}</span>
                                </div>

                                <span className='text-success px-1 me-2 ms-4' onClick={notification}><i className="far fs-4 fa-bell mouse-hover"></i></span>
                                <span className='text-primary px-1 py-0' onClick={logout}><i className="fas fs-4 fa-sign-out-alt mouse-hover"></i></span>
                            </>}
                            {!isLoggedIn() && <>
                                <NavBar />
                            </>}
                        </div>
                    </div>

                </div>
            </nav>

        </>
    );
};

export default Header;