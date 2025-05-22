import { Form, Formik } from "formik";
import { useCallback, useEffect, useState } from "react";
import { DialogHeader, FormSelectField, FormTextField } from "../../components";
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  Grid,
} from "@mui/material";
import {
  BusinessUnitDto,
  CreateEmployeeProfileCommand,
  EmployeeDto,
  useCreateBusinessUnitMutation,
  useCreateEmployeeProfileMutation,
} from "../../app/api/HCMSApi";
import { useBusinessUnit } from "../BusinessUnit/useBusinessUnits";
import { useJobTitle } from "../Job/JobTitle/useJobTitle";
import { enums } from "../../app/api";
import dayjs from "dayjs";
import { removeEmptyFields } from "../../utils";

const emptyEmployeeData = {
  employeeName: "",
  employeeID: "",
} as any;
export const EmployeeDialog = ({ onClose }: { onClose: () => void }) => {
  // const [open, setOpen] = useState(false);
  const [EmployeeData, setEmployee] = useState<CreateEmployeeProfileCommand>();
  const [addEmployee] = useCreateEmployeeProfileMutation();
  const { businessUnitLookups } = useBusinessUnit();
  const { jobTitlesLookups } = useJobTitle();
  useEffect(() => {
    setEmployee({
      ...emptyEmployeeData,
      ...EmployeeData,
    });
  }, [emptyEmployeeData, EmployeeData]);

  const handleSubmit = useCallback(
    (values: CreateEmployeeProfileCommand) => {
      const birthDate = dayjs(values.birthDate).format("YYYY-MM-DD");
      const employementDate = values.employementDate && dayjs(values.employementDate).format("YYYY-MM-DD");

      const payload = removeEmptyFields({ ...values, birthDate, employementDate });
      addEmployee({
        createEmployeeProfileCommand: payload,
      }) 
        .unwrap()
        .then(onClose);
    },
    [onClose, addEmployee]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!EmployeeData && (
        <Formik
          initialValues={EmployeeData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Add Employee" onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 1 }}>
                    <FormTextField
                      name="name"
                      label="Employee Full Name"
                      type="text"
                    />
                    <FormTextField
                      name="birthDate"
                      label="Birth Date"
                      type="date"
                    />
                  </Box>
                </Grid>
                <Grid item xs={24}>
                  <Box sx={{ display: "flex", gap: 1 }}>
                    <FormSelectField
                      name="gender"
                      label="Gender"
                      options={[
                        {
                          label: "Male",
                          value: enums.Gender.Male,
                        },
                        {
                          label: "Female",
                          value: enums.Gender.Female,
                        },
                      ]}
                    />

                    <FormSelectField
                      name="martialStatus"
                      label="Martial Status"
                      options={[
                        {
                          label: "Single",
                          value: enums.MartialStatus.Single,
                        },
                        {
                          label: "Married",
                          value: enums.MartialStatus.Married,
                        },
                        {
                          label: "Widowed",
                          value: enums.MartialStatus.Divorced,
                        },
                        {
                          label: "Widowed",
                          value: enums.MartialStatus.Widowed,
                        },
                      ]}
                    />
                  </Box>
                </Grid>
                <Grid item xs={12}>
                  <Grid item xs={12}>
                    <Box sx={{ display: "flex", gap: 2 }}>
                      <FormSelectField
                        name="businessUnitId"
                        label="Business Unit"
                        type="number"
                        options={businessUnitLookups}
                      />
                      <FormSelectField
                        name="jobTitleId"
                        label="Job Title"
                        type="number"
                        options={jobTitlesLookups}
                      />
                    </Box>
                  </Grid>

                  <Grid item xs={12}>
                    <FormTextField
                      name="employementDate"
                      label="Employment Date"
                      type="date"
                    />
                  </Grid>
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
