import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import agent from "../actions/agent";
import { Category } from "../models/category";
import { Row } from "antd";
import ShowCourses from "../components/ShowCourses";

import { Course } from "../models/course";
const CategoryPage = () => {
    const [data, setData] = useState<Category>();
    // useParams извлекает параметры из URL в данном случае - id
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        agent.Categories.getCategory(parseInt(id!)).then((response) => {
            setData(response);
        });
    }, []);
    return (
        <div className="course">
            <div className="course__header">
                <h1>Pick a course from your favorite Category!</h1>
                <h2>{data?.name}</h2>
            </div>
            <Row gutter={[24, 32]}>
                {data?.courses?.length ? data.courses.map((course: Course, index: number) => {
                    return <ShowCourses key={index} course={course} />;
                }) : <h1> There are no courses in this Category!</h1>}
            </Row>
        </div>
    );
};

export default CategoryPage;