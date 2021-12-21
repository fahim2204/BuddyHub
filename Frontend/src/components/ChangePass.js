import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAlert } from 'react-alert';
import { Link, useNavigate } from 'react-router-dom';
import { apiUrl } from '../Config';

const ChangePass = () => {
    const alert = useAlert();
    const navigate = useNavigate();

    var [errorMsg, setErrorMsg] = useState('');

    useEffect(() => { document.title = "BuddyHub - ChangePassword" }, [])
    var [passInfo, setPassInfo] = useState({
        Username: "",
        OldPass: "",
        NewPass: ""
    });

    return (
        <>
            <div>
                <h2>ChangePassword</h2>
                <form action method="post">
                    Old password: <input type="password" name="OldPass" defaultValue className="form-control" />
                    <br />
                    New password: <input type="password" name="NewPass" defaultValue className="form-control" />
                    <br />
                    Confirm password: <input type="password" name="ConfirmPassword" defaultValue className="form-control" />
                    <br />
                    <input type="submit" name="submit" defaultValue="Change password" className="btn btn-success" />
                </form>
            </div>
        </>
            )
}