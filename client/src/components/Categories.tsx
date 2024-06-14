
import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import agent from "../actions/agent";
import { Category } from "../models/category";
import { useAppDispatch, useAppSelector } from "../redux/store/configureStore";
import { categoriesSelector, getCategoriesAsync } from "../redux/slice/categorySlice";
const Categories = () => {
    const categories = useAppSelector(categoriesSelector.selectAll);
    const { categoriesLoaded } = useAppSelector((state) => state.category);
    const dispatch = useAppDispatch();
    useEffect(() => {
        if (!categoriesLoaded) dispatch(getCategoriesAsync());
    }, [categoriesLoaded, dispatch]);

    return (
        <div className="categories">
            {categories && categories.map((category: Category, index: number) => {
                return (
                    <Link key={index} to={`category/${category.id}`}>
                        <div className="categories_name">
                            {category.name}
                        </div>
                    </Link>
                );
            })}
        </div>
    );
};

export default Categories;