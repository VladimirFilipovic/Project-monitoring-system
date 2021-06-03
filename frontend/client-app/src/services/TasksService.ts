import http from "../http-common";

const create = (data: any) => {
    return http.post("/tasks/", data);
  };

const projectservice = {
    create
  };
  
  export default projectservice;