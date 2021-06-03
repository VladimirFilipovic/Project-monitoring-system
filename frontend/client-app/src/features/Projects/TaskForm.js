import React, {useState, useEffect} from 'react'
import {TextareaAutosize, Grid, Paper, Typography, Select, FormControl, Input, MenuItem, InputLabel, Button} from '@material-ui/core'
import {UseForm, Form} from '../../app/common/form/UseForm'
import TextField from '@material-ui/core/TextField';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import EmployeeService from '../../services/EmployeeService';
import { CollectionsBookmarkRounded } from '@material-ui/icons';


const initialFieldValues = {
    id: '',
    description: '',
    name: '',
    employees: [],
    projectId: ''
}

const initialOptions = [
    {id:0, userName:""},
]


function getStyles(name, personName, theme) {
    return {
      fontWeight:
        personName.indexOf(name) === -1
          ? theme.typography.fontWeightRegular
          : theme.typography.fontWeightMedium,
    };
  }

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

export default function TaskForm(props) {
    const {handleTaskSubmit, setOpenPopup} = props
    const {values, setValues, handleInputChange, errors, setErrors} = UseForm(initialFieldValues);
    const [personName, setPersonName] = React.useState([]); //niz id-jeva radnika
    const [options, setOptions] = useState(initialOptions)
    const theme = useTheme();

    const handleEmployeeSelection = () => {

    }

    const handleChange = (event) => {
        console.log(event.target.value);
        setPersonName(event.target.value);
        setValues({
            ...values,
            employees: event.target.value
        }
        )
      };

    useEffect(() => {
        EmployeeService.getAll()
        .then((response) => {
        setOptions(response.data);
        })
        .catch((e) => {
        console.log(e);
        });
    }, [])

    const handleSubmit = e => {
        console.log('handleSubmit')
        e.preventDefault()
        handleTaskSubmit(values)
    }

    return (
        <Paper style={{padding:"3em"}}>
        <Form onSubmit={handleSubmit}>
            <Grid container justify="center" spacing={3}>
               <TextField id="standard-basic" label="Title" style={{width:'100%', marginBottom:'-0.5em'}}
               onChange={handleInputChange}
               name="name"
               value={values.name}/>
                <Grid item sm={12} container justify="center">
                <TextareaAutosize aria-label="minimum height"
                id="description" 
                rowsMin={5}
                style={{width:'100%'}}
                placeholder="Description"
                name="description"
                value={values.description} 
                onChange={handleInputChange}
                error={errors.description}
                style={{borderRadius: '0.5em', padding: '1em', marginTop: '1em', width:'100%'}}/>
                </Grid>
                <Grid container >
                <Grid item sm={6} container justify="flex-start">
                <FormControl >
                    <InputLabel id="demo-mutiple-name-label">Employees</InputLabel>
                    <Select
                    labelId="demo-mutiple-name-label"
                    id="demo-mutiple-name"
                    multiple
                    value={personName}
                    onChange={handleChange}
                    input={<Input />}
                    MenuProps={MenuProps}
                    >
                    {options.map((option) => (
                        <MenuItem key={option.id} value={option.id} style={getStyles(option.userName, personName, theme)}>
                        {option.userName}
                        </MenuItem>
                    ))}
                    </Select>
                </FormControl>
                </Grid>
                <Grid container alignItems="center" justify="flex-end">
                    <Grid item sm={3} container justify="flex-end"
                    style={{marginRight: "0.5em"}}
                    >
                            <Button
                            style={{ marginTop: "2em", width: "100%"}}
                            variant="contained"
                            color="primary"
                            size="large"
                            text="create"
                            type="submit">Create</Button>
                    </Grid>
                </Grid>
                </Grid>
            </Grid>
        </Form>
        </Paper>
    )
}
