import { ChatBubble } from "../ChatBubble/ChatBubble";
import "./MessagesArea.scss";

const messages = [
  { author: 'Моніка Геллер', text: 'Do you like it?', time: '11:45' },
  { author: 'Флеш', text: 'Lorem ipsum dolor sit amet consectetur.', time: '11:45' },
  { author: 'Моніка Геллер', text: 'Do you like it?', time: '11:45' },
  { author: 'Флеш', text: 'Lorem ipsum dolor sit amet consectetur.', time: '11:45' },
  { author: 'Моніка Геллер', text: 'Do you like it?', time: '11:45' },
  { author: 'Флеш', text: 'Lorem ipsum dolor sit amet consectetur.', time: '11:45' },
];

function MessagesArea() {
  return (
      <div className="msgs-area">
    {messages.map((message, index) => (
      <ChatBubble key={index} message={message} />
    ))}
  </div>
  )
}
export default MessagesArea
