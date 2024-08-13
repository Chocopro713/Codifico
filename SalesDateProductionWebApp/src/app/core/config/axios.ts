
import axios from "axios";


const baseURL = `https://localhost:44315`;

const authorizationExclude: any = [
    '/Auth-login'
];

const config = {
    baseURL,
};

const axiosIns = axios.create(config);

axiosIns.interceptors.request.use(
    async (response: any) => {

        response.headers["Content-Type"] = `application/json`;
        response.headers["ngrok-skip-browser-warning"] = "1";

        return response;
    },
    (error) => { }
);

axiosIns.interceptors.response.use( //@ts-ignore
    (response: any) => {
        return Promise.resolve({
            status: response.status,
            data: response.data
        });
    },
    async (error: any) => {

        return Promise.reject({
            status: error.response.status,
            data: error.response.data
        });
    }
);

export default axiosIns;
