import React, { useEffect } from "react";
import { Route, Routes } from "react-router-dom";

import Homepage from "./pages/Homepage";
import LoginPage from "./pages/Login";
import DetailPage from "./pages/DetailPage";
import Navigation from "./components/Navigation";
import "antd/dist/reset.css";
import Category from "./components/Categories";
import CategoryPage from "./pages/CategoryPage";
import DescriptionPage from "./pages/DescriptionPage";
import BasketPage from "./pages/BasketPage";

import agent from "./actions/agent";
import { setBasket } from "./redux/slice/basketSlice";
import { useAppDispatch } from "./redux/store/configureStore";
function App() {
  const dispatch = useAppDispatch();
  function getCookie(name: string) {
    return (
      document.cookie.match("(^|;)\\s*" + name + "\\s*=\\s*([^;]+)")?.pop() ||
      ""
    );
  }

  useEffect(() => {
    const clientId = getCookie("client_id");

    if (clientId) {
      agent.Baskets.get()
        .then((response) => {
          dispatch(setBasket(response));
        })
        .catch((error) => console.log(error));
    }
  }, [dispatch]);

  return (
    <div>
      <Navigation />
      <Routes>
        <Route path="/" element={<Category />} />
      </Routes>
      <Routes>
        <Route path="/" element={<Homepage />} />
        <Route path="/category/:id" element={<CategoryPage />} />
        <Route path="/basket" element={<BasketPage />} />
        <Route path="/course/:id" element={<DescriptionPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/detail" element={<DetailPage />} />

      </Routes>
    </div>
  );
}

export default App;
