import React from 'react'
import {TableRow, TableBody, TableCell, Typography, Button, Grid} from '@material-ui/core';
import useTable from '../../app/common/table/UseTable';


const headCells = [
    {id:'name', label:'Name', disableSorting:true},
    {id:'dateCreated', label:'Creation Date', disableSorting:true},
    {id:'download', label:'Download', disableSorting:true},

]

//const align="right"
const align="left"
//const align="center"

export default function DemosTable(props) {

    const {demos} = props;

    const {
        TblContainer,
        TblHead, 
        TblPagination,
        recordsAfterPaging,
        recordsAfterPagingAndSorting, 
        TblHeadSort
        } =useTable(demos, headCells, null, align);

    return (
        <>
            <TblContainer style={{marginTop:'0px'}}>
            < TblHead/>
                <TableBody style={{marginTop:'0px'}}>
                   
                    {
                        demos.map(item => (
                      <TableRow key={item.id}>
                            <TableCell  align={align}>{item.name}</TableCell>
                            <TableCell align={align}>{new Date(item.dateCreated).toUTCString()}</TableCell>
                            <TableCell align={align}>
                                <Button variant="outlined" color="primary">
                                    Download
                                </Button>
                            </TableCell>
                        </TableRow>
                        ))
                    }
                </TableBody>
            </TblContainer>
            </>
    )
}
