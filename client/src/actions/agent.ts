import axios, {AxiosResponse} from "axios";
import {Course} from "../models/course";
import { PaginatedCourse } from "../models/paginatedCourse";
import { Category } from "../models/category";

import { Basket } from "../models/basket";
import { Login, Register, User } from "../models/users";
axios.defaults.baseURL = "http://localhost:5226/api";

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

axios.defaults.withCredentials = true;

const requests = {
    get: <T>(url: string, params?: URLSearchParams) => axios.get<T>(url, {params}).then(responseBody),
    post: <T>(url: string, body: object) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: object) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete(url).then<T>(responseBody)
};

const Users = {
    login: (values: Login) => requests.post<User>("users/login", values),
    register: (values: Register) => requests.post<User>("users/register", values)
};

const Courses = {
    list: (params?: URLSearchParams) => requests.get<PaginatedCourse>("/courses", params),
    getById: (id: string) => requests.get<Course>(`/courses/${id}`)
};

const Categories = {
    list: () => requests.get<Category[]>("/categories"),
    getCategory: (id: number) => requests.get<Category>(`/categories/${id}`)
};

const Baskets = {
    get: () => requests.get<Basket>("basket"),
    addItem: (courseId: string) => requests.post<Basket>(`basket?courseId=${courseId}`, {}),
    removeItem: (courseId: string) => requests.del(`basket?courseId=${courseId}`)
};


const agent = {
    Courses,
    Categories,
    Baskets,
    Users
};

export default agent;
