import axios from "axios";

const API = axios.create({
    baseURL: "https://localhost:7349/api",
    headers: { "Content-Type": "application/json" }
});

API.interceptors.response.use(
    (response) => response.data, 
    (error) => {
        console.error("API Error:", error.response?.data || error.message);
        return Promise.reject(error);
    }
);

export default API;