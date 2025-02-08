import { toast } from "react-toastify";
import axios from "axios";
import "react-toastify/dist/ReactToastify.css";

const axiosInstance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
  timeout: 5000,
});

axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    debugger;
    if (error.config.skipGlobalErrorHandler) {
      return Promise.reject(error);
    }

    if (error.response) {
      const status = error.response.status;
      if (status === 403) {
        toast.error("You do not have permission to access this resource.");
      } else if (status === 500) {
        toast.error("Server error. Please try again later.");
      } else {
        toast.error(
          `Error: ${
            error.response.data.message.message ||
            error.response.data.message ||
            error.message
          }`
        );
      }
    } else if (error.request) {
      toast.error(
        "No response from the server. Please check your connection.",
        {
          toastId: "No response from the server",
        }
      );
    } else {
      toast.error(`Request error: ${error.message}`);
    }

    return Promise.reject(error);
  }
);

export default axiosInstance;
