import React from 'react'
import { MenuItem } from '../mini/MenuItem'

function AdminNavbar() {
    return (
        <>
            <div className="srounded-3 shadow-sm">
                    <MenuItem icon="fas fa-home" title="Home" linkToGo="/login" />
                    <MenuItem icon="fas fa-amazon" title="Admin" linkToGo="/admin" />
                  
            </div>

        </>
    )
}

export default AdminNavbar
