import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Header from './components/Header'
import Login from './components/Login'
import Register from './components/Register';
import Home from './components/Home';
import ProfileCard from './components/ProfileCard';
import Dashboard from './components/admin/Dashboard';
import AdminAllUser from './components/admin/AdminAllUser';
import AdminAllPost from './components/admin/AdminAllPost';


function App() {
  return (
    <>
    <Header />
      <Routes>
        {/* <Route path="/" element={<Navigate to="/login" />} /> */}
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/profile/:id"  element={<ProfileCard/>}/>
        <Route path="/admin/home" element={<Dashboard />} />
        <Route path="/admin/all-user" element={<AdminAllUser />} />
        <Route path="/admin/all-post" element={<AdminAllPost />} />
      </Routes>
    </>
  );
}

export default App;
