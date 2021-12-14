import React from 'react';

const Header = () => {
    return (
        <>
            <nav className="navbar navbar-light bg-light fixed-top">
                <div className="container d-flex flex-nowrap shadow-sm">
                    <div className="row w-100 align-items-center">
                        <div className="col-4 d-flex justify-content-start">
                            <a className="text-decoration-none text-secondary" href="/Home/Index">
                                <img className="img-fluid img-responsive"
                                    src="" alt="Logo" width="70" height="50" />
                                <h5 className="d-inline-block ms-1 font-monospace">
                                    BuddyHub
                                </h5>
                            </a>

                        </div>
                    </div>
                </div>
            </nav>

        </>
    );
};

export default Header;