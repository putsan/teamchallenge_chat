import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import { useState } from "react";

import GetNameModal from "../../components/GetNameModal/GetNameModal";
import MoreInfoButton from "../../components/MoreInfoButton";
import { MODAL_MODES } from "../../app/constants";

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
      <div className="start-flow__main" />

      <div className="start-flow__bottom">
        <div className="start-flow__description">
          <h1>LDIS Live Discussion</h1>
          <p>Привіт, готовий до найкращого спілкування в своєму житті?</p>
        </div>

        <div className="start-flow__buttons">
          <Button
            onClick={() => toShowModal(MODAL_MODES.CHOOSE)}
            variant="contained"
            sx={{ width: "330px" }}
          >
            Продовжити без реєстрації
          </Button>

          <div>
            <Link to="/auth">
              <Button
                variant="outlined"
                size="small"
                sx={{ marginRight: "10px" }}
              >
                Вхід
              </Button>
            </Link>

            <Link to="/auth" state={{ stage: "registration" }}>
              <Button variant="outlined" size="small">
                Реєстрація
              </Button>
            </Link>
          </div>
        </div>

        <MoreInfoButton />
      </div>

      {showModal && (
        <GetNameModal handleClose={() => setShowModal(false)} flow={flow} />
      )}
    </div>
  );
}

export default StartFlow;
