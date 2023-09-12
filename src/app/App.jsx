import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

import StartFlow from '../pages/StartFlow';
import Auth from '../pages/Auth';
import './App.scss'

function App() {
  return (
    <Router>
        <Routes>
          <Route path="/" element={<StartFlow />} />
          <Route path="/auth" element={<Auth />} />
        </Routes>
    </Router>
  );
}

export default App;
