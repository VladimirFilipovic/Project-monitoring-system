import React from 'react'
import {TableRow, TableBody, TableCell, Typography, Button, Grid} from '@material-ui/core';
import useTable from '../../app/common/table/UseTable';

const headCells = [
    {id:'date', label:'Date', disableSorting:true},
    {id:'amount', label:'Amount', disableSorting:true},
    {id:'companyName', label:'Company Name', disableSorting:true},

]

//const align="right"
const align="left"
//const align="center"


export default function PaymentsTable(props) {
    const {payments} = props;

    const {
        TblContainer,
        TblHead, 
        TblPagination,
        recordsAfterPaging,
        recordsAfterPagingAndSorting, 
        TblHeadSort
        } =useTable(payments, headCells, null, align);

    return (
        <>
            <TblContainer style={{marginTop:'0px'}}>
            < TblHead/>
                <TableBody style={{marginTop:'0px'}}>
                   
                    {
                        payments.map(item => (
                      <TableRow key={item.id}>
                            <TableCell  align={align}>{new Date(item.date).toUTCString()}</TableCell>
                            <TableCell align={align}>{item.amount}{item.currency}</TableCell>
                            <TableCell align={align}>{item.client?item.client.clientName:"Company Name"}</TableCell>
                        </TableRow>
                        ))
                    }
                </TableBody>
            </TblContainer>
            </>
    )
}
