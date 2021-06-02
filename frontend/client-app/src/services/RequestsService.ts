import { Request } from './../models/ProjectModels';
import http from "../http-common";

const getAll = (): Promise<Request[]> => {
  return http.get("/requests");
};

const get = (id: string):Promise<Request> => {
  return http.get(`/requests/${id}`);
};

const getByName = (name: string):Promise<Request[]> => {
  return http.get(`/requests?name=${name}`)
  //ovde cemo da isfiltriramo i da vratimo by name ssss
};

const create = (data: Request) => {
  return http.post("/requests", data);
};

// const update = (id, data) => {
//   return http.put(`/requests/${id}`, data);
// };

// const remove = (id) => {
//   return http.delete(`/requests/${id}`);
// };

const requestsService = {
  getAll,
  get,
  getByName,
  create
  // update,
  // remove
};

export default requestsService;