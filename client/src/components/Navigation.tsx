import React, { useState } from "react";
import Logo from "../assets/logo.png";
import * as FaIcons from "react-icons/fa";
const Navigation = () => {
    const [sideBar, setSideBar] = useState(false);

    const showSideBar = () => setSideBar(!sideBar);


    return (
        <div className="nav-container">
            <div className="nav">
                <div className="nav__left">
                    <div className="nav__left__hamburger">
                        <FaIcons.FaBars onClick={showSideBar} />
                        <nav className={sideBar ? "nav-menu active" : "nav-menu"}>
                            <ul className="nav-menu-items">
                                <li className="cancel">
                                    <FaIcons.FaChevronLeft onClick={showSideBar} />
                                </li>
                                <li className="nav-menu-items__header">
                                    Navigation
                                </li>
                                <li>Categories</li>
                                <li>Course</li>
                            </ul>
                        </nav>
                    </div>
                    <img className="nav__left__logo" src={Logo} alt="logo" />
                    <ul className="nav__left__list">
                        <li className="nav__left__list__item">Categories</li>
                        <li className="nav__left__list__item">Courses</li>
                    </ul>
                </div>
                <div className="nav__right">
                    <form action="" className="nav__right__search">
                        <input type="text"
                            className="nav__right__search__input"
                            placeholder="Search Courses..." />

                        <button className="nav__right__search__button">
                            <FaIcons.FaSearch />
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Navigation;