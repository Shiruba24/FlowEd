import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import Logo from "../assets/logo.png";
import * as FaIcons from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import { useAppSelector } from "../redux/store/configureStore";
import { useDispatch } from "react-redux";
import { setCourseParams } from "../redux/slice/courseSlice";
import UserMenu from "./UserMenu";
import { signOut } from "../redux/slice/userSlice";
const Navigation = () => {
    const [sideBar, setSideBar] = useState(false);
    const [searchText, setSearchText] = useState("");

    const showSideBar = () => setSideBar(!sideBar);


    const { basket } = useAppSelector((state) => state.basket);
    const { user } = useAppSelector((state) => state.user);
    const dispatch = useDispatch();
    const basketCount = basket?.items.length;
    const navigate = useNavigate();
    const signout = () => {
        dispatch(signOut());
        navigate("/");
    };

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearchText(e.target.value);
    };

    const onSearch = (e: SyntheticEvent) => {
        e.preventDefault();
        dispatch(setCourseParams({ search: searchText }));
    };

    return (
        <div className="nav-container">
            <div className="nav">
                <div className="nav__left">
                    <div className="nav__left__hamburger">
                        <FaIcons.FaBars onClick={showSideBar} />
                        <nav className={sideBar ? "nav-menu active" : "nav-menu"}>
                            <ul className="nav-menu-items" onClick={showSideBar} >
                                <li className="cancel">
                                    <FaIcons.FaChevronLeft />
                                </li>
                                <li className="nav-menu-items__header">
                                    Navigation
                                </li>
                                <Link to="/">
                                    {" "}
                                    <li>Home</li>{" "}
                                </Link>
                                {user ?
                                    (<>
                                        {" "}
                                        <Link to="/proflie">
                                            <li>Profile</li></Link>{" "}
                                        <div onClick={signout}>
                                            {" "}
                                            <li>Logout</li>{" "}
                                        </div>{" "}
                                    </>) :
                                    <Link to="/login">
                                        <li>Login</li>
                                    </Link>}

                            </ul>
                        </nav>
                    </div>
                    <img className="nav__left__logo" src={Logo} alt="logo" />
                    <ul className="nav__left__list">
                        <Link to="/">
                            <li className="nav__left__list__item">Home</li>
                        </Link>
                        {user ? (
                            <li className="nav__left__list__item"><UserMenu /></li>) :
                            (
                                <Link to="/login">
                                    <li className="nav__left__list__item">Login</li>
                                </Link>)}
                    </ul>
                </div>
                <div className="nav__right">
                    <form onSubmit={onSearch} action="" className="nav__right__search">
                        <input type="text"
                            className="nav__right__search__input"
                            placeholder="Search Courses..."
                            value={searchText}
                            onChange={handleChange}
                        />

                        <button className="nav__right__search__button">
                            <FaIcons.FaSearch />
                        </button>
                    </form>
                    <Link to="/basket">
                        <div className="nav__right__cart">
                            <FaIcons.FaShoppingCart />
                            {basketCount! > 0 && (<span className="nav__right__cart__count">{basketCount}</span>)}
                        </div>
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default Navigation;