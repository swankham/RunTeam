import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';

import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CHeaderBrand,
  CCol,
  CContainer,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow
} from '@coreui/react';
import CIcon from '@coreui/icons-react';
import { loginUser } from './../../../redux/actions/authActionCreators';

const Login = ({ user, dispatchLoginAction }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  // eslint-disable-next-line
  const [error, setError] = useState({ email: false, password: false });

  const handleOnSubmit = (e) => {
    e.preventDefault();
    if (isFormInvalid()) updateErrorFlags();
    else dispatchLoginAction(email, password,
      () => {
        //toast.success('Logged in successfully');      
      },
      (message) => toast.error(`Error: ${message}`))
  };

  let redirect;
  if (user.isLoggedIn) {
    let data = user.roles.filter(role => role === "Admin");
    if (data.length > 0) {
      redirect = <Redirect to="/Dashboard" />;
    } else redirect = <Redirect to="/base/carousels" />;
  } else {
    redirect = "";
  }

  const isFormInvalid = () => (!email || !password);

  const updateErrorFlags = () => {
    const errObj = { email: false, password: false };
    if (!email.trim()) errObj.email = true;
    if (!password.trim()) errObj.password = true;
    setError(errObj);
  };

  return (
    <div className="c-app c-default-layout flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md="8">
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <CForm>
                    <h1>เข้าสู่ระบบ</h1>
                    <p className="text-muted">ยินดีต้อนรับเข้าสู่ รันรันทีม</p>
                    <CInputGroup className="mb-3">
                      <CInputGroupPrepend>
                        <CInputGroupText>
                          <CIcon name="cil-user" />
                        </CInputGroupText>
                      </CInputGroupPrepend>
                      <CInput
                        type="email"
                        placeholder="อีเมล์"
                        autoComplete="username"
                        onChange={(e) => setEmail(e.target.value)}
                        value={email} />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupPrepend>
                        <CInputGroupText>
                          <CIcon name="cil-lock-locked" />
                        </CInputGroupText>
                      </CInputGroupPrepend>
                      <CInput
                        type="password"
                        placeholder="รหัสผ่าน"
                        autoComplete="current-password"
                        onChange={(e) => setPassword(e.target.value)}
                        value={password} />
                    </CInputGroup>
                    <CRow>
                      <CCol xs="6">
                        {/* <CButton type="submit" color="primary" className="px-4">Login</CButton> */}
                        <CButton type="submit" size="sm" color="primary" onClick={handleOnSubmit}><CIcon name="cil-scrubber" /> เข้าสู่ระบบ</CButton>
                      </CCol>
                      {/* <CCol xs="6" className="text-right">
                        <CButton color="link" className="px-0">Forgot password?</CButton>
                      </CCol> */}
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
              <CCard className="text-white bg-primary py-5 d-md-down-none" style={{ width: '44%' }}>
                <CCardBody className="text-center">
                  <div>
                    <h2>มาเป็นส่วนหนึ่งกับเรา</h2>
                    {/* <p>เพื่อความสะดวก ทางเราได้ทำการจัดเก็บข้อมูลของท่านที่ได้กรอกรายละเอียดในระบบที่มีความปลอดภัย โดยถือว่าเป็นสิทธิและกรรมสิทธิ์ของเรา รวมไปถึงเบอร์ IP Address และวันเวลาที่ท่านได้เข้ามาใช้บริการด้วย</p> */}
                    <Link to="/register">
                      <CButton color="primary" className="mt-3" active tabIndex={-1}>สมัครสมาชิก ตอนนี้!</CButton>
                    </Link>
                  </div>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
      {redirect}
    </div>
  )
}

const mapStateToProps = (state) => ({ user: state.user });
const mapDispatchToProps = dispatch => ({
  dispatchLoginAction: (email, password, onSuccess, onError) =>
    dispatch(loginUser({ email, password }, onSuccess, onError))
});

export default connect(mapStateToProps, mapDispatchToProps)(Login);
