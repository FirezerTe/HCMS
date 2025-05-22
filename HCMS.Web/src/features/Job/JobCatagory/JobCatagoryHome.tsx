import AddIcon from "@mui/icons-material/Add";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import { Box, Button, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { PageHeader } from "../../../components/PageHeader";
import { JobCatagoryDialog } from "./JobCatagoryDialog";
import { useNavigate } from "react-router-dom";
import { JobCatagoryList } from "./JobCatagoryList";
import { useGetAllJobCatagoryQuery } from "../../../app/api/HCMSApi";
import SetupMenu from "../SetupMenu";
import CategoryIcon from "@mui/icons-material/Category";

const Header = ({ text }: { text: string }) => (
  <Typography
    variant="h5"
    sx={{ lineHeight: 2.5, flex: 1, pt: 2, display: "block" }}
    color="textSecondary"
  >
    {text}
  </Typography>
);

export const JobCatagoryHome = () => {
  const [dialogOpened, setDialogOpened] = useState(false);
  const { data } = useGetAllJobCatagoryQuery();
  const navigate = useNavigate();
  return (
    <Box>
      <SetupMenu />
      <Box sx={{ display: "flex" }}>
        <PageHeader
          title={"Job Catagory"}
          icon={<CategoryIcon sx={{ fontSize: 15, color: "#1976d2" }} />}
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
          Add New Job Catagory
        </Button>
      </Box>

      {dialogOpened && (
        <JobCatagoryDialog
          onClose={() => {
            setDialogOpened(false);
          }}
        />
      )}
      <Box>
        <JobCatagoryList items={data} />
      </Box>
    </Box>
  );
};
