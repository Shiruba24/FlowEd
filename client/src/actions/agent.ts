import axios, {AxiosResponse} from "axios";
import {Course} from "../models/course";
import { PaginatedCourse } from "../models/paginatedCourse";
import { Category } from "../models/category";
axios.defaults.baseURL = "http://localhost:5226/api";

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: object) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: object) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete(url).then<T>(responseBody)
};

const Courses = {
    list: () => requests.get<PaginatedCourse>("/courses"),
    getById: (id: string) => requests.get<Course>(`/courses/${id}`)
};

const Categories = {
    list: () => requests.get<Category[]>("/categories"),
    getCategory: (id: number) => requests.get<Category>(`/categories/${id}`)
};

const agent = {
    Courses,
    Categories
};

export default agent;
