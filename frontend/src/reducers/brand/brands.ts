import { BrandActionTypes } from "../../types/brand/actions";
import { Brand } from "./../../types/brand/Brand";
import * as types from "../../types/brand/types";

const brandsReducerDefaultState: Brand[] = [];

const brandReducer = (
  state = brandsReducerDefaultState,
  action: BrandActionTypes
): Brand[] => {
  switch (action.type) {
    case types.GET_ALL_BRAND:
      return action.brands;
    case types.GET_BRAND_BY_ID:
      const t: Brand[] = [];
      t.push(action.brand);
      return t;
    case types.ADD_BRAND:
      return [...state, action.brand];
    case types.DELETE_BRAND:
      return state.filter(({ id }) => id !== action.id);
    case types.UPDATE_BRAND || types.PATCH_BRAND:
      return state.map((brand) => {
        if (brand.id === action.brand.id) {
          return {
            ...brand,
            ...action.brand,
          };
        } else {
          return brand;
        }
      });
    default:
      return state;
  }
};

export { brandReducer };
