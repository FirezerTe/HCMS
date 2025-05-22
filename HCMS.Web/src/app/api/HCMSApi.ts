import { emptySplitApi as api } from "./emptySplitApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    login: build.mutation<LoginApiResponse, LoginApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/login`,
        method: "POST",
        body: queryArg.userLogin,
        params: { returnUrl: queryArg.returnUrl },
      }),
    }),
    registerUser: build.mutation<RegisterUserApiResponse, RegisterUserApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/RegisterUser`,
        method: "POST",
        body: queryArg.userRegisterDto,
      }),
    }),
    verificationCode: build.mutation<
      VerificationCodeApiResponse,
      VerificationCodeApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Authentication/verification-code`,
        method: "POST",
        body: queryArg.verificationCode,
      }),
    }),
    getAllBusinessUnits: build.query<
      GetAllBusinessUnitsApiResponse,
      GetAllBusinessUnitsApiArg
    >({
      query: () => ({ url: `/api/BusinessUnit/all` }),
    }),
    createBusinessUnit: build.mutation<
      CreateBusinessUnitApiResponse,
      CreateBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/CreateBusinessUnit`,
        method: "POST",
        body: queryArg.createBusinessUnitCommand,
      }),
    }),
    createEmployeeProfile: build.mutation<
      CreateEmployeeProfileApiResponse,
      CreateEmployeeProfileApiArg
    >({
      query: (queryArg) => ({
        url: `/api/EmployeeProfile/add`,
        method: "POST",
        body: queryArg.createEmployeeProfileCommand,
      }),
    }),
    getAllEmployees: build.query<
      GetAllEmployeesApiResponse,
      GetAllEmployeesApiArg
    >({
      query: () => ({ url: `/api/EmployeeProfile/all` }),
    }),
    addJobCatagory: build.mutation<
      AddJobCatagoryApiResponse,
      AddJobCatagoryApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Job/AddJobCatagory`,
        method: "POST",
        body: queryArg.addJobCatagoryCommand,
      }),
    }),
    addJobGrade: build.mutation<AddJobGradeApiResponse, AddJobGradeApiArg>({
      query: (queryArg) => ({
        url: `/api/Job/AddJobGrade`,
        method: "POST",
        body: queryArg.addJobGradeCommand,
      }),
    }),
    addJobTitle: build.mutation<AddJobTitleApiResponse, AddJobTitleApiArg>({
      query: (queryArg) => ({
        url: `/api/Job/AddJobTitle`,
        method: "POST",
        body: queryArg.addJobTitleCommand,
      }),
    }),
    getAllJobCatagory: build.query<
      GetAllJobCatagoryApiResponse,
      GetAllJobCatagoryApiArg
    >({
      query: () => ({ url: `/api/Job/allJobCatagory` }),
    }),
    getAllJobGrade: build.query<
      GetAllJobGradeApiResponse,
      GetAllJobGradeApiArg
    >({
      query: () => ({ url: `/api/Job/allJobGrades` }),
    }),
    getAllJobTitle: build.query<
      GetAllJobTitleApiResponse,
      GetAllJobTitleApiArg
    >({
      query: () => ({ url: `/api/Job/allJobTitles` }),
    }),
    getAllLookups: build.query<GetAllLookupsApiResponse, GetAllLookupsApiArg>({
      query: () => ({ url: `/api/Lookup/all` }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as HCMSApi };
export type LoginApiResponse = /** status 200 Success */ LoginRes;
export type LoginApiArg = {
  returnUrl?: string;
  userLogin: UserLogin;
};
export type RegisterUserApiResponse = unknown;
export type RegisterUserApiArg = {
  userRegisterDto: UserRegisterDto;
};
export type VerificationCodeApiResponse = /** status 200 Success */ void;
export type VerificationCodeApiArg = {
  verificationCode: VerificationCode;
};
export type GetAllBusinessUnitsApiResponse =
  /** status 200 Success */ BusinessUnitDto[];
export type GetAllBusinessUnitsApiArg = void;
export type CreateBusinessUnitApiResponse = /** status 200 Success */ number;
export type CreateBusinessUnitApiArg = {
  createBusinessUnitCommand: CreateBusinessUnitCommand;
};
export type CreateEmployeeProfileApiResponse = /** status 200 Success */ number;
export type CreateEmployeeProfileApiArg = {
  createEmployeeProfileCommand: CreateEmployeeProfileCommand;
};
export type GetAllEmployeesApiResponse =
  /** status 200 Success */ EmployeeDto[];
export type GetAllEmployeesApiArg = void;
export type AddJobCatagoryApiResponse = /** status 200 Success */ number;
export type AddJobCatagoryApiArg = {
  addJobCatagoryCommand: AddJobCatagoryCommand;
};
export type AddJobGradeApiResponse = /** status 200 Success */ string;
export type AddJobGradeApiArg = {
  addJobGradeCommand: AddJobGradeCommand;
};
export type AddJobTitleApiResponse = /** status 200 Success */ number;
export type AddJobTitleApiArg = {
  addJobTitleCommand: AddJobTitleCommand;
};
export type GetAllJobCatagoryApiResponse =
  /** status 200 Success */ JobCatagory[];
export type GetAllJobCatagoryApiArg = void;
export type GetAllJobGradeApiResponse = /** status 200 Success */ JobGrade[];
export type GetAllJobGradeApiArg = void;
export type GetAllJobTitleApiResponse = /** status 200 Success */ JobTitleDto[];
export type GetAllJobTitleApiArg = void;
export type GetAllLookupsApiResponse = /** status 200 Success */ LookupDto;
export type GetAllLookupsApiArg = void;
export type LoginRes = {
  isSuccess?: boolean;
  needVerification?: boolean | null;
  isLockedOut?: boolean | null;
};
export type ProblemDetails = {
  type?: string | null;
  title?: string | null;
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
};
export type UserLogin = {
  userEmail?: string | null;
  password?: string | null;
};
export type UserRegisterDto = {
  email?: string | null;
  firstName?: string | null;
  middleName?: string | null;
  lastName?: string | null;
  branchId?: number;
  roles?: string[] | null;
};
export type VerificationCode = {
  code?: string | null;
};
export type BusinessUnitDto = {
  id?: number;
  businessUnitID?: string | null;
  name?: string | null;
  parentBusinessUnit?: string | null;
  parentBusinessUnitID?: number;
  type?: string | null;
  areaCode?: string | null;
  addres?: string | null;
};
export type CreateBusinessUnitCommand = {
  businessUnitName?: string | null;
  parentId?: number;
  businessUnitTypeId?: number;
  areaCode?: string | null;
  address?: string | null;
};
export type Gender = 1 | 2;
export type MartialStatus = 1 | 2 | 3 | 4;
export type CreateEmployeeProfileCommand = {
  name?: string | null;
  businessUnitID?: number;
  jobTitleId?: number;
  birthDate?: string;
  employementDate?: string;
  gender?: Gender;
  martialStatus?: MartialStatus;
};
export type EmployeeDto = {
  id?: number;
  employeeId?: number;
  employeeName?: string | null;
  businessUnit?: string | null;
  jobTitle?: string | null;
  birthDate?: string;
  employementDate?: string;
  gender?: Gender;
  martialStatus?: MartialStatus;
};
export type AddJobCatagoryCommand = {
  name?: string | null;
  description?: string | null;
};
export type AddJobGradeCommand = {
  name?: string | null;
  description?: string | null;
};
export type AddJobTitleCommand = {
  id?: number;
  title?: string | null;
  description?: string | null;
  jobCatagoryId?: number;
  jobGradeId?: number;
};
export type JobCatagoryEnum = 1 | 2 | 3 | 4;
export type JobCatagory = {
  value?: JobCatagoryEnum;
  name?: string | null;
  description?: string | null;
};
export type JobGradeEnum = 1 | 2 | 3 | 4 | 5;
export type JobGrade = {
  value?: JobGradeEnum;
  name?: string | null;
  description?: string | null;
};
export type JobTitleDto = {
  id?: number;
  title?: string | null;
  description?: string | null;
  jobCatagory?: string | null;
  jobGrade?: string | null;
};
export type BusinessUnitTypeEnum = 1 | 2 | 3 | 4 | 5;
export type BusinessUnitType = {
  value?: BusinessUnitTypeEnum;
  name?: string | null;
  description?: string | null;
};
export type LookupDto = {
  jobTitles?: JobTitleDto[] | null;
  jobCatagories?: JobCatagory[] | null;
  jobGrades?: JobGrade[] | null;
  businessUnits?: BusinessUnitDto[] | null;
  businessUnitTypes?: BusinessUnitType[] | null;
};
export const {
  useLoginMutation,
  useRegisterUserMutation,
  useVerificationCodeMutation,
  useGetAllBusinessUnitsQuery,
  useLazyGetAllBusinessUnitsQuery,
  useCreateBusinessUnitMutation,
  useCreateEmployeeProfileMutation,
  useGetAllEmployeesQuery,
  useLazyGetAllEmployeesQuery,
  useAddJobCatagoryMutation,
  useAddJobGradeMutation,
  useAddJobTitleMutation,
  useGetAllJobCatagoryQuery,
  useLazyGetAllJobCatagoryQuery,
  useGetAllJobGradeQuery,
  useLazyGetAllJobGradeQuery,
  useGetAllJobTitleQuery,
  useLazyGetAllJobTitleQuery,
  useGetAllLookupsQuery,
  useLazyGetAllLookupsQuery,
} = injectedRtkApi;
