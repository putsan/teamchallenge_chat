import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import "./ModalChatFull.scss";

const ModalChatFull = () => {
  const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    height: 400,
    bgcolor: "background.paper",
    border: "1px solid #000",
    p: 4,
  };

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <div>
      <Button onClick={handleOpen}>Open modal</Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography
            id="modal-modal-title"
            variant="h6"
            component="h2"
            sx={{ textAlign: "center" }}
          >
            <div style={{ color: "black" }}>Упс...</div>
            <span className="span-full-chat">Нажаль чат переповнений</span>
          </Typography>
          <Typography
            id="modal-modal-description"
            sx={{ mt: 2, textAlign: "center" }}
          >
            <div className="find-other">
              Давай знайдемо тобі
              <div>
                <span>щось інше</span>
              </div>
            </div>
            <div>
              <div>
                <Button
                  variant="contained"
                  className="list-chats"
                  sx={{
                    marginTop: "10%",
                    width: "200px",
                    background: "#BFBFBF",
                  }}
                >
                  До списку чатів
                </Button>
              </div>
              <div>
                <Button
                  variant="contained"
                  className="list-chats"
                  sx={{
                    marginTop: "10%",
                    width: "200px",
                    background: "#BFBFBF",
                  }}
                >
                  Здивуй мене
                </Button>
              </div>
            </div>
          </Typography>
        </Box>
      </Modal>
    </div>
  );
};
export default ModalChatFull;
