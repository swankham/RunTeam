import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import {
    // CButton,
    // CCard,
    // CCardBody,
    // CCardGroup,
    // CCol,
    CContainer,
    // CForm,
    // CInput,
    // CInputGroup,
    // CInputGroupPrepend,
    // CInputGroupText,
    // CRow
} from '@coreui/react';
import { fetchAllEvents } from './../../redux/actions/eventActionCreators';

const Events = ({ events, dispatchFetchAllEventsAction }) => {
    useEffect(() => {dispatchFetchAllEventsAction(); }, [dispatchFetchAllEventsAction])

    const columns = [
        { field: 'eventCode', header: 'Code' },
        { field: 'eventName', header: 'Name' },
        { field: 'registrationStartDate', header: 'StartDate' },
        { field: 'registrationEndDate', header: 'EndDate' }
    ];

    return (
        <>
            <CContainer>

            </CContainer>
        </>
    )
}

const mapStateToProps = (state) => ({
    events: state.event.data
});

const mapDispatchToProps = dispatch => ({
    dispatchFetchAllEventsAction: () =>
        dispatch(fetchAllEvents())
});

export default connect(mapStateToProps, mapDispatchToProps)(Events);