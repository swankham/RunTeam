import * as constants from './../constants';

export default function diesReducer(state = [], action) {
    switch (action.type) {
        case constants.SET_ALL_EVENTS:
            return action.payload;
        case constants.SET_EVENT:
            return { ...action.payload.data };
        case constants.ADD_EVENT:
            return state.concat(action.payload);
        case constants.REMOVE_EVENT:
            return state.filter(item => item.id !== action.payload);
        case constants.UPDATE_EVENT:
            return state.map(item => {
                if (item.id === action.payload.id)
                    return { ...item, ...action.payload.data };
                else
                    return item;
            });
        case constants.RESET_USER_INFO:
            return [];
        default:
            return state;
    }
};
