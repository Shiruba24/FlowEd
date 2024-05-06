import React, { useState, useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";

function App() {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5226/api/courses").then((response) => {
      console.log(response);
      setCourses(response.data);
    });
  }, []);

  return (
    <div className="App">
      <ul>
        {courses.map((course: any, index) => {
          return (
            <li key={index}>
              {course.id}
              {course.title}
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default App;
