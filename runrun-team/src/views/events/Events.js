import React, {useEffect} from 'react';
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
    useEffect(() => dispatchFetchAllEventsAction(), [dispatchFetchAllEventsAction])
    return (
        <>
            <CContainer>
                All Events
            </CContainer>
        </>
    )
}

const mapStateToProps = (state) => ({ 
    events: state.events 
});

const mapDispatchToProps = dispatch => ({
  dispatchFetchAllEventsAction: () =>
    dispatch(fetchAllEvents())
});

export default connect(mapStateToProps, mapDispatchToProps)(Events);