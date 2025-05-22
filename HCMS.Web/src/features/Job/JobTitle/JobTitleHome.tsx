import AddIcon from "@mui/icons-material/Add";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import { Box, Button, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { PageHeader } from "../../../components/PageHeader";
import { useNavigate } from "react-router-dom";
import { JobTitleDialog } from "./JobTitleDialog";
import { JobTitleList } from "./JobTitleList";
import { useGetAllJobTitleQuery } from "../../../app/api/HCMSApi";
import SetupMenu from "../SetupMenu";
import WorkIcon from "@mui/icons-material/Work";
const Header = ({ text }: { text: string }) => (
  <Typography
    variant="h5"
    sx={{ lineHeight: 2.5, flex: 1, pt: 2, display: "block" }}
    color="textSecondary"
  >
    {text}
  </Typography>
);

export const JobTitleHome = () => {
  const [dialogOpened, setDialogOpened] = useState(false);
  const { data } = useGetAllJobTitleQuery();
  const navigate = useNavigate();
  return (
    <Box>
      <SetupMenu />

      <Box sx={{ display: "flex" }}>
        <PageHeader
          title={"Job Title"}
          icon={<WorkIcon sx={{ fontSize: 15, color: "#1976d2" }} />}
        />
        <Box sx={{ flex: 1 }}></Box>
        <Button
          variant="outlined"
          startIcon={<AddIcon />}
          onClick={() => {
            setDialogOpened(true);
          }}
          sx={{
            color: "#fff", // Text color
            borderColor: "#1976d2", // Border color
            backgroundColor: "#1976d2",
            "&:hover": {
              backgroundColor: "#1976d2", // Background color on hover
              color: "#fff", // Text color on hover
              borderColor: "#1976d2", // Border color on hover
            },
          }}
        >
          Add New Job Title
        </Button>
      </Box>

      {dialogOpened && (
        <JobTitleDialog
          onClose={() => {
            setDialogOpened(false);
          }}
        />
      )}
      <Box>
        <JobTitleList items={data} />
      </Box>
    </Box>
  );
};
