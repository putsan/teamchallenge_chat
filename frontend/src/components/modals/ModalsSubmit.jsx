import "./ModalsSubmit.scss";
import modalType from "./ModalType";
<<<<<<< Updated upstream
const ModalsSubmit = ({type}) => {
  return (
    <div className="modal">
=======
import { useState } from "react";
const ModalsSubmit = ({type}) => {
  const [showModal,setShowModal] = useState(true)
  const closeModal = () => {
    setShowModal(false)
  }
  return (
    showModal && <div onClick={closeModal} className="background">
    <div onClick={(e) => e.stopPropagation()} className="modal">
>>>>>>> Stashed changes
      <div className="modal-content">
        <button className="backgtoun-svg">
          <input className="uploadFile--input" type="file" />
          <svg
            className="userPhoto"
            xmlns="http://www.w3.org/2000/svg"
            width="46"
            height="46"
            viewBox="0 0 46 46"
            fill="none"
          >
            <g clip-path="url(#clip0_341_665)">
              <path
                d="M5.75 15.3333C5.75 16.3875 6.6125 17.25 7.66667 17.25C8.72083 17.25 9.58333 16.3875 9.58333 15.3333V11.5H13.4167C14.4708 11.5 15.3333 10.6375 15.3333 9.58329C15.3333 8.52913 14.4708 7.66663 13.4167 7.66663H9.58333V3.83329C9.58333 2.77913 8.72083 1.91663 7.66667 1.91663C6.6125 1.91663 5.75 2.77913 5.75 3.83329V7.66663H1.91667C0.8625 7.66663 0 8.52913 0 9.58329C0 10.6375 0.8625 11.5 1.91667 11.5H5.75V15.3333Z"
                fill="#F8F9FA"
                fill-opacity="0.7"
              />
              <path
                d="M24.9167 32.5834C28.0924 32.5834 30.6667 30.009 30.6667 26.8334C30.6667 23.6577 28.0924 21.0834 24.9167 21.0834C21.7411 21.0834 19.1667 23.6577 19.1667 26.8334C19.1667 30.009 21.7411 32.5834 24.9167 32.5834Z"
                fill="#F8F9FA"
                fill-opacity="0.7"
              />
              <path
                d="M40.25 11.5H34.1742L31.7975 8.91246C31.0883 8.12663 30.0533 7.66663 28.98 7.66663H16.7133C17.0392 8.24163 17.25 8.87413 17.25 9.58329C17.25 11.6916 15.525 13.4166 13.4167 13.4166H11.5V15.3333C11.5 17.4416 9.775 19.1666 7.66667 19.1666C6.9575 19.1666 6.325 18.9558 5.75 18.63V38.3333C5.75 40.4416 7.475 42.1666 9.58333 42.1666H40.25C42.3583 42.1666 44.0833 40.4416 44.0833 38.3333V15.3333C44.0833 13.225 42.3583 11.5 40.25 11.5ZM24.9167 36.4166C19.6267 36.4166 15.3333 32.1233 15.3333 26.8333C15.3333 21.5433 19.6267 17.25 24.9167 17.25C30.2067 17.25 34.5 21.5433 34.5 26.8333C34.5 32.1233 30.2067 36.4166 24.9167 36.4166Z"
                fill="#F8F9FA"
                fill-opacity="0.7"
              />
            </g>
            <defs>
              <clipPath id="clip0_341_665">
                <rect width="46" height="46" fill="white" />
              </clipPath>
            </defs>
          </svg>
        </button>
        {modalType[type]}
      </div>
<<<<<<< Updated upstream
      <button className="decline-btn">Скасувати</button>
=======
      <button onClick={closeModal} className="decline-btn">Скасувати</button>
    </div>
>>>>>>> Stashed changes
    </div>
  );
};
export default ModalsSubmit;
