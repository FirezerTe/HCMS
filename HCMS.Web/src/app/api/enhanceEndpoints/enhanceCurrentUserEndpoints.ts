import { HCMSApi } from "../HCMSApi";
import { Tag } from "./tags";

const enhancedApi = HCMSApi.enhanceEndpoints({
  addTagTypes: [Tag.CurrentUser],
  endpoints: {
    // logins: {
    //   invalidatesTags: [Tag.CurrentUser],
    // }
  },
});

export default enhancedApi;
