import { Form, Formik } from "formik";
import { useCallback, useEffect, useState } from "react";
import { DialogHeader, FormSelectField, FormTextField } from "../../components";
import { useBusinessUnit } from "./useBusinessUnits";
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
  CreateBusinessUnitCommand,
  useCreateBusinessUnitMutation,
} from "../../app/api/HCMSApi";
import { useBusinessUnitType } from "./useBusinessUnitType";

const emptyBusinessUnitData = {
  businessUnitName: "",
  parentId: "",
} as any;
export const BusinessUnitDialog = ({ onClose }: { onClose: () => void }) => {
  const [businessUnitData, setBusinessUnit] =
    useState<CreateBusinessUnitCommand>();
  const [addBusinessUnit] = useCreateBusinessUnitMutation();
  const { businessUnitLookups } = useBusinessUnit();
  const { businessUnitTypeLookups } = useBusinessUnitType();

  useEffect(() => {
    setBusinessUnit({
      ...emptyBusinessUnitData,
      ...businessUnitData,
    });
  }, [emptyBusinessUnitData, businessUnitData]);

  const handleSubmit = useCallback(
    (values: CreateBusinessUnitCommand) => {
      addBusinessUnit({
        createBusinessUnitCommand: values,
      })
        .unwrap()
        .then(onClose);
    },
    [onClose, addBusinessUnit]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!businessUnitData && (
        <Formik
          initialValues={businessUnitData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Business Unit" onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <FormTextField
                    name="businessUnitName"
                    label="Business Unit Name"
                    type="text"
                  />
                </Grid>
                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormSelectField
                      name="businessUnitTypeId"
                      label="Business Unit Type "
                      type="number"
                      options={businessUnitTypeLookups}
                    />
                                        <FormSelectField
                      name="parentId"
                      label="Parent Business Unit"
                      type="number"
                      options={businessUnitLookups}
                    />
                  </Box>
                </Grid>

                <Grid item xs={12}>
                  <FormTextField
                    name="areaCode"
                    label="Business Unit Area Code"
                    type="text"
                  />
                </Grid>
                <Grid item xs={12}>
                <FormTextField
                    name="address"
                    label="Business Unit Address"
                    type="text"
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
