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
import {
  JobCatagory,
  useAddJobCatagoryMutation,
  useCreateBusinessUnitMutation,
} from "../../../app/api/HCMSApi";

const emptyjobCatagoryData = {
  name: "",
  description: "",
} as any;
export const JobCatagoryDialog = ({ onClose }: { onClose: () => void }) => {
  const [jobCatagoryData, setJobCatagory] = useState<JobCatagory>();
  const [addJobCatagory] = useAddJobCatagoryMutation();

  useEffect(() => {
    setJobCatagory({
      ...emptyjobCatagoryData,
      ...jobCatagoryData,
    });
  }, [emptyjobCatagoryData, jobCatagoryData]);

  const handleSubmit = useCallback(
    (values: JobCatagory) => {
      addJobCatagory({
        addJobCatagoryCommand: values,
      })
        .unwrap()
        .then(onClose);
    },
    [onClose, addJobCatagory]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!jobCatagoryData && (
        <Formik
          initialValues={jobCatagoryData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Add Job Catagory" onClose={onClose} />
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
                    label="Job Catagory Name"
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
