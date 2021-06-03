import React from 'react'
import {TableRow, TableBody, TableCell, Typography, Button, Grid} from '@material-ui/core';
import useTable from '../../app/common/table/UseTable';


const headCells = [
    {id:'name', label:'Name', disableSorting:true},
    {id:'description', label:'Description', disableSorting:true},
    {id:'completed', label:'Completed', disableSorting:true},

]

//const align="right"
const align="left"
//const align="center"

export default function TasksTable(props) {
    const {tasks} = props;

    const {
        TblContainer,
        TblHead, 
        TblPagination,
        recordsAfterPaging,
        recordsAfterPagingAndSorting, 
        TblHeadSort
        } =useTable(tasks, headCells, null, align);

    return (
        <>
            <TblContainer style={{marginTop:'0px'}}>
            < TblHead/>
                <TableBody style={{marginTop:'0px'}}>
                   
                    {
                        tasks.map(item => (
                      <TableRow key={item.id}>
                            <TableCell  align={align}>{item.name}</TableCell>
                            <TableCell align={align}>{item.description}</TableCell>
                            <TableCell align={align}>{item.completed?"true":"false"}</TableCell>
                        </TableRow>
                        ))
                    }
                </TableBody>
            </TblContainer>
            </>
    )
}
