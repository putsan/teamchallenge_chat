import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import Chat from "./components/temporraryTestComponents/Chat";

const AppRoutes = [
  {
    index: true,
    element: <Chat />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
