import { Project } from './../models/ProjectModels';
import http from "../http-common";

const getAll = (): Promise<Project[]> => {
  return http.get("/projects");
};

const get = (id: string):Promise<Project> => {
  return http.get(`/projects/${id}`);
};

const getByName = (name: string):Promise<Project[]> => {
  return http.get(`/projects?name=${name}`)
  //ovde cemo da isfiltriramo i da vratimo by name ssss
};

const create = (data: any) => {
  return http.post("/projects/", data);
};

// const update = (id, data) => {
//   return http.put(`/projects/${id}`, data);
// };

// const remove = (id) => {
//   return http.delete(`/projects/${id}`);
// };

const projectservice = {
  getAll,
  get,
  getByName,
  create
  // update,
  // remove
};

export default projectservice;