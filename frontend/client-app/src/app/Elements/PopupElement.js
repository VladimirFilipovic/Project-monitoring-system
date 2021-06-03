import { Dialog, DialogContent, DialogTitle, makeStyles, Typography, Button } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import React from 'react'

const useStyles = makeStyles(theme => ({
    dialogWrapper: {
        padding: theme.spacing(2)
    },
    dialogTitle:{
        padding:'0px'
    }
    
}))

export default function Popup(props) {
    const {title, children, openPopup, setOpenPopup} = props;
    const classes = useStyles();

    return (
        <Dialog open={openPopup} maxWidth='md' classes={{ paper: classes.dialogWrapper}}>
            <DialogTitle className={classes.dialogTitle}>
                <div style={{display:'flex'}}>
                    <Button
                    text="X"
                    color="secondary"
                    onClick={() => {setOpenPopup(false)}}>
                         <CloseIcon fontSize="small"/>
                    </Button>
                </div>
            </DialogTitle>
            <DialogContent dividers>
                {children}
            </DialogContent>
        </Dialog>
    )
}
