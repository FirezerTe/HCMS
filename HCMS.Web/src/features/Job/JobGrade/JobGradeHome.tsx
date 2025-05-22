import AddIcon from "@mui/icons-material/Add";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import { Box, Button, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { PageHeader } from "../../../components/PageHeader";
import { useNavigate } from "react-router-dom";
import { JobGradeDialog } from "./JobGradeDialog";
import { JobGradeList } from "./JobGradeList";
import { useGetAllJobGradeQuery } from "../../../app/api/HCMSApi";
import SetupMenu from "../SetupMenu";
import GradeIcon from "@mui/icons-material/Grade";

const Header = ({ text }: { text: string }) => (
  <Typography
    variant="h5"
    sx={{ lineHeight: 2.5, flex: 1, pt: 2, display: "block" }}
    color="textSecondary"
  >
    {text}
  </Typography>
);

export const JobGradeHome = () => {
  const [dialogOpened, setDialogOpened] = useState(false);
  const { data } = useGetAllJobGradeQuery();
  const navigate = useNavigate();
  return (
    <Box>
      <SetupMenu />
      <Box sx={{ display: "flex" }}>
        <PageHeader
          title={"Job Grade"}
          icon={<GradeIcon sx={{ fontSize: 15, color: "#1976d2" }} />}
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
          Add New Job Grade
        </Button>
      </Box>

      {dialogOpened && (
        <JobGradeDialog
          onClose={() => {
            setDialogOpened(false);
          }}
        />
      )}
      <Box>
        <JobGradeList items={data} />
      </Box>
    </Box>
  );
};
