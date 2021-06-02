import { Project } from '../models/ProjectModels';
import http from "../http-common";

const getAll = () => {
  return http.get("/projects");
};

const get = (id) => {
  return http.get(`/projects/${id}`);
};

const getByName = (name) => {
  console.log(name)
  return http.get(`/projects?name=${name}`)
  //ovde cemo da isfiltriramo i da vratimo by name ssss
};

// const create = (data: string) => {
//   return http.post("/projects", data);
// };

// const update = (id, data) => {
//   return http.put(`/projects/${id}`, data);
// };

// const remove = (id) => {
//   return http.delete(`/projects/${id}`);
// };

const projectservices = {
  getAll,
  get,
  getByName
  // create,
  // update,
  // remove
};

export default projectservices;