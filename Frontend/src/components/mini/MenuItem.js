import React from 'react';
import { NavLink } from 'react-router-dom';

export const MenuItem = ({ ...props }) => {
    return (
     
            <NavLink to={props.linkToGo} className={c => c.isActive ? "row d-flex align-items-center text-danger text-decoration-none" : "row d-flex align-items-center text-decoration-none"}> 
            <div className="col-2 d-flex justify-content-center"><i className={props.icon}></i></div>
            <div className="col-10 d-flex justify-content-start">{props.title}</div>
             </NavLink>

      
    )
}
