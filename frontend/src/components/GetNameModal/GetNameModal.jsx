import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import "./GetNameModal.scss";

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 310,
  bgcolor: '#808080',
  border: '2px solid #000',
  boxShadow: 24,
  p: 2,
};

export const GetNameModal = ({ handleClose }) => {

  return (
    <Modal
      open={true}
      onClose={handleClose}
    >
      <Box sx={style}>
        <Typography id="modal-modal-title" variant="h6" component="h2">
          Як можна до тебе звертатись?
        </Typography>

        <TextField helperText="Це ім’я бачитимуть усі користувачі чату" />

        <Link to="/chat/000">
          <Button variant="contained" onClick={handleClose}>
            Здивуй мене
          </Button>
        </Link>
      </Box>
    </Modal>
  );
};
