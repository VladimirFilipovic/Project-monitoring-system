import http from "../http-common";

const getAll = () => {
  return http.get("/projects");
};

const get = (id: string) => {
  return http.get(`/projects/${id}`);
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

const projectservice = {
  getAll,
  get
  // create,
  // update,
  // remove
};

export default projectservice;