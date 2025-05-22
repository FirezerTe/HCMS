import {
  Box,
  Button,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { Fragment, useState } from "react";
import { EmployeeDto } from "../../app/api/HCMSApi";

interface EmployeeListProps {
  items?: EmployeeDto[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const EmployeeList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: EmployeeListProps) => {
  const [selectedEmployee, setSelectedEmployee] = useState<EmployeeDto>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
              <TableCell sx={{fontWeight: 'bold'}}>Employee ID</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Name</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Business Unit</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Job Title</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Gender</TableCell>
                 <TableCell sx={{fontWeight: 'bold'}}>BirthDate</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Employement Date</TableCell> 
                <TableCell sx={{fontWeight: 'bold'}}>Martial Status</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(items || []).map((item) => (
                <Fragment key={item.id}>
                  <TableRow
                    hover={false}
                    key={item.id}
                    sx={
                      !hideWorkflowComment
                        ? {
                            cursor: "pointer",
                            "& > *": { borderBottom: "unset" },
                          }
                        : {}
                    }
                  >
                          <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.employeeId}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.employeeName}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.businessUnit}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.jobTitle}
                    </TableCell>
              
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.gender}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.birthDate}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.employementDate}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.martialStatus}
                    </TableCell>
                  </TableRow>
                </Fragment>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </Box>
  );
};
