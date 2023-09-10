import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement } from '../features/counter/counterSlice';
import './App.scss'

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
    </div>
  );
}

export default App;
