import { createStore, combineReducers, applyMiddleware } from "redux";
import thunk, { ThunkMiddleware } from "redux-thunk";
import { brandReducer } from "../reducers/brand/brands";
import { AppActions } from "../types/brand/actions";

export const rootReducer = combineReducers({
  brands: brandReducer,
});

export type AppState = ReturnType<typeof rootReducer>;

export const store = createStore(
  rootReducer,
  applyMiddleware(thunk as ThunkMiddleware<AppState, AppActions>)
);
