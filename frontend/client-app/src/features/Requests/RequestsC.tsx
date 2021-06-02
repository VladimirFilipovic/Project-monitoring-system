import { Formik, Form, Field, ErrorMessage } from "formik";
import React, { ChangeEvent, useState } from "react";
import {
  Button,
  Container,
  FormField,
  Header,
  Input,
  Label,
  Segment,
} from "semantic-ui-react";
import { Project, Request } from "../../models/ProjectModels";
import * as Yup from "yup";
import requestsService from "../../services/RequestsService";
import projectsService from "../../services/ProjectsService";
import { v4 as uuidv4 } from "uuid";
import _ from "lodash";
import { string } from "yup/lib/locale";

interface Props {
  request: Request | undefined;
  closeForm: () => void;
}

export default function RequestsC({ closeForm }: Props) {
  const initialState = {
    id: null,
    name: "",
    requestDate: new Date(),
    accepted: false,
    deleted: false,
    specification: null,
  };

  const [request, setRequest] = useState(initialState);

  const validationSchema = Yup.object({
    name: Yup.string().required("The project name is required"),
    requestDate: Yup.date()
      .required("The deadline date is required")
      .min(
        new Date(Date.now() + 46400000),
        "Request Date must be later than " + new Date().toUTCString()
      ),
    //specification: Yup.string().required('The specification is required')
  });

  function handleCreateRequest(requestCreate: Request) {
    const projId = uuidv4();
    requestCreate.id = projId;
    let fileSpec;
    let reqCopy = _.cloneDeep(requestCreate);
    //    getByteArray(requestCreate.specification).then((byteArray) => {
    //         reqCopy.specification = byteArray
    //         fileSpec = byteArray
    //         console.log('REQ SPEC')
    //     console.log(requestCreate)

    //    console.log('REQ SPEC2')
    //    console.log(reqCopy)

    //     let project: Project = {
    //         id:projId,
    //         name:requestCreate.name,
    //         isCompleted: false,
    //         deadline: requestCreate.requestDate,
    //         deleted: false
    //     }
    //     const projCopy = _.cloneDeep(project)
    //     reqCopy.project = projCopy
    //     const reqForProjCopy = _.cloneDeep(reqCopy)
    //     project.request = reqForProjCopy
    //     project.request.specification = fileSpec
    //     //     console.log(request.specification)
    //     //    // project.request.specification = convertFile(fileGlob)
    //     //     console.log('here it is theeeeeee projects')
    //     console.log(JSON.stringify(project.request))
    //     projectsService.create(JSON.stringify(project.request))
    //     .then(res => {
    //         console.log(res)
    //     })
    //     .catch(e => {
    //         console.log(e)
    //     })
    //    })

    let idCardBase64 = "";
    getBase64(requestCreate.specification, (result: any) => {
      reqCopy.specification = result;
      fileSpec = result;
      console.log("REQ SPEC");
      console.log(requestCreate);

      console.log("REQ SPEC2");
      console.log(reqCopy);

      let project: Project = {
        id: projId,
        name: requestCreate.name,
        isCompleted: false,
        deadline: requestCreate.requestDate,
        deleted: false,
      };
      const projCopy = _.cloneDeep(project);
      reqCopy.project = projCopy;
      const reqForProjCopy = _.cloneDeep(reqCopy);
      project.request = reqForProjCopy;
      project.request.specification = fileSpec;
      console.log(project);
      projectsService
        .create(project)
        .then((res) => {
          console.log(res);
        })
        .catch((e) => {
          console.log(e);
        });
      idCardBase64 = result;
    });
  }


  function convertFile(file: any): ArrayBuffer {
    const fileReader = new FileReader();
    console.log("fuke");
    console.log(file);
    if (fileReader) {
      console.log("fuke1");

      fileReader.readAsArrayBuffer(file);
      fileReader.onload = function () {
        const fileData = fileReader.result;
        if (typeof fileData !== "string" && fileData != null) {
          return fileData;
        }
      };
    }
    return new ArrayBuffer(10);
  }

  function getByteArray(file: any) {
    return new Promise(function (resolve, reject) {
      const fileReader = new FileReader();
      fileReader.readAsArrayBuffer(file);
      fileReader.onload = function () {
        if (
          typeof fileReader.result !== "string" &&
          fileReader.result != null
        ) {
          const array = new Uint8Array(fileReader.result);
          const fileByteArray = [];
          for (let i = 0; i < array.length; i++) {
            fileByteArray.push(array[i]);
          }
          resolve(array); // successful
        }
      };
      fileReader.onerror = reject; // call reject if error
    });
  }

  function getBase64(file: any, cb: any) {
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      cb(reader.result);
    };
    reader.onerror = function (error) {
      console.log("Error: ", error);
    };
  }

  function changeHandleFile(event: any) {
    setRequest({ ...request, specification: event.target.files[0] });
  }

  return (
    <Container style={{ marginTop: "7em" }}>
      <Segment clearing>
        <Header content="Request details" sub color="teal" />
        <Formik
          validationSchema={validationSchema}
          enableReinitialize
          initialValues={request}
          onSubmit={handleCreateRequest}
        >
          {({ handleSubmit, resetForm }) => (
            <Form
              className="ui form"
              onSubmit={handleSubmit}
              autoComplete="off"
            >
              <FormField>
                <Field placeholder="Name" name="name" />
                <ErrorMessage
                  name="name"
                  render={(error) => (
                    <Label basic color="red" content={error} />
                  )}
                />
              </FormField>
              <FormField>
                <Field
                  type="date"
                  placeholder="Deadline date"
                  name="requestDate"
                />
                <ErrorMessage
                  name="requestDate"
                  render={(error) => (
                    <Label basic color="red" content={error} />
                  )}
                />
              </FormField>
              <FormField>
                <Input
                  onChange={changeHandleFile}
                  type="file"
                  name="specification"
                />
              </FormField>
              <Button floated="right" positive type="submit" content="Submit" />
              <Button
                floated="right"
                type="button"
                onClick={() => resetForm()}
                content="Clear"
              />
            </Form>
          )}
        </Formik>
      </Segment>
    </Container>
  );
}
