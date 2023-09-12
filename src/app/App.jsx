import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement } from './store/counter/counterSlice';

import { Button } from '@mui/material';
import StartFlow from '../pages/StartFlow';
import './App.scss'
import Auth from '../pages/Auth';

function App() {
  const dispatch = useDispatch();
  const count = useSelector(state => state.counter);

  return (
    <div>
      <p>Скоро тут буде чат</p>
      <br/>
      <h1>Counter: {count}</h1>
      <button onClick={() => dispatch(increment())}>Increment</button>
      <button onClick={() => dispatch(decrement())}>Decrement</button>
      <Button sx={{fontSize: "16px"}}>Text</Button>

      <StartFlow/>
      <Auth/>
    </div>
  );
}

export default App;
