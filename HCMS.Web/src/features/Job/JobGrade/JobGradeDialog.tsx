import { Form, Formik } from "formik";
import { useCallback, useEffect, useState } from "react";
import {
  DialogHeader,
  FormSelectField,
  FormTextField,
} from "../../../components";
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  Grid,
} from "@mui/material";
import { JobGrade, useAddJobGradeMutation } from "../../../app/api/HCMSApi";

const emptyjobGradeData = {
  name: "",
  description: "",
} as any;
export const JobGradeDialog = ({ onClose }: { onClose: () => void }) => {
  const [jobGradeData, setJobGrade] = useState<JobGrade>();
  const [addJobGrade] = useAddJobGradeMutation();

  useEffect(() => {
    setJobGrade({
      ...emptyjobGradeData,
      ...jobGradeData,
    });
  }, [emptyjobGradeData, jobGradeData]);

  const handleSubmit = useCallback(
    (values: JobGrade) => {
      addJobGrade({
        addJobGradeCommand: values,
      })
        .unwrap()
        .then(onClose);
    },
    [onClose, addJobGrade]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!jobGradeData && (
        <Formik
          initialValues={jobGradeData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Add Job Grade" onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <FormTextField
                    name="name"
                    label="Job Grade Name"
                    type="text"
                  />
                </Grid>

                <Grid item xs={12}>
                  <FormTextField
                    name="description"
                    type="text"
                    placeholder="Description"
                    label="Description"
                    fullWidth
                    multiline
                    minRows={5}
                    variant="outlined"
                  />
                </Grid>
              </Grid>
            </DialogContent>
            <DialogActions sx={{ p: 2 }}>
              <Button onClick={onClose}>Cancel</Button>
              <Button color="primary" variant="outlined" type="submit">
                Save
              </Button>
            </DialogActions>
          </Form>
        </Formik>
      )}
    </Dialog>
  );
};
