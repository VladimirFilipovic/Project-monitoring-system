import { Project } from './../models/ProjectModels';
import http from "../http-common";

const getAll = (): Promise<Project[]> => {
  return http.get("/users");
};

const get = (id: string):Promise<Project> => {
  return http.get(`/users/${id}`);
};

const getByName = (name: string):Promise<Project[]> => {
  return http.get(`/users?name=${name}`)
  //ovde cemo da isfiltriramo i da vratimo by name ssss
};

const register = (data: any) => {
  return http.post("/users/", data);
};

const login = (data: any) => {
    return http.post("/users/login/", data);
  };

// const update = (id, data) => {
//   return http.put(`/users/${id}`, data);
// };

// const remove = (id) => {
//   return http.delete(`/users/${id}`);
// };

const userservice = {
  getAll,
  get,
  getByName,
  register,
  login
  // update,
  // remove
};

export default userservice;