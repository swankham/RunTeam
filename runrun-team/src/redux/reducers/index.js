import { combineReducers } from 'redux';

import user from './userReducer';
import loading from './loadingReducer';
import store from './storeReducer';

const rootReducer = combineReducers({ user, loading, store});

export default rootReducer;