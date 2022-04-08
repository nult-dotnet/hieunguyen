import "./App.css";
import { Route, Routes } from "react-router-dom";
import Index from "./components/Brand/Index";
import AddBrandComponent from "./components/Brand/AddBrandComponent";
import EditBrandComponent from "./components/Brand/EditBrandComponent";

function App() {
  return (
    <div style={{alignItems:"center"}}>
      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/add-brand" element={<AddBrandComponent />} />
        <Route path="/edit/:id" element={<EditBrandComponent/>}/>
      </Routes>
    </div>
  );
}

export default App;
