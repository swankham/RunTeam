import { createStore, applyMiddleware, compose } from 'redux'

// import rootReducer from './reducers';
// import { apiMiddleware } from './redux/middlewares';

const initialState = {
  sidebarShow: 'responsive'
}

const changeState = (state = initialState, { type, ...rest }) => {
  switch (type) {
    case 'set':
      return {...state, ...rest }
    default:
      return state
  }
}

const store = createStore(changeState);
export default store