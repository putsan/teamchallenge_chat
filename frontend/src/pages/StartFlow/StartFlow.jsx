import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import { useState } from "react";

import GetNameModal from "../../components/GetNameModal/GetNameModal";
import { MODAL_MODES } from "../../app/constants";
import StyledButton from "../../components/Button";

import "./StartFlow.scss";

function StartFlow() {
  const [showModal, setShowModal] = useState(false);
  const [flow, setFlow] = useState(null);

  const toShowModal = (flowType) => {
    setFlow(flowType);
    setShowModal(true);
  };

  return (
    <div className="start-flow">
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
          onClick={() => toShowModal(MODAL_MODES.CHOOSE)}
          variant="contained"
          sx={{
            width: "140px",
            height: "140px",
            borderRadius: "50%",
            marginRight: "10px",
          }}
        >
          Обрати <br />
          чат
        </Button>

        <Button
          onClick={() => toShowModal(MODAL_MODES.RANDOM)}
          variant="contained"
          sx={{
            width: "140px",
            height: "140px",
            borderRadius: "50%",
          }}
        >
          Здивуй <br />
          мене
        </Button>
      </div>

      <div className="start-flow__top" />

      <div className="start-flow__bottom">
        <StyledButton text="Продовжити без реєстрації" />

        <Link
          to="/auth"
          style={{ marginRight: "25px" }}
          state={{ stage: "registration" }}
        >
          <Button variant="outlined" size="small">
            Реєстрація
          </Button>
        </Link>

        <Link to="/auth">
          <Button variant="outlined" size="small">
            Вхід
          </Button>
        </Link>
      </div>

      {showModal && (
        <GetNameModal handleClose={() => setShowModal(false)} flow={flow} />
      )}
    </div>
  );
}

export default StartFlow;
