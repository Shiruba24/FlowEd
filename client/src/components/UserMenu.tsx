import React from "react";
import { Dropdown, Menu } from "antd";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { signOut } from "../redux/slice/userSlice";

const UserMenu = () => {

    const dispatch = useDispatch();
    const navigate = useNavigate();
    const signout = () => {
        dispatch(signOut());
        navigate("/");
    };

    const menu = (
        <Menu>
            <Menu.Item>
                <Link to="/profile">Profile</Link>
            </Menu.Item>
            <Menu.Item>
                <div onClick={signout}>Logout</div>
            </Menu.Item>
        </Menu>
    );

    return (
        <Dropdown overlay={menu} placement="bottomCenter">
            <div className="dropdown">Menu</div>
        </Dropdown>
    );


};

export default UserMenu;