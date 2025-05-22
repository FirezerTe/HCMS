import { Box, Button, Typography, Grid, Paper } from "@mui/material";
import { useNavigate } from "react-router-dom";
import BusinessCenterIcon from "@mui/icons-material/BusinessCenter";
import WorkIcon from "@mui/icons-material/Work";
import CategoryIcon from "@mui/icons-material/Category";
import GradeIcon from "@mui/icons-material/Grade";

const SetupMenu = () => {
  const navigate = useNavigate();

  return (
    <Box
      sx={{
        padding: 2,
        backgroundColor: "##1976d2",
        height: "12vh",
        display: "flex",
        alignItems: "flex-start",
        justifyContent: "center",
      }}
    >
      <Grid container spacing={6}>
        <Grid item xs={6} sm={6} md={3}>
          <Paper
            onClick={() => {
              navigate("/businessunit");
            }}
            elevation={1}
            sx={{ padding: 1, borderRadius: "16px", textAlign: "center" }}
          >
            <BusinessCenterIcon sx={{ fontSize: 15, color: "#1976d2" }} />
            <Typography variant="h6" sx={{ mt: 1 }}>
              Business Unit
            </Typography>
          </Paper>
        </Grid>
        <Grid item xs={6} sm={6} md={3}>
          <Paper
            onClick={() => {
              navigate("/jobtitle");
            }}
            elevation={3}
            sx={{ padding: 1, borderRadius: "16px", textAlign: "center" }}
          >
            <WorkIcon sx={{ fontSize: 15, color: "#FA500" }} />
            <Typography variant="h6" sx={{ mt: 1 }}>
              Job Title
            </Typography>
          </Paper>
        </Grid>
        <Grid item xs={6} sm={6} md={3}>
          <Paper
            onClick={() => {
              navigate("/jobcatagory");
            }}
            elevation={3}
            sx={{ padding: 1, borderRadius: "16px", textAlign: "center" }}
          >
            <CategoryIcon sx={{ fontSize: 15, color: "#1976d2" }} />
            <Typography variant="h6" sx={{ mt: 1 }}>
              Job Category
            </Typography>
          </Paper>
        </Grid>
        <Grid item xs={6} sm={6} md={3}>
          <Paper
            onClick={() => {
              navigate("/jobgrade");
            }}
            elevation={3}
            sx={{ padding: 1, borderRadius: "16px", textAlign: "center" }}
          >
            <GradeIcon sx={{ fontSize: 15, color: "#1976d2" }} />
            <Typography variant="h6" sx={{ mt: 1 }}>
              Job Grade
            </Typography>
          </Paper>
        </Grid>
      </Grid>
    </Box>
  );
};

export default SetupMenu;
