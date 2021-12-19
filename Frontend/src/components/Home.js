import React, { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { isLoggedIn } from '../Config';
import { useAlert } from 'react-alert';


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
                            </div>
                        </div>
                        <div className="col-4">
                            side Menu
                        </div>
                    </div>
                </div>
            </>}
        </>

    )



}

export default Home
