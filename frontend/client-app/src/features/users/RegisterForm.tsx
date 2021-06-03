import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, FormField, Header, Input, Label } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import * as Yup from 'yup';
import { useStore } from '../../stores/store';
import ValidationErrors from '../errors/ValidationErrors';

export default observer(function RegisterForm() {
    const {userStore} = useStore();
    return (
        <Formik
            initialValues={{UserName: '', Email: '', Password: '', CompanyName:'',Pib:'', error:null}}
            onSubmit={(values, {setErrors}) => userStore.register(values).catch(error => 
                setErrors({error: error.errors}))}
            validationSchema={Yup.object({
                Username: Yup.string().required(),
                Email: Yup.string().required().email(),
                Password: Yup.string().required(),
                CompanyName: Yup.string().required(),
                Pib: Yup.string()
                .required()
                .matches(/^[0-9]+$/, "Must be only digits")
                .min(8, 'Must be exactly 5 digits')
                .max(8, 'Must be exactly 5 digits')

            })}
        >
            {({handleSubmit, isSubmitting, errors, isValid, dirty}) => (
                <Form className='ui form error' onSubmit={handleSubmit} autoComplete='off'>
                    <Header as='h2' content='Sign up to ITSolutions' color='teal' textAlign='center' />
                    <MyTextInput name='Username' placeholder='Username' />
                    <MyTextInput name='CompanyName' placeholder='Company Name' />
                    <MyTextInput name='Pib' placeholder='Pib' />
                    <MyTextInput name='Email' placeholder='Email' />
                    <MyTextInput name='Password' placeholder='Password' type='password' />
                    <ErrorMessage 
                        name='error' render={() => 
                        <ValidationErrors errors={errors.error}/>}
                    />
                    {/* <FormField>
                    <Input name='Username' placeholder='Username' />
                    </FormField>
                    <FormField>
                    <Input name='email' placeholder='Email' />
                        </FormField>
                        <FormField>
                        <Input name='password' placeholder='Password' type='password' />
                        </FormField>
                        <FormField>
                        <Input name='CompanyName' placeholder='CompanyName' />
                        </FormField>
                        <FormField>
                        <Input name='Pib' placeholder='Pib' />
                        </FormField>
                        <ErrorMessage 
                        name='error' render={() => 
                        <Label style={{marginBottom: 10}} basic color='red' content={errors.error}/>}
                    /> */}
                      <Button disabled={!isValid || !dirty} 
                       positive content='Register' type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})