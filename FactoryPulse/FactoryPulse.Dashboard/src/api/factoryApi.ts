import API from "./baseApi";

export const getFactories = () =>
    API.get("/factory")