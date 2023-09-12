import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { Button, TextField } from "@mui/material";
import { decrement, increment } from "../app/store/counter/counterSlice";
import GoogleIcon from '@mui/icons-material/Google';

function Auth() {
  const dispatch = useDispatch();
  const count = useSelector(state => state.counter);

  return (
    <div>
      <p>Скоро тут буде чат</p>

     <div style={{margin: "25px"}}>
     <TextField label="Ім’я користувача" variant="standard" />
     </div>
     <div style={{margin: "25px"}}>
     <TextField label="Пароль" variant="standard" type="password"/>
     </div>
     <div style={{margin: "25px"}}>
     <TextField label="Підтвердіть пароль" variant="standard" type="password"/>
     </div>
      <div>
      <Link to="/"><Button variant="contained" sx={{marginRight:"10px"}}>Продовжити</Button> </Link>
      <Link to="/"> <Button variant="contained"><GoogleIcon/> </Button></Link>
      </div>
      <br/>
      <h1>Counter: {count}</h1>
      <p>Вже є аккаунт?</p>
    <Link to="/"> <p style={{textDecoration: "underline"}}> Вхід </p></Link>
      <br />
      <Link to="/"><Button variant="contained" sx={{fontSize: "16px"}}>Назад</Button></Link>

    </div>
  )
}
export default Auth
