import { store } from '../stores/store';
import http from "../http-common";
import { Project } from './../models/ProjectModels';

const getAll = (): Promise<Project[]> => {
  const config = {
    headers: {
      Authorization: 'Bearer ' + store.commonStore.token
    }
  }
  return http.get("/users",config);
};

const get = (id: string):Promise<Project> => {
  return http.get(`/users/${id}`);
};

const getByName = (name: string):Promise<Project[]> => {
  return http.get(`/users?name=${name}`)
  //ovde cemo da isfiltriramo i da vratimo by name ssss
};

const register = (data: any) => {
  return http.post("/users/register", data);
};

const login = (data: any) => {
    return http.post("/users/login/", data);
  };

 const current = () => {
  const config = {
    headers: {
      Authorization: 'Bearer ' + store.commonStore.token
    }
  }
   return http.get("/users", config);
 }

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
  login,
  current
  // update,
  // remove
};

export default userservice;