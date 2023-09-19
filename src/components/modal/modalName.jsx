import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import React, { useState } from "react";
const ModalName = () =>{
    const   [isActive , setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)
    return(
        

        <div>

            {/* <Button onClick={handleOpen}> open</Button>  */}
            <Modal
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
    )
}

export default ModalName;