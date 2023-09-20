import { Box, Button, Modal, TextField, Typography } from "@mui/material"
import React from "react";
import { Link } from "react-router-dom";
import ModalName from "../components/modal/modalName";



function StartFlow( ) {
  const   [isActive , setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true)
  const handleClose = () => setOpen(false)
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

        <Button  onClick={handleOpen}
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
      <Link to="/auth" style={{ marginRight: '25px' }} state={{ stage: "login" }}>
        <Button variant="contained">
          Реєстрація
        </Button>
      </Link>
      <Link to="/login" state={{ stage: "registration" }}>
        <Button variant="contained">
          Вхід
        </Button>
      </Link>
    </div>
    <Modal sx={{width: "310px", height:"380px", backgroundColor: "blue", }}

             open={isActive}
             onClose={handleClose}> 
                 <Box>
                 <Typography id="modal-modal-title" variant="h6" component="h2">
      Text in a modal
    </Typography>
             <TextField helperText="Це ім’я бачитимуть усі користувачі чату" />
             </Box>
             </Modal>
    </div>
  );
}
export default StartFlow
