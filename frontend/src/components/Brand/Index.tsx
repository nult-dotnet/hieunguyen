import * as React from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { Brand } from "../../types/brand/Brand";
import { AppState } from "../../store/store";
import { bindActionCreators, ThunkDispatch } from "@reduxjs/toolkit";
import { AppActions } from "../../types/brand/actions";
import { connect } from "react-redux";
import { startDeleteBrand, startGetAllBrands } from "../../actions/brands";
import { Button, ButtonGroup } from "@mui/material";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

type Props = LinkStateProps & LinkDispatchProps;

class Index extends React.Component<Props> {
  componentDidMount() {
    this.props.startGetAllBrands();
  }

  onDelete = (id: number) => {
    if (window.confirm("Are you sure wanted to delete the brand?")) {
      this.props.startDeleteBrand(id);
    }
  };

  render() {
    const { brands } = this.props;
    return (
      <React.Fragment>
        <Button
          sx={{ alignItems: "center", marginLeft: 75, marginTop: 2 }}
          variant="contained"
          aria-label="contained primary button group"
          color="primary"
          onClick={() => (window.location.href = "/add-brand")}
        >
          Add Brand
        </Button>
        <TableContainer component={Paper}>
          <Table
            sx={{ marginTop: 5, minWidth: 900 }}
            aria-label="customized table"
          >
            <TableHead>
              <TableRow>
                <StyledTableCell>Id</StyledTableCell>
                <StyledTableCell align="center">Name</StyledTableCell>
                <StyledTableCell align="center">Total Rate</StyledTableCell>
                <StyledTableCell align="center">Description</StyledTableCell>
                <StyledTableCell align="center">Address</StyledTableCell>
                <StyledTableCell align="center">Status</StyledTableCell>
                <StyledTableCell align="center">Phone Number</StyledTableCell>
                <StyledTableCell align="center">Owner</StyledTableCell>
                <StyledTableCell align="center">Actions</StyledTableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {brands.map((brand) => (
                <StyledTableRow key={brand.id}>
                  <StyledTableCell component="th" scope="row">
                    {brand.id}
                  </StyledTableCell>
                  <StyledTableCell align="center">{brand.name}</StyledTableCell>
                  <StyledTableCell align="center">
                    {brand.totalRate}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {brand.description}
                  </StyledTableCell>
                  <StyledTableCell align="center">
                    {brand.address}
                  </StyledTableCell>
                  <StyledTableCell align="center">
                    {brand.status}
                  </StyledTableCell>
                  <StyledTableCell align="center">
                    {brand.phoneNumber}
                  </StyledTableCell>
                  <StyledTableCell align="center">
                    {brand.userId}
                  </StyledTableCell>
                  <StyledTableCell
                    sx={{
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                      "& > *": {
                        margin: 1,
                      },
                    }}
                    align="center"
                  >
                    <ButtonGroup
                      variant="contained"
                      aria-label="contained primary button group"
                    >
                      <Button
                        onClick={() => this.onDelete(brand.id)}
                        style={{ marginRight: "10px" }}
                        color="error"
                      >
                        Delete
                      </Button>
                      <Button
                        onClick={() =>
                          (window.location.href = `/edit/${brand.id}`)
                        }
                        color="primary"
                      >
                        Edit
                      </Button>
                    </ButtonGroup>
                  </StyledTableCell>
                </StyledTableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </React.Fragment>
    );
  }
}

interface LinkStateProps {
  brands: Brand[];
}

interface LinkDispatchProps {
  startGetAllBrands: () => void;
  startDeleteBrand: (id: number) => void;
}

const mapStateToProps = (state: AppState): LinkStateProps => ({
  brands: state.brands,
});

const mapDispatchToProps = (
  dispatch: ThunkDispatch<any, any, AppActions>
): LinkDispatchProps => ({
  startGetAllBrands: bindActionCreators(startGetAllBrands, dispatch),
  startDeleteBrand: bindActionCreators(startDeleteBrand, dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(Index);
