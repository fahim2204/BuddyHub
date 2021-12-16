import React, { useEffect } from 'react'

function Home() {

    useEffect(() => {document.title = "BuddyHub - Home"},[])



    return (
        <div>
            <h5>This is Home</h5>
        </div>
    )
}

export default Home
