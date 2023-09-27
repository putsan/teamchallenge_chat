import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

import Authentication from "../pages/Authentication ";
import ChatScreen from "../pages/ChatScreen";
import StartFlow from '../pages/StartFlow';
import './App.scss'

function App() {
  return (
    <Router>
        <Routes>
          <Route path="/" element={<StartFlow />} />
          <Route path="/auth" element={<Authentication />} />
          <Route path="/chat/:chatId" element={<ChatScreen />} />
        </Routes>
    </Router>
  );
}

export default App;
