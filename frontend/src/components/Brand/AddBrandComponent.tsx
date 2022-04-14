import { ThunkDispatch } from "@reduxjs/toolkit";
import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { startAddBrand } from "../../actions/brands";
import { AppState } from "../../store/store";
import { AppActions } from "../../types/brand/actions";
import { Brand } from "../../types/brand/Brand";
import "react-toastify/dist/ReactToastify.css";
import { Box, Button, TextField } from "@mui/material";
import { toast, ToastContainer } from "react-toastify";
import {
  validatePhoneNumber,
  validateString,
} from "../../services/validateForm";
type Props = LinkStateProps & LinkDispatchProps;

interface AddBrandState {
  name: string;
  address: string;
  description: string;
  phoneNumber: string;
  userId: string;
  nameValid: string;
  addressValid: string;
  phoneValid: string;
}

class AddBrandComponent extends Component<Props, AddBrandState> {
  constructor(props: any) {
    super(props);
    this.state = {
      name: "",
      address: "",
      description: "",
      phoneNumber: "",
      userId: "",
      nameValid: "",
      addressValid: "",
      phoneValid: "",
    };
  }

  onAdd = async (data: Brand) => {
    await this.props.startAddBrand(data);
  };

  onHandleChange = (event: any) => {
    let target = event.target;
    let name = target.name;
    let value = target.value;

    const model = { [name]: value } as Pick<AddBrandState, keyof AddBrandState>;

    this.setState(model);

    if (name === "name") {
      this.setState({ nameValid: validateString(value) });
    } else if (name === "address") {
      this.setState({ addressValid: validateString(value) });
    } else if (name === "phoneNumber") {
      this.setState({ phoneValid: validatePhoneNumber(value) });
    }
  };

  onHandleSubmit = (event: any) => {
    event.preventDefault();

    const {
      name,
      address,
      description,
      phoneNumber,
      addressValid,
      phoneValid,
      nameValid,
      userId,
    } = this.state;

    if (
      name !== "" &&
      address !== "" &&
      phoneNumber !== "" &&
      userId !== "" &&
      nameValid === "" &&
      addressValid === "" &&
      phoneValid === ""
    ) {
      this.props.startAddBrand({
        modelId: 0,
        name: name,
        totalRate: 0,
        description: description,
        address: address,
        status: 0,
        phoneNumber: phoneNumber,
        userId: parseInt(userId),
      });
    } else {
      toast.warn("Hãy nhập dữ liệu hợp lệ", {
        position: "top-right",
        autoClose: 2000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
      });
    }
  };

  render() {
    const {
      name,
      address,
      description,
      phoneNumber,
      addressValid,
      phoneValid,
      nameValid,
      userId,
    } = this.state;

    return (
      <React.Fragment>
        <h2
          style={{
            position: "absolute",
            left: 0,
            right: 0,
            marginLeft: "auto",
            marginRight: "auto",
            width: "130px",
            marginTop: "10px",
          }}
        >
          Add Brand
        </h2>
        <form
          onSubmit={this.onHandleSubmit}
          style={{
            position: "absolute",
            left: 0,
            right: 0,
            marginLeft: "auto",
            marginRight: "auto",
            width: "700px",
            marginTop: "50px",
          }}
          noValidate
          autoComplete="off"
        >
          <TextField
            style={{ width: "700px" }}
            required
            name="name"
            value={name}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Name"
          />
          {nameValid !== "" && (
            <label className="alert-danger">{nameValid}</label>
          )}
          <br />
          <br />
          <TextField
            style={{ width: "700px" }}
            required
            name="address"
            value={address}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Address"
          />
          {addressValid !== "" && (
            <label className="alert-danger">{addressValid}</label>
          )}
          <br />
          <br />
          <TextField
            style={{ width: "700px" }}
            name="description"
            value={description}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Description"
          />
          <br />
          <br />
          <TextField
            style={{ width: "700px" }}
            required
            name="phoneNumber"
            value={phoneNumber}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Phone Number"
          />
          {phoneValid !== "" && (
            <label className="alert-danger">{phoneValid}</label>
          )}
          <br />
          <br />
          <TextField
            style={{ width: "700px" }}
            required
            name="userId"
            value={userId}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="UserId"
          />
          <br />
          <br />
          <div
            style={{
              display: "inline",
              position: "absolute",
              left: 0,
              right: 0,
              marginLeft: "auto",
              marginRight: "auto",
              width: "700px",
            }}
          >
            <Button
              sx={{ marginTop: 2 }}
              style={{
                position: "absolute",
                left: 0,
                width: "150px",
              }}
              type="button"
              variant="contained"
              aria-label="contained primary button group"
              color="error"
              onClick={() => (window.location.href = "/")}
            >
              Exit
            </Button>
            <Button
              sx={{ marginTop: 2 }}
              style={{
                display: "inline-flex",
                position: "absolute",
                right: 0,
                width: "150px",
              }}
              type="submit"
              variant="contained"
              aria-label="contained primary button group"
              color="primary"
            >
              Submit
            </Button>
          </div>
        </form>
        <ToastContainer />
      </React.Fragment>
    );
  }
}

interface LinkStateProps {
  brands: Brand[];
}
interface LinkDispatchProps {
  startAddBrand: (brand: Brand) => void;
}

const mapStateToProps = (state: AppState): LinkStateProps => ({
  brands: state.brands,
});

const mapDispatchToProps = (
  dispatch: ThunkDispatch<any, any, AppActions>
): LinkDispatchProps => ({
  startAddBrand: bindActionCreators(startAddBrand, dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(AddBrandComponent);
