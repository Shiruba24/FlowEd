import React from "react";
import { Route, Routes } from "react-router-dom";

import Homepage from "./pages/Homepage";
import LoginPage from "./pages/Login";
import DetailPage from "./pages/DetailPage";
import Navigation from "./components/Navigation";
import "antd/dist/reset.css";
import Category from "./components/Categories";
function App() {

  return (
    <div>
      <Navigation />
      <Routes>
        <Route path="/" element={<Category />} />
      </Routes>
      <Routes>
        <Route path="/" element={<Homepage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/detail" element={<DetailPage />} />

      </Routes>
    </div>
  );
}

export default App;
