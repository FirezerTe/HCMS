import { rtkQueryErrorHandler } from "./api/emptySplitApi";
import {
  Action,
  AnyAction,
  ThunkAction,
  configureStore,
} from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import { HCMSApi } from "./api/HCMSApi";

export const store = configureStore({
  reducer: {
    [HCMSApi.reducerPath]: HCMSApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware().concat([
      HCMSApi.middleware,
      rtkQueryErrorHandler,
    ]);
  },
});

setupListeners(store.dispatch);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
export * from "./api";
