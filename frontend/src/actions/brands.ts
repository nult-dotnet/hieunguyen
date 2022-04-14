import { AppState } from "./../store/store";
import { AppActions } from "./../types/brand/actions";
import { Brand } from "../types/brand/Brand";
import * as types from "../types/brand/types";
import { Dispatch } from "redux";
import {
  add,
  deleteApi,
  getAll,
  getById,
  update,
  updatePatch,
} from "../services/brandApi";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export const getAllBrand = (brands: Brand[]): AppActions => ({
  type: types.GET_ALL_BRAND,
  brands,
});

export const getBrandById = (brand: Brand): AppActions => ({
  type: types.GET_BRAND_BY_ID,
  brand,
});

export const addBrand = (brand: Brand): AppActions => ({
  type: types.ADD_BRAND,
  brand,
});

export const updateBrand = (brand: Brand): AppActions => ({
  type: types.UPDATE_BRAND,
  brand,
});

export const patchBrand = (brand: Brand): AppActions => ({
  type: types.PATCH_BRAND,
  brand,
});

export const deleteBrand = (id: number): AppActions => ({
  type: types.DELETE_BRAND,
  id,
});

export const startGetAllBrands =
  () => async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const res = await getAll();
      dispatch(getAllBrand(res.resultObj));
    } catch (error) {
      console.log(error);
    }
  };

export const startGetBrandById =
  (id: number) =>
  async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const res = await getById(id);

      if (res.isSuccessed) {
        dispatch(getBrandById(res.resultObj));
      } else {
        toast.warn(res.message, {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
      }
    } catch (error) {
      console.log(error);
    }
  };

export const startAddBrand =
  (brand: Brand) =>
  async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const data = {
        name: brand.name,
        description: brand.description,
        address: brand.address,
        phoneNumber: brand.phoneNumber,
        userId: brand.userId,
      };
      const res = await add(data);
      debugger;
      if (res.isSuccessed) {
        toast.info("Đã thêm thương hiệu thành công", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
        dispatch(addBrand(res.resultObj));
      } else {
        toast.warn(res.message, {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
      }
    } catch (error) {
      console.log(error);
    }
  };

export const startUpdateBrand =
  (brand: Brand) =>
  async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const data = {
        name: brand.name,
        description: brand.description,
        address: brand.address,
        phoneNumber: brand.phoneNumber,
        status: brand.status,
      };
      const res = await update(brand.modelId, data);

      if (res.isSuccessed) {
        toast.info("Cập nhật thương hiệu thành công", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
        dispatch(updateBrand(res.resultObj));
      } else {
        toast.warn(res.message, {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
      }
    } catch (error) {
      console.log(error);
    }
  };

export const startPatchBrand =
  (id: number, data: any) =>
  async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const res = await updatePatch(id, data);

      debugger;

      if (res.isSuccessed) {
        toast.info("Cập nhật thương hiệu thành công", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
        dispatch(patchBrand(res.resultObj));
      } else {
        toast.warn(res.message, {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
      }
    } catch (error) {
      console.log(error);
    }
  };

export const startDeleteBrand =
  (id: number) =>
  async (dispatch: Dispatch<AppActions>, getState: () => AppState) => {
    try {
      const res = await deleteApi(id);
      dispatch(deleteBrand(id));
    } catch (error) {
      console.log(error);
    }
  };
