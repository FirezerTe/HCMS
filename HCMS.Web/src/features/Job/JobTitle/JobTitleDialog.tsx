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
import { JobTitleDto, useAddJobTitleMutation } from "../../../app/api/HCMSApi";
import { useJobCatagory } from "../JobCatagory/useJobCatagories";
import { useJobGrade } from "../JobGrade/useJobGrade";

const emptyjobTitleData = {
  name: "",
  description: "",
} as any;
export const JobTitleDialog = ({ onClose }: { onClose: () => void }) => {
  const [jobTitleData, setJobTitle] = useState<JobTitleDto>();
  const [addJobTitle] = useAddJobTitleMutation();
  const { JobCatagoryLookups } = useJobCatagory();
  const { JobGradesLookups } = useJobGrade();
  useEffect(() => {
    setJobTitle({
      ...emptyjobTitleData,
      ...jobTitleData,
    });
  }, [emptyjobTitleData, jobTitleData]);

  const handleSubmit = useCallback(
    (values: JobTitleDto) => {
      addJobTitle({
        addJobTitleCommand: values,
      })
        .unwrap()
        .then(onClose);
    },
    [onClose, addJobTitle]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!jobTitleData && (
        <Formik
          initialValues={jobTitleData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Add Job Title" onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <FormTextField
                    name="title"
                    label="Job Title Name"
                    type="text"
                  />
                </Grid>
                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormSelectField
                      name="jobCatagoryId"
                      label="Job Catagory"
                      type="number"
                      options={JobCatagoryLookups}
                    />
                  </Box>
                </Grid>
                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormSelectField
                      name="jobGradeId"
                      label="Job Grade"
                      type="number"
                      options={JobGradesLookups}
                    />
                  </Box>
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
