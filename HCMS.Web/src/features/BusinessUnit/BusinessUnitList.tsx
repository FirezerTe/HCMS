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
import { BusinessUnitDto } from "../../app/api";

interface BusinessUnitListProps {
  items?: BusinessUnitDto[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const BusinessUnitList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: BusinessUnitListProps) => {
  const [selectedBusinessUnit, setSelectedBusinessUnit] =
    useState<BusinessUnitDto>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell sx={{fontWeight: 'bold'}}>Name</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Parent BusinessUnit</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}> BusinessUnit ID</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}> BusinessUnit Type</TableCell>
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
                      {item.name}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.parentBusinessUnit}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.businessUnitID}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.type}
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
