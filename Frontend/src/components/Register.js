import React, { useState, useEffect } from 'react';
import GoogleLogin from 'react-google-login';
import axios from 'axios';
import { useAlert } from 'react-alert';
import { useNavigate } from 'react-router-dom';
import { apiUrl } from '../Config';


const Register = () => {

    const alert = useAlert();
    const navigate = useNavigate();

    useEffect(() => { document.title = "BuddyHub - Registration" }, [])
    var [registrationInfo, SetRegistrationInfo] = useState({
        Username: "",
        Password: ""
    });


    const SendLoginRequest = (user) => {
        axios.post(`https://localhost:44349/Api/oauth`, user)
            .then(res => {
                console.log("Resource adata");
                console.log(res);
                // console.log(res.data);
            })
            .catch(err => {
                if (err === undefined) {
                    alert.show('Something went wrong');
                } else {
                    console.log(err.response.data.Message);
                    if (err.response.data.Message === "Already Registered!!") {
                        alert.show('You are already Registered!!', {
                            timeout: 5000, // custom timeout just for this one alert
                            type: 'success',
                            onOpen: () => {
                                console.log('hey')
                            }, // callback that will be executed after this alert open
                            onClose: () => {
                                console.log('closed')
                            } // callback that will be executed after this alert is removed
                        });
                    } else {
                        alert.error('Opps!!!', {
                            timeout: 5000,
                            onOpen: () => {
                                console.log('hey')
                            },
                            onClose: () => {
                                console.log('closed')
                            }
                        })
                    }
                }
                // console.log(err.response.status);
            })
    }

    const responseGoogle = (response) => {
        console.log(response);
        let user = {
            Username: response.profileObj.email,
            Name: response.profileObj.name,
            Email: response.profileObj.email,
            ProfileImage: response.profileObj.imageUrl,
            OriginId: response.googleId,
            OriginName: 'Google',
            Password: response.googleId,
        }
        SendLoginRequest(user);
    }

    const HandleRegistrationForm = e => {
        SetRegistrationInfo({
            ...registrationInfo,
            [e.target.name]: e.target.value
        })
    }
    const DoRegistration = async () => {
        await axios.post(`${apiUrl}/Login`, registrationInfo)
            .then(res => {
                console.log(res.data);
                sessionStorage.setItem('token', res.data.token);
                navigate("/");
            })
            .catch(err => {
                alert.error('Opps!!!');
            })

    }

    return (
        <div>
            <div className="container">
                <div className="row d-flex justify-content-center">
                    <div className="col-5">
                        <div className="card shadow-lg rounded-3">
                            <div className="card-body">
                                <h4 className="card-title text-center text-capitalize fw-bold">Registration</h4>
                                <hr />
                                <div className="">
                                    <div className="row mb-3">
                                        <label htmlFor="inputUsername" className="col-sm-3 col-form-label">Username :</label>
                                        <div className="col-sm-7">
                                            <input type="text" className="form-control" onChange={HandleRegistrationForm} name="Username" />
                                        </div>
                                    </div>
                                    <div className="row mb-3">
                                        <label htmlFor="inputPassword" className="col-sm-3 col-form-label">Password :</label>
                                        <div className="col-sm-7">
                                            <input type="password" className="form-control" onChange={HandleRegistrationForm} name="Password" />
                                        </div>
                                    </div>
                                    <div className="d-flex justify-content-center mt-4">
                                        <button type="submit" onClick={DoRegistration} className="btn btn-primary d-inline-block">Register</button>
                                    </div>
                                </div>

                                {/* Implement Login With Google OAuth */}
                                <div className="d-flex justify-content-center mt-4">
                                    <GoogleLogin
                                        clientId="197200157088-jok25uj7eb4dm1jhdie8f5cth1kntimu.apps.googleusercontent.com"
                                        buttonText="Login"
                                        // scope = 'https://www.googleapis.com/auth/user.birthday.read https://www.googleapis.com/auth/user.gender.read https://www.googleapis.com/auth/userinfo.profile'
                                        onSuccess={responseGoogle}
                                        onFailure={responseGoogle}
                                        cookiePolicy={'single_host_origin'}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Register;