import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Header from './components/Header'
import Login from './components/Login'
import Register from './components/Register';
import Home from './components/Home';
import ProfileCard from './components/ProfileCard';


function App() {
  return (
    <>
    <Header />
      <Routes>
        {/* <Route path="/" element={<Navigate to="/login" />} /> */}
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/profile"  element={<ProfileCard/>}/>
      </Routes>
    </>
  );
}

export default App;
