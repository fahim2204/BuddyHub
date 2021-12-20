import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Header from './components/Header'
import Login from './components/Login'
import Register from './components/Register';
import Home from './components/Home';
import Dashboard from './components/admin/Dashboard';


function App() {
  return (
    <>
    <Header />
      <Routes>
        {/* <Route path="/" element={<Navigate to="/login" />} /> */}
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/admin" element={<Dashboard />} />
      </Routes>
    </>
  );
}

export default App;
