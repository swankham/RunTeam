import { combineReducers } from 'redux';

import user from './userReducer';
import loading from './loadingReducer';
import store from './storeReducer';
import event from './eventReducer';

const rootReducer = combineReducers({ user, loading, store, event});

export default rootReducer;