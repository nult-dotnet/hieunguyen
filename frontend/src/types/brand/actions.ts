import { Brand } from "./Brand";
import * as types from "./types";

export interface GetAllBrandAction {
  type: typeof types.GET_ALL_BRAND;
  brands: Brand[];
}

export interface GetBrandByIdAction {
  type: typeof types.GET_BRAND_BY_ID;
  brand: Brand;
}

export interface AddBrandAction {
  type: typeof types.ADD_BRAND;
  brand: Brand;
}

export interface UpdateBrandAction {
  type: typeof types.UPDATE_BRAND;
  brand: Brand;
}

export interface DeleteBrandAction {
  type: typeof types.DELETE_BRAND;
  id: number;
}

export type BrandActionTypes =
  | GetAllBrandAction
  | GetBrandByIdAction
  | AddBrandAction
  | UpdateBrandAction
  | DeleteBrandAction;

export type AppActions = BrandActionTypes;
