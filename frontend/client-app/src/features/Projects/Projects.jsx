import { Container } from 'semantic-ui-react'
import { HeroH1Black } from '../Home/home-style'
import React, { useState, useEffect, useMemo, useRef } from "react";
import ProjectsServices from '../../services/ProjectsService';
import { Project } from '../../models/ProjectModels';
import { Column, useTable } from "react-table";

// export default function Projects() {
//   return (
//       <Container style={{marginTop: '7em'}}>
//           <HeroH1Black> Your requested projects </HeroH1Black>
//       </Container>
//   )
// }

const ProjectsList = (props) => {
    const [projects, setProjects] = useState([]);
    const [searchName, setSearchName] = useState("");
    const projectsRef = useRef(null);
  
    projectsRef.current = projects;
  
    useEffect(() => {
      retrieveProjects();
    }, []);

    const onChangeSearchName = (e) => {
        const searchName = e.target.value;
        setSearchName(searchName);
      };  

    const retrieveProjects = () => {
        ProjectsServices.getAll()
          .then((response) => {

            setProjects(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
      };  

    const refreshList = () => {
        retrieveProjects();
      };  

    // const removeAllProjects = () => {
    //     ProjectsService.removeAll()
    //       .then((response) => {
    //         console.log(response.data);
    //         refreshList();
    //       })
    //       .catch((e) => {
    //         console.log(e);
    //       });
    //   };  
    const findByName = () => {
        ProjectsServices.getByName(searchName.toString())
          .then((response) => {
            setProjects(response.data);
          })
          .catch((e) => {
            setProjects([]);
            console.log(e);
          });
      };

      //ovde rowIndex mozda any
      const openProject = (rowIndex) => {
        if(projectsRef.current) {
        const id = projectsRef.current[rowIndex].id;
        props.history.push("/projects/" + id);
        }
      }; 
      
    //   const deleteProject = (rowIndex: number) => {
    //     if(projectsRef.current) {
    //     const id = projectsRef.current[rowIndex].id;
        
    
    //     ProjectsService.remove(id)
    //       .then((response) => {
    //         props.history.push("/tutorials");
    
    //         let newTutorials = [...tutorialsRef.current];
    //         newTutorials.splice(rowIndex, 1);
    
    //         setTutorials(newTutorials);
    //       })
    //       .catch((e) => {
    //         console.log(e);
    //       });
    //     }
    //   }

    const columns = React.useMemo(
        () => [
          {
            Header: "Name",
            accessor: "name",
          },
          {
            Header: "Accepted",
            accessor: "request",
            Cell: (props) => {
              if(props.data[props.row.id].isCompleted === true) {
                return props.value.accepted ? "Project Accepted" : "Project Rejected";
              }
              else {
                return props.value.accepted ? "Project Accepted" : "Waiting for review";
              }
            }
          },
          {
            Header: "Deadline",
            accessor: "deadline",
            Cell: (props) => {
              return new Date(props.value).toUTCString();
            }
          },
          {
            Header: "Completed",
            accessor: "isCompleted",
            Cell: (props) => {
              return props.value ? "Completed" : "In-progress";
            },
          },
          {
            Header: "Deleted",
            accessor: "deleted",
            Cell: (props) => {
                return props.value ? "Deleted": "Active"
            }
          },
          {
            Header: "Actions",
            accessor: "actions",
            Cell: (props) => {
              const rowIdx = props.row.id;
              return (
                <div>
                  <span onClick={() => openProject(rowIdx)}>
                    <i class="fas fa-money-check-alt"  action mr-2></i>
                  </span>
                </div>
              );
            },
          },
        ],
        []
      );

      
    //   const {
    //     getTableProps,
    //     getTableBodyProps,
    //     headerGroups,
    //     rows,
    //     prepareRow,
    //   } = useTable({
    //     columns,
    //     data: projects,
    //   });

    const {
      getTableProps,
      getTableBodyProps,
      headerGroups,
      rows,
      prepareRow,
    } = useTable({
      columns,
      data: projects,
    });

  return (
    <Container style={{marginTop: '7em'}}>
          
    <div style={{position: 'relative', marginBottom: '5em'}}>
    <HeroH1Black> Your requested projects </HeroH1Black>
    </div>
    <div style={{position: 'relative'}}>
        <div className="list row">
      <div className="col-md-8">
        <div className="input-group mb-3">
          <input
            type="text"
            className="form-control"
            placeholder="Search by title"
            value={searchName}
            onChange={onChangeSearchName}
          />
          <div className="input-group-append">
            <button
              className="btn btn-outline-secondary"
              type="button"
              onClick={findByName}
            >
              Search
            </button>
          </div>
        </div>
      </div>
      <div className="col-md-12 list">
        <table
          className="table table-striped table-bordered"
          {...getTableProps()}
        >
          <thead>
            {headerGroups.map((headerGroup) => (
              <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map((column) => (
                  <th {...column.getHeaderProps()}>
                    {column.render("Header")}
                  </th>
                ))}
              </tr>
            ))}
          </thead>
          <tbody {...getTableBodyProps()}>
            {rows.map((row, i) => {
              prepareRow(row);
              return (
                <tr {...row.getRowProps()}>
                  {row.cells.map((cell) => {
                    return (
                      <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                    );
                  })}
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
    </div>
    </Container>
  );

}

export default ProjectsList
 


