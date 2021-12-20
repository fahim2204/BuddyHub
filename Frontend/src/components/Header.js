import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import NavBar from './NavBar';
import { isLoggedIn } from '../Config';
import userImg from '../images/user.png';
import '../App.css';
import { Popover } from 'react-tiny-popover'

const Header = () => {
    const navigate = useNavigate();

    const logout = () => {
        console.log(sessionStorage.getItem('LoggedUser'));
        sessionStorage.clear();
        navigate("/login");
    }
    const [isPopoverOpen, setIsPopoverOpen] = useState(false);

    const notification = () => {
        alert("You are logged out!");
    }

    return (
        <>
            <nav className="navbar fixed-top bg-light">
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
                                    <span className='me-2 border border-info rounded-circle mouse-hover'><Link to={"/profile/" + sessionStorage.getItem('Id')}><img src={userImg} alt="user" width="35" height="35" className='rounded-circle m-0 p-0' /></Link></span>
                                    <span className='me-4 fw-bold'>{sessionStorage.getItem('Name')}</span>
                                </div>
                                {/* <span className='text-success px-1 me-2 ms-4' onClick={notification}><i className="far fs-4 fa-bell mouse-hover"></i></span>*/}


                                <Popover
                                    isOpen={isPopoverOpen}
                                    positions={['bottom', 'left']} // if you'd like, you can limit the positions
                                    padding={10} // adjust padding here!
                                    reposition={false} // prevents automatic readjustment of content position that keeps your popover content within its parent's bounds
                                    onClickOutside={() => setIsPopoverOpen(false)} // handle click events outside of the popover/target here!
                                    content={({ position, nudgedLeft, nudgedTop }) => ( // you can also provide a render function that injects some useful stuff!
                                        // <div>
                                        //     <div>Hi! I'm popover content. Here's my current position: {position}.</div>
                                        //     <div>I'm {` ${nudgedLeft} `} pixels beyond my boundary horizontally!</div>
                                        //     <div>I'm {` ${nudgedTop} `} pixels beyond my boundary vertically!</div>
                                        // </div>
                                        <>
                                            <div className="p-2 border shadow rounded-3 align-items-center bg-light">
                                                <h6>
                                                    <Link className="text-decoration-none text-success" to="Profile/@Html.DisplayFor(modelItem => item.FK_Notifier_Username)"> Fahim Faisal </Link>
                                                    <Link className="text-decoration-none text-primary" to="@Html.DisplayFor(modelItem => item.GotoLink)"> Likes </Link> at  10:12PM
                                                </h6>
                                                <hr />
                                                <h6>
                                                    <Link className="text-decoration-none text-success" to="Profile/@Html.DisplayFor(modelItem => item.FK_Notifier_Username)"> Fahim Faisal </Link>
                                                    <Link className="text-decoration-none text-primary" to="@Html.DisplayFor(modelItem => item.GotoLink)"> Likes </Link> at  10:12PM
                                                </h6>
                                                <hr />

                                            </div>

                                        </>
                                    )}
                                >
                                    {/* <div onClick={() => setIsPopoverOpen(!isPopoverOpen)}>Click me!</div> */}
                                    <span className='text-success px-1 me-2 ms-4' onClick={() => { setIsPopoverOpen(!isPopoverOpen); console.log(isPopoverOpen) }}><i className="far fs-4 fa-bell mouse-hover"></i></span>
                                </Popover>



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