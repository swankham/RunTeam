import axios from 'axios';

import * as constants from './constants';
import { logoutUser } from './actions/authActionCreators';

export const apiMiddleware = ({ dispatch, getState }) => next => action => {
    if (action.type !== constants.API) return next(action);

    dispatch({ type: constants.TOGGLE_LOADER });

    const AUTH_TOKEN = getState().user.token;
    //console.log('Token: ', AUTH_TOKEN);
    if (AUTH_TOKEN)
        axios.defaults.headers.common['Authorization'] = `Bearer ${AUTH_TOKEN}`;
    const { url, method, success, data, postProcessSuccess, postProcessError } =
        action.payload;
    //console.log(method)

    axios({
        method,
        url: constants.BASE_URL + url,
        data: data ? data : null
    }).then((response) => {
        // console.log('success response: ', response)        
        if (response) {
            // console.log('response.data: ', response)
            if (postProcessSuccess) postProcessSuccess(response.data.data);
            if (success) dispatch(success(response.data)); //ทำให้เกิด catch            
        }
        dispatch({ type: constants.TOGGLE_LOADER });
    })
        .catch((err) => {
            //console.log('error1: ', err)
            dispatch({ type: constants.TOGGLE_LOADER });

            if (err.response) {
                console.log('error response : ', err.response)
                console.log('error response data : ',err.response.data)
                if (err.response && err.response.status === 403)
                    dispatch(logoutUser());
                if (err.response.status === 500)
                    if (postProcessError) postProcessError('500 Internal Server Error');
                if (err.response.status === 400){
                    console.log('error status = 400')
                    if(err.response.data.Message){
                        console.log('Message = true')
                        if (postProcessError) postProcessError(err.response.data.Message);
                    }                        
                    else{
                        if (postProcessError){
                            postProcessError(err.response.data.title);
                        }
                    }
                }                    
                if (err.response.data.errors) {                    
                    if (postProcessError) postProcessError(!err.response.data.errors);// ? err.response.data.Message : err.response.data.errors);
                }
            }
        })
};