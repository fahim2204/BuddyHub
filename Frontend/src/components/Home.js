import React, { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

function Home() {

    useEffect(() => {document.title = "BuddyHub - Home"},[])
    const navigate = useNavigate();

    // const isLoggedIn = us


    
if(sessionStorage.getItem('Token')){
    return navigate('/login');
}else{

    return (
        <div>
            <h5>This is Home</h5>
        </div>
    )
}


}

export default Home
