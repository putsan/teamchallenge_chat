import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

import StartFlow from '../pages/StartFlow';
import Auth from '../pages/Auth';
import './App.scss'
import Login from "../pages/Login";
import ModalName from "../components/modal/modalName";


function App() {
  return (
    <Router>
        <Routes>
          <Route path="/" element={<StartFlow />} />
          <Route path="/auth" element={<Auth />} />
          <Route path ="/login" element={<Login/>} />
          <Route path="/ModalName" element={<ModalName/>} />
        </Routes>
    </Router>
  );
}

export default App;
