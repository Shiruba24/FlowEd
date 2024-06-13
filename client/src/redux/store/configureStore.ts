import { configureStore } from "@reduxjs/toolkit";
import { loginSlice } from "../slice/loginSlice";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { basketSlice } from "../slice/basketSlice";



export const store = configureStore({
    reducer:{
        login: loginSlice.reducer,
        basket: basketSlice.reducer
    }
});


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;