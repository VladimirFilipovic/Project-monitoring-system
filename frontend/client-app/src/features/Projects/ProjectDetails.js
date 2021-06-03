import React, {useState, useEffect} from 'react'
import {Grid, Typography, Paper, Divider, Button} from '@material-ui/core'
import Popup from '../../app/Elements/PopupElement'
import TasksService from '../../services/TasksService';
import ProjectsServices from '../../services/ProjectsService';

import DateRangeTwoToneIcon from '@material-ui/icons/DateRangeTwoTone';
import PersonPinTwoToneIcon from '@material-ui/icons/PersonPinTwoTone';
import DemosTable from './DemosTable'
import DocumentationTable from './DocumentationTable'
import UpdateTwoToneIcon from '@material-ui/icons/UpdateTwoTone';
import PaymentsTable from './PaymentsTable';
import TasksTable from './TasksTable'
import { observer } from 'mobx-react-lite';
import TaskForm from './TaskForm'
import {v4 as uuidv4} from 'uuid'
import { useStore } from '../../stores/store';


export default observer (function ProjectDetails(props) {

    const [project, setProject] = useState();
    const [openPopup, setOpenPopup] = useState(false);
    const { userStore: { user, logout, getUser} } = useStore();
    const { commonStore: { token} } = useStore();

    useEffect(() => {
        let id = props.match.params['id'];
        ProjectsServices.get(id)
        .then(res => {
            setProject(res.data)
        })
        .catch(err => {
            console.log(err)
        })
    }, [])

    if(project == null){
        return (<p>Loading</p>)
    }

    const handleTaskSubmit = (task) => {
        console.log('handleTaskSubmit')
        setOpenPopup(false);
        task.id = uuidv4();
        task.projectId = project.id;
        TasksService.create(task)
        .then(res => {

        })
        .catch(err => {

        })

    }

    const handleNewTaskClick = () => {
        setOpenPopup(true);
    }

    return (
        <>
        <Grid container justify="center" style={{padding:"3em"}}>
        <Paper style={{padding:"3em"}}>
        <Grid container >
            <Grid item sm={12}>
            <Typography variant="h6" >
                {project.name}
            </Typography>
            <Divider />
            </Grid>
            <Grid container direction="row" alignItems="center" style={{marginTop:'0.5em'}}>
                <Grid item>
                <DateRangeTwoToneIcon/>
                </Grid>
                <Grid item>
                 Deadline:
                </Grid>
                <Grid item>
                {new Date(project.deadline).toUTCString()}
                </Grid>
            </Grid>
            
            <Grid container direction="row" alignItems="center">
                
                <Grid item>
                <UpdateTwoToneIcon/> 
                </Grid>
                <Grid item>
                 Completed:
                </Grid>
                <Grid item>
                {project.isCompleted ? " Completed" : " In-progress"}
                </Grid>
            </Grid>
            <Grid container direction="row" alignItems="center">
                
                <Grid item>
                <PersonPinTwoToneIcon/> 
                </Grid>
                <Grid item>
                 Accepted:
                </Grid>
                <Grid item>
                {project.isCompleted ? (project.request.accepted? " Project Accepted": " Project Rejected"):(project.request.accepted? " Project Accepted": " Waiting for review")}
                </Grid>
            </Grid>
            <Divider />

            <Typography variant="subtitle1" style={{marginTop:'2em'}}>
                Demos:
            </Typography>
            {project.demos && <DemosTable demos={project.demos}></DemosTable>}
            <Typography variant="subtitle1" style={{marginTop:'2em'}}>
                Documentation:
            </Typography>
            {project.documentation && <DocumentationTable documentation={project.documentation}></DocumentationTable>}
            {user?.username==="admin" && <>
            <Typography variant="subtitle1" style={{marginTop:'2em'}}>
                Payments:
            </Typography>
            {project.payments && <PaymentsTable payments={project.payments}></PaymentsTable>}
            <Grid container justify="space-between"> 
                <Grid item sm={9}>
                <Typography variant="subtitle1" style={{marginTop:'2em'}}>
                    Tasks:
                </Typography>
                </Grid>
                <Grid item sm={2} container alignItems="flex-end" justify="flex-end">
                <Button variant="outlined" color="primary" onClick={handleNewTaskClick}>New task</Button>
                </Grid>
           </Grid>
            {project.tasks && <TasksTable tasks={project.tasks}></TasksTable>}
            </>}
        </Grid>
        </Paper>
        </Grid>
        <Popup 
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}>
            <TaskForm
            handleTaskSubmit={handleTaskSubmit}
            setOpenPopup={setOpenPopup}/>
        </Popup>
        </>
    )
})
