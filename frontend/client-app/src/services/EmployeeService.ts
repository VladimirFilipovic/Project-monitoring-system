import { Employee } from './../models/EmployeeModels';
import http from "../http-common";

const getAll = (): Promise<Employee[]> => {
    return http.get("/employees");
  };

  const employeeservice = {
    getAll
  };
  
  export default employeeservice;