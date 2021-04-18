import * as constants from '../constants';

export const registerUser = (data, onSuccess, onError) => ({
    type: constants.API,
    payload: {
        method: 'POST',
        header:{
            'Content-Type': 'application/json'
        },
        url: '/api/account/register',        
        data,
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

export const loginUser = (data, onSuccess, onError) => ({
    type: constants.API,
    payload: {
        method: 'POST',
        url: '/api/Account/authenticate',
        data,        
        success: (response) => (setUserInfo(response)),
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

export const logoutUser = () => {
    localStorage.removeItem('USER_INFO_RUNRUN_TEAM');
    return { type: constants.RESET_USER_INFO };
};

const setUserInfo = (data) =>{
    // const parsedToken = JSON.parse(atob(data.jwToken.split('.')[1]));
    console.log(data);
    const userInfo = {
        userId: data.data.id,  //Data.data: UserId
        email: data.data.email,
        userName: data.data.userName,
        token: data.data.jwToken,
        firstName: data.data.firstName,
        lastName: data.data.lastName,
        isLoggedIn: true,
        roles: data.data.roles
    };
    localStorage.setItem('USER_INFO_RUNRUN_TEAM', JSON.stringify(userInfo));
    return {type: constants.SET_USER_INFO, payload: userInfo};
}