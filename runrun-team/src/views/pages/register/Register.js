import React, { useState } from 'react'
import { connect } from 'react-redux'
import { toast } from 'react-toastify'
import { Redirect } from 'react-router-dom'

import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { loginUser, registerUser } from './../../../redux/actions/authActionCreators';

const Register = ({ user, dispatchLoginAction, dispatchRegisterAction }) => {
  //const [data, setData] = useState(null)
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [email, setEmail] = useState('')
  const [userName, setUserName] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')

  const handleSubmit = (e) => {
    e.preventDefault()
    newRegister(firstName, lastName, email, password, confirmPassword, userName);
  }

  const newRegister = (firstName, lastName, email, password, confirmPassword, userName) => new Promise((resolve, reject) => {
    dispatchRegisterAction(firstName, lastName, email, password, confirmPassword, userName, (response) => {
      resolve('success');
    },
      (message) => {
        reject(new Error(message));
      })
  }).then((done) => {
    toast.success('Registration Successfully!');
    dispatchLoginAction(email, password,
      () => {
        toast.success('Logged in successfully');
      },
      (message) => toast.error(`Error: ${message}`))
  }).catch((error) => {
    toast.error(`Error: ${error.message}`);
  });

  let redirect;
  if (user.isLoggedIn) {
    let data = user.roles.filter(role => role === "Admin");
    if (data.length > 0) {
      redirect = <Redirect to="/Dashboard" />;
    } else redirect = <Redirect to="/" />;
  } else {
    redirect = "";
  }

  return (
    <div>
      {/* <CContainer> */}
      <CRow className="justify-content-center" >
        <CCol md="9" lg="7" xl="6" >
          <CCard className="mx-4" style={{ boxShadow: '0 0 15px 1px rgb(0 0 0 / 40%)' }}>
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <h2 style={{ paddingRight: '1rem', paddingLeft: '1rem', fontWeight: 600 }}>ลงเบียนผู้เข้าใช้งาน</h2>
                <p className="text-muted" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'red !important', fontWeight: 600 }}>* จำเป็นต้องระบุ</p>
                <CInputGroup className="mb-3">
                  <CInputGroupPrepend>
                    <CInputGroupText>
                      <CIcon name="cil-user" />
                    </CInputGroupText>
                  </CInputGroupPrepend>
                  <CInput type="text" placeholder="ชื่อ*" autoComplete="firstName" value={firstName} onChange={(e) => setFirstName(e.target.value)} required style={{ marginRight: '0.5rem' }} />
                  <CInput type="text" placeholder="สกุล*" autoComplete="lastName" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CInputGroupPrepend>
                    <CInputGroupText>@</CInputGroupText>
                  </CInputGroupPrepend>
                  <CInput type="email" placeholder="อีเมล์*" autoComplete="email" value={email} onChange={(e) => { setEmail(e.target.value); setUserName(e.target.value) }} required />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CInputGroupPrepend>
                    <CInputGroupText>
                      <CIcon name="cil-lock-locked" />
                    </CInputGroupText>
                  </CInputGroupPrepend>
                  <CInput type="password" placeholder="รหัสผ่าน*" autoComplete="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
                </CInputGroup>
                <CInputGroup className="mb-4">
                  <CInputGroupPrepend>
                    <CInputGroupText>
                      <CIcon name="cil-lock-locked" />
                    </CInputGroupText>
                  </CInputGroupPrepend>
                  <CInput type="password" placeholder="ยืนยันรหัสผ่าน*" autoComplete="Confirm-password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} required />
                </CInputGroup>
                <CButton type="submit" color="success" block>สมัครสมาชิก</CButton>
              </CForm>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
      {/* </CContainer> */}
      {redirect}
    </div>
  )  
}
//registerUser
const mapStateToProps = (state) => ({ user: state.user });

const mapDispatchToProps = dispatch => ({
  dispatchLoginAction: (email, password, onSuccess, onError) =>
    dispatch(loginUser({ email, password }, onSuccess, onError)),
  dispatchRegisterAction: (firstName, lastName, email, password, confirmpassword, username, onSuccess, onError) =>
    dispatch(registerUser({ firstName, lastName, email, password, confirmpassword, username }, onSuccess, onError))
});

export default connect(mapStateToProps, mapDispatchToProps)(Register);