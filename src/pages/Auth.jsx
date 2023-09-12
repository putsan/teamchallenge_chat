import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import { decrement, increment } from "../app/store/counter/counterSlice";

function Auth() {
  const dispatch = useDispatch();
  const count = useSelector(state => state.counter);

  return (
    <div>
      <p>Скоро тут буде чат</p>
      <p>Це сторінка під твої екрани для входу та реєстрації. Павда подумай чи треба їх розділяти на 2 на різних ендпоїнтах чи зробиш на одному, як мінімум поки.. Або разом можемо подумати щодо цього</p>
      <br/>
      <h1>Counter: {count}</h1>
      <Button onClick={() => dispatch(increment())}>Increment</Button>
      <Button onClick={() => dispatch(decrement())}>Decrement</Button>
      <br />
      <Link to="/"><Button variant="contained" sx={{fontSize: "16px"}}>Назад</Button></Link>
    </div>
  )
}
export default Auth
