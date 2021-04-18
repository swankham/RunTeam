import * as constants from '../constants';

export const fetchAllEvents = (data, onSuccess, onError) => ({
    type: constants.API,
    payload: {
        method: 'GET',
        url: '/api/v1.0/Event',
        data,
        success: (response) => (setAllEvents(response)),
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

export const createEvent = (data, onSuccess, onError) => ({
    type: constants.API,
    payload: {
        method: 'POST',
        url: '/api/v1.0/Event',
        data,
        success: (data) => (addEvent(data)),
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

export const getEventById = (id, onSuccess) => ({
    type: constants.API,
    payload: {
        method: 'GET',
        url: `/api/v1.0/Event/${id}`,
        postProcessSuccess: onSuccess
    }
});

// export const getEventByCode = (code, refcode, onSuccess, onError) => ({
//     type: constants.API,
//     payload: {
//         method: 'GET',
//         url: `/api/v1.0/Event/GetByCode?dieCode=${code}&refCode=${refcode}`,
//         success: (response) => (setAllEvents(response)),
//         postProcessSuccess: onSuccess,
//         postProcessError: onError
//     }
// });

export const updateEventById = (id, data, onSuccess, onError) => ({
    type: constants.API,
    payload:{
        method: 'PUT',
        url: `/api/v1.0/Event/${id}`,
        data,
        success: (id, data) => (updateEvent(id, data)),
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

export const deleteEventById = (id, onSuccess, onError) => ({
    type: constants.API,
    payload:{
        method: 'DELETE',
        url: `/api/v1.0/Event/${id}`,
        success: () => (removeEvent(id)),
        postProcessSuccess: onSuccess,
        postProcessError: onError
    }
});

const updateEvent = (id, data) => ({
    type: constants.UPDATE_EVENT,
    payload: { id, data }
});

const addEvent = (data) => ({
    type: constants.ADD_EVENT,
    payload: data
});

const setAllEvents = (data) => ({
    type: constants.SET_ALL_EVENTS,
    payload: data
});

const removeEvent = (id) => ({
    type: constants.REMOVE_EVENT,
    payload: { id }
});