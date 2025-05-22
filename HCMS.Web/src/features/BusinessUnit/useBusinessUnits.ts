import { useMemo } from "react";
import { SelectOption } from "../../types";
import { useGetAllLookupsQuery } from "../../app/api/HCMSApi";

export const useBusinessUnit = () => {
  const { data } = useGetAllLookupsQuery();

  const { businessUnitLookups, branches } = useMemo(() => {
    const businessUnitLookups = (data?.businessUnits || []).map<SelectOption>(
      ({ id, name, businessUnitID }) => ({
        label: name || businessUnitID || "",
        value: id,
      })
    );

    return { businessUnitLookups, branches: data?.businessUnits || [] };
  }, [data]);
  return {
    branches,
    businessUnitLookups,
  };
};
