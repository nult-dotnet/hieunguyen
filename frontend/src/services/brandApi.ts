import { apiURL, headers } from "./api";
import axios from "axios";

const getAll = async () => {
  try {
    const res = await axios.get(`${apiURL}/brands/get-all`);
    return res.data;
  } catch (error) {
    console.log(error);
  }
};

const getById = async (id: number) => {
  try {
    const res = await axios.get(`${apiURL}/brands/${id}`);
    return res.data;
  } catch (error) {
    console.log(error);
  }
};

const add = async (brand: {
  name: string;
  description: string;
  address: string;
  phoneNumber: string;
  userId: number;
}) => {
  try {
    const res = await axios.post(`${apiURL}/brands/create`, brand, { headers });
    return res.data;
  } catch (error) {
    console.log(error);
  }
};

const update = async (
  id: number,
  brand: {
    name: string;
    description: string;
    address: string;
    phoneNumber: string;
    status: number;
  }
) => {
  try {
    const res = await axios.put(`${apiURL}/brands/update/${id}`, brand, {
      headers
    });
    return res.data;
  } catch (error) {
    console.log(error);
  }
};

const deleteApi = async (id: number) => {
  try {
    const res = await axios.delete(`${apiURL}/brands/delete/${id}`, {
      headers,
    });
    debugger
    return res.data;
  } catch (error) {
    console.log(error);
  }
};

export { getAll, getById, add, update, deleteApi };
