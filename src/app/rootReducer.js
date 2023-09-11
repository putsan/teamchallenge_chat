// app/rootReducer.js
import { combineReducers } from '@reduxjs/toolkit';
// import userReducer from '../features/userSlice';
import counterSlice from '../modules/counter/counterSlice';

const rootReducer = combineReducers({
  counter: counterSlice,
  // user: userReducer
});

export default rootReducer;
