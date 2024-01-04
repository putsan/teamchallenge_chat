import LobbyHeaderGreetings from "../LobbyHeaderGreetings.jsx";
import LobbyHeaderBar from "../LobbyHeaderBar/LobbyHeaderBar.jsx";
import LobbyHeaderButtons from "../LobbyHeaderButtons/LobbyHeaderButtons.jsx";

const LobbyHeader = () => {
  return (
    <div>
      <LobbyHeaderBar />
      <LobbyHeaderGreetings />
      <LobbyHeaderButtons />
    </div>
  );
};

export default LobbyHeader;
