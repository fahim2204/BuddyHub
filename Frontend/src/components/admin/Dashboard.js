import React from 'react'
import AdminNavbar from './AdminNavbar'

function Dashboard() {
    return (
        <>
            <div className="container">
                <div className="row">
                    <div className="col-3">
                        <AdminNavbar />
                    </div>
                    <div className="col-9">
                    </div>
                </div>
            </div>
        </>
    )
}

export default Dashboard
