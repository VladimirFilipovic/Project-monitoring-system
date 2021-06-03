import React, {useState, useEffect, useRef} from 'react'
import useTable from '../../app/common/table/UseTable';
import ProjectsServices from '../../services/ProjectsService';
import {TableRow, TableBody, TableCell, Button, makeStyles} from '@material-ui/core';
import CreditCardTwoToneIcon from '@material-ui/icons/CreditCardTwoTone';
import { useHistory } from "react-router-dom";

const headCells = [
    {id:'name', label:'Name'},
    {id:'isCompleted', label:'Accepted', disableSorting:true},
    {id:'deadline', label:'Deadline', },
    {id:'isCompleted', label:'Completed'},
    {id:'deleted', label:'Deleted'},
    {id:'action', label:'Action',  disableSorting:true}
    
]

export default function ProjectsTable(props) {

    const [filterFn, setfilterFn] = useState({fn: items => {return items;}});
    const [projects, setProjects] = useState([]);
    const [searchName, setSearchName] = useState("");
    const projectsRef = useRef(null);
    
    const {
        TblContainer,
        TblHead, 
        TblPagination,
        recordsAfterPaging,
        recordsAfterPagingAndSorting, 
        TblHeadSort
        } =useTable(projects, headCells, filterFn);

    useEffect(() => {
        retrieveProjects();
        }, []);

    const retrieveProjects = () => {
        ProjectsServices.getAll()
            .then((response) => {

            setProjects(response.data);
            })
            .catch((e) => {
            console.log(e);
            });
        };

    const onChangeSearchName = (e) => {
        const searchName = e.target.value;
        setSearchName(searchName);
        };  

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
        props.rowIndexhistory.push("/projects/" + id);
         }
    };
    
    const handleRowClick = (item) => {
        console.log('handleRowClick');
        props.history.push('projects-details/'+item.id);
    }
          
    
    const handleCreditCard = (e) => {
        e.stopPropagation();
        console.log('handleCreditCard');
    }

    return (
        <div>
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
            <TblContainer>
           
                <TblHeadSort/>
                <TableBody>
                    {
                        recordsAfterPagingAndSorting().map(item => (
                            <TableRow key={item.id} onClick={() => handleRowClick(item)}>
                                <TableCell>{item.name}</TableCell>
                                <TableCell>{item.isCompleted ? (item.request.accepted? "Project Accepted": "Project Rejected"):(item.request.accepted? "Project Accepted": "Waiting for review")}</TableCell>
                                <TableCell>{new Date(item.deadline).toUTCString()}</TableCell>
                                <TableCell>{item.isCompleted ? "Completed" : "In-progress"}</TableCell>
                                <TableCell>{item.deleted ? "Deleted": "Active"}</TableCell>
                                <TableCell>
                                    <CreditCardTwoToneIcon fontSize="small"
                                        onClick={(e) => handleCreditCard(e)}/>  
                                </TableCell>
                                
                            </TableRow>
                        ))
                    }
                </TableBody>
            </TblContainer>
            <TblPagination/>
        </div>
    )
}
