import React from "react";
import { increment } from "../redux/loginRreduces";
import { useAppDispatch, useAppSelector } from "../redux/store/configureStore";

const Login = () => {

    const { visits } = useAppSelector((state) => state.login);

    const dispatch = useAppDispatch();



    return (<>
        <h1>Number of Visits: {visits}</h1>
        <button onClick={() => dispatch(increment(5))}>Increment</button>
    </>);
};

export default Login;