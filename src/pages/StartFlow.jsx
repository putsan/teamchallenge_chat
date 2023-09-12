import { Button } from "@mui/material"
import { Link } from "react-router-dom";

function StartFlow() {
  return (
    <div>
      <div>
        <h1>LDIS</h1>
        <p>Привіт, готовий до найкращого спілкування в своєму житті?</p>
      </div>

      <div style={{ margin: "55px 0 92px" }}>
        <h3>
          Реєстрація не потрібна!
          <br />
          Залітай і починай{" "}
        </h3>

        <Button
        variant="contained"
        sx={{
          width: '140px',
          height: '140px',
          borderRadius: '50%',
          marginRight: '10px'
        }}
      >
        Обрати <br />чат
      </Button>
      <Button
        variant="contained"
        sx={{
          width: '140px',
          height: '140px',
          borderRadius: '50%'
        }}
      >
        Здивуй <br />мене
      </Button>
      </div>

      <div>
      <Link to="/auth" style={{ marginRight: '25px' }}>
        <Button variant="contained">
          Реєстрація
        </Button>
      </Link>
      <Link to="/auth">
        <Button variant="contained">
          Вхід
        </Button>
      </Link>
    </div>
    </div>
  );
}
export default StartFlow
