import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { apiUrl } from '../../Config';
import AdminNavbar from './AdminNavbar'

function AdminAllPost() {

    useEffect(() => {
        document.title = "BuddyHub - Profile";
        GetProfileData();
    }, []);

    var [profileInfo, SetprofileInfo] = useState();

    const GetProfileData = () => {
        console.log("Getting Data");

        axios.get(`${apiUrl}/profile`)
            .then(res => {
                console.log(res.data)
                // res.data.forEach(elem => {
                    
                // });
                SetprofileInfo(res.data)
                console.log(profileInfo);
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
                        <AdminNavbar />
                    </div>
                    <div className="col-9">
                        {profileInfo && profileInfo.map(user => 
                            <h5>{user.Name}</h5>
                        )}

                        
                    </div>
                </div>
            </div>
        </>
    )
}

export default AdminAllPost
