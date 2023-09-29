import ChatFooter from "../components/ChatFooter/ChatFooter";
import MessagesArea from "../components/MessagesArea/MessagesArea";
import NavHeader from "../components/NavHeader/NavHeader";

function ChatScreen() {
  return (
    <div>
      <NavHeader />
      <MessagesArea />
      <ChatFooter />
    </div>
  );
}
export default ChatScreen;
