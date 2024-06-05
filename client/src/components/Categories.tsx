
import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import agent from "../actions/agent";
import { Category } from "../models/category";
const Categories = () => {
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        agent.Categories.list().then((response) => {
            setCategories(response);
        });
    }, []);

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