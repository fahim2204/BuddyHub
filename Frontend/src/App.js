import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom"
import Header from './components/Header'
import Login from './components/Login'

function App() {
  return (
    <>
      <Header />
      <Login />
    </>

  );
}

export default App;
