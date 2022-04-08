import { bindActionCreators, ThunkDispatch } from "@reduxjs/toolkit";
import React, { Component } from "react";
import { AppState } from "../../store/store";
import { AppActions } from "../../types/brand/actions";
import { Brand } from "../../types/brand/Brand";
import { withRouter, WithRouterProps } from "../../withRouter";
import { connect } from "react-redux";
import { startGetBrandById, startUpdateBrand } from "../../actions/brands";
import { Box, Button, TextField } from "@mui/material";
import "react-toastify/dist/ReactToastify.css";
import { toast, ToastContainer } from "react-toastify";
import { validatePhoneNumber, validateString } from "../../services/validateForm";

type Props = LinkStateProps & LinkDispatchProps & WithRouterProps<Params>;

interface UpdateBrandState {
  name: string;
  address: string;
  description: string;
  phoneNumber: string;
  status: string;
  totalRate: string;
  userId: string;
  addressValid: string;
  phoneValid: string;
  nameValid: string;
}

interface Params {
  id: string;
}

class EditBrandComponent extends Component<Props, UpdateBrandState> {
  constructor(props: any) {
    super(props);
    this.state = {
      name: "",
      address: "",
      description: "",
      phoneNumber: "",
      status: "",
      totalRate: "",
      userId: "",
      addressValid: "",
      phoneValid: "",
      nameValid: "",
    };
  }

  async componentDidMount() {
    const id = this.props.match.params.id;
    await this.props.startGetBrandById(parseInt(id));
    const { brands } = this.props;

    debugger;
    brands.map((brand) => {
      this.setState({
        name: brand.name,
        address: brand.address,
        description: brand.description,
        phoneNumber: brand.phoneNumber,
        status: brand.status.toString(),
        totalRate: brand.totalRate.toString(),
        userId: brand.userId.toString(),
      });
    });
  }

  onHandleChange = (event: any) => {
    let target = event.target;
    let name = target.name;
    let value = target.value;

    const model = { [name]: value } as Pick<
      UpdateBrandState,
      keyof UpdateBrandState
    >;

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

    const name = this.state.name;
    const address = this.state.address;
    const description = this.state.description;
    const phoneNumber = this.state.phoneNumber;
    const status = this.state.status;
    const userId = this.state.userId;
    const addressValid = this.state.addressValid;
    const phoneValid = this.state.phoneValid;
    const nameValid = this.state.nameValid;
    const id = this.props.match.params.id;
    if (
      name != "" &&
      address != "" &&
      phoneNumber != "" &&
      userId != "" &&
      nameValid === "" &&
      addressValid === "" &&
      phoneValid === ""
    ) {
      this.props.startUpdateBrand({
        id: parseInt(id),
        name: name,
        totalRate: 0,
        description: description,
        address: address,
        status: parseInt(status),
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
    const name = this.state.name;
    const address = this.state.address;
    const description = this.state.description;
    const phoneNumber = this.state.phoneNumber;
    const status = this.state.status;
    const userId = this.state.userId;
    const totalRate = this.state.totalRate;
    const addressValid = this.state.addressValid;
    const phoneValid = this.state.phoneValid;
    const nameValid = this.state.nameValid;
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
            marginTop: "5px",
          }}
        >
          Edit Brand
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
            required
            name="totalRate"
            value={totalRate}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Total Rate"
            disabled
          />
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
            disabled
          />
          <br />
          <br />
          <TextField
            style={{ width: "700px" }}
            required
            name="status"
            value={status}
            onChange={this.onHandleChange}
            id="standard-basic"
            label="Status"
          />
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
              sx={{ marginTop: 1 }}
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
              sx={{ marginTop: 1 }}
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
  startUpdateBrand: (brand: Brand) => void;
  startGetBrandById: (id: number) => void;
}

const mapStateToProps = (state: AppState): LinkStateProps => ({
  brands: state.brands,
});

const mapDispatchToProps = (
  dispatch: ThunkDispatch<any, any, AppActions>
): LinkDispatchProps => ({
  startUpdateBrand: bindActionCreators(startUpdateBrand, dispatch),
  startGetBrandById: bindActionCreators(startGetBrandById, dispatch),
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(EditBrandComponent));
