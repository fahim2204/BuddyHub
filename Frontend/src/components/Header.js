import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import NavBar from './NavBar';

const Header = () => {
    const navigate = useNavigate();

    const logout = () => {
        console.log(sessionStorage.getItem('LoggedUser'));        
        sessionStorage.clear();
        navigate("/login");
    }
    


    return (
        <>
            <nav className="navbar navbar-light bg-light fixed-top">
                <div className="container d-flex flex-nowrap shadow-sm">
                    <div className="row w-100 align-items-center">
                        <div className="col-4 d-flex justify-content-start">
                            <Link className="text-decoration-none text-secondary" to="/">
                                <img className="img-fluid img-responsive"
                                    src="/Buddyhub-logo.png" alt="Logo" width="170" height="100" />
                            </Link>
                        </div>
                    </div>
                    {sessionStorage.getItem('Token') ?  <>
                        <button className='btn btn-sm btn-success' onClick={logout}>Logout</button>
                    </>: <NavBar /> }
                    
                </div>
            </nav>

        </>
    );
};

export default Header;