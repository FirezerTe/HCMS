import { useMemo } from "react";
import { SelectOption } from "../../../types";
import { useGetAllLookupsQuery } from "../../../app/api/HCMSApi";

export const useJobGrade = () => {
  const { data } = useGetAllLookupsQuery();

  const { JobGradesLookups, jobGrades } = useMemo(() => {
    const JobGradesLookups = (data?.jobGrades || []).map<SelectOption>(
      ({ value, name, description }) => ({
        label: name || description || "",
        value: value,
      })
    );

    return { JobGradesLookups, jobGrades: data?.jobGrades || [] };
  }, [data]);
  return {
    jobGrades,
    JobGradesLookups,
  };
};
