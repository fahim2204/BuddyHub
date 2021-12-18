import React,{useState, useEffect} from 'react';
import GoogleLogin from 'react-google-login';
import axios from 'axios';
import { useAlert } from 'react-alert';
import { Link, useNavigate } from 'react-router-dom';
import FacebookLogin from 'react-facebook-login';
import { apiUrl } from '../Config';


//? Send All Axios Request with Token
// axios.interceptors.request.use(
//     config => {
//         config.headers.Authorization = `Bearer ${localStorage.getItem('token')}`;
//         return config;
//     },
//     error => {
//         return Promise.reject(error);
//     }
// )

const token = "abcdefghijklmnopqrstuvwxyz1234567890";
const authAxios = axios.create({
    baseURL: apiUrl,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        Authorization: `${token}`
    }
})


const Login = () => {

    useEffect(() => {document.title = "BuddyHub - Login"},[])
    var [clientInfo, setClientInfo] = useState({
        Ip : "127.0.0.1",
        Country: "Bangladesh",
    });
    var [loginInfo, SetLoginInfo] = useState({
        Username: "",
        Password: ""
    });
        

    const alert = useAlert();
    const navigate = useNavigate();


    const GetClientInfo = async () => {
        await axios.get(`https://geolocation-db.com/json`)
        .then(res => { 
            setClientInfo(res.data);
            console.log(res.data);
        })
        .catch(err => {
            console.log(err);
        })
         
    }


    const CheckOAuth = (user) => {
        axios.post(`${apiUrl}/CheckOAuth`, user)
            .then(res => {
                console.log(res);
                if (res.data === "Yes") {
                    alert.success("User Already Exists");
                } else {
                    alert.info("User Not Found");
                    navigate("/Register");
                }
            })
    }

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
        // SendLoginRequest(user);
        CheckOAuth(user);
    }
    const responseFacebook = (response) => {
        console.log(response);
        // let user = {
        //     Username: response.profileObj.email,
        //     Name: response.profileObj.name,
        //     Email: response.profileObj.email,
        //     ProfileImage: response.profileObj.imageUrl,
        //     OriginId: response.googleId,
        //     OriginName: 'Google',
        //     Password: response.googleId,
        // }
        // SendLoginRequest(user);
    }


    const Testtoken = () => {
        authAxios.get(`${apiUrl}/OBC`)
            .then(res => {
                console.log(res.data);
            })
            .catch(err => {
                console.log(err);
            })
    }
const HandleLoginForm = e => {
    SetLoginInfo({
        ...loginInfo,
        [e.target.name]: e.target.value
    })
}
const DoLogin = async () => {

    await axios.post(`${apiUrl}/Login`, loginInfo)
    .then(res => {
        console.log(res.data);
        if(res.data === "unauthorized"){
            alert.error("Wrong Credentials!!")
        }else if(res.data === "authorized"){
            alert.success("Success!!");
            console.log(res.data);
            sessionStorage.setItem('token', res.data);
            setTimeout(() => {
                navigate("/");
            },2000)
            // setTimeout
        }
        // else if(){}
        // navigate("/");
    })
        .catch(err => {
            alert.error('Opps!!!');
        })

        

}


    return (
        <div>
            {/* <button onClick={Testtoken}>Test Token</button> */}
            <div className="container">
                <div className="row d-flex justify-content-center">
                    <div className="col-5">
                        <div className="card shadow-lg rounded-3">
                            <div className="card-body">
                                <h4 className="card-title text-center text-capitalize fw-bold">Login</h4>
                                <hr />
                                <div className="">
                                    <div className="row mb-3">
                                        <label htmlFor="inputUsername" className="col-sm-3 col-form-label">Username :</label>
                                        <div className="col-sm-7">
                                            <input type="text" className="form-control" onChange={HandleLoginForm} name="Username" />
                                        </div>
                                    </div>
                                    <div className="row mb-3">
                                        <label htmlFor="inputPassword" className="col-sm-3 col-form-label">Password :</label>
                                        <div className="col-sm-7">
                                            <input type="password" className="form-control" onChange={HandleLoginForm} name="Password"/>
                                        </div>
                                    </div>
                                    <div className="d-flex justify-content-center mt-4">
                                        <button type="submit" onClick={DoLogin} className="btn btn-primary d-inline-block">Sign in</button>
                                    </div>
                                </div>

                                {/* Implement Login With Google OAuth */}
                                <div className="row d-flex justify-content-center mt-4">
                                    <div className="col-4 text-center align-self-center">
                                        <GoogleLogin
                                            clientId="197200157088-jok25uj7eb4dm1jhdie8f5cth1kntimu.apps.googleusercontent.com"
                                            buttonText="Login"
                                            onSuccess={responseGoogle}
                                            onFailure={responseGoogle}
                                            cookiePolicy={'single_host_origin'}
                                        />
                                    </div>
                                    <div className="col-4 text-center align-self-center">
                                        <FacebookLogin
                                            appId="408009050991275"
                                            autoLoad={false}
                                            fields="name,email,picture"
                                            callback={responseFacebook}
                                            textButton="Login"
                                            cssClass='btn btn-primary'
                                            icon="fa-facebook"
                                        />
                                    </div>
                                </div>
                                <h6 className='text-center mt-4 text-muted'>Not Registered Yet? <Link to="/register">Register</Link></h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;