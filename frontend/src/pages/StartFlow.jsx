import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import { useState } from "react";

import GetNameModal from "../components/GetNameModal/GetNameModal";
import { MODAL_CHOOSE, MODAL_RANDOM } from "../app/constants";

function StartFlow() {
  const [showModal, setShowModal] = useState(false);
  const [flow, setFlow] = useState(null);

  const toShowModal = (flowType) => {
    setFlow(flowType);
    setShowModal(true);
  };

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
          onClick={() => toShowModal(MODAL_CHOOSE)}
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
          onClick={() => toShowModal(MODAL_RANDOM)}
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

      <div>
        <Link
          to="/auth"
          style={{ marginRight: "25px" }}
          state={{ stage: "registration" }}
        >
          <Button variant="contained">Реєстрація</Button>
        </Link>

        <Link to="/auth">
          <Button variant="contained">Вхід</Button>
        </Link>
      </div>

      {showModal && (
        <GetNameModal handleClose={() => setShowModal(false)} flow={flow} />
      )}
    </div>
  );
}

export default StartFlow;
