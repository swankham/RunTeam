import React from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCardFooter,
  CCol,
  CContainer,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow,
  CInvalidFeedback,
  CValidFeedback
} from '@coreui/react'
import CIcon from '@coreui/icons-react'

const Register = () => {
  return (
    <div>
      {/* <CContainer> */}
        <CRow className="justify-content-center">
          <CCol md="9" lg="7" xl="6">
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm>
                  <h2 style={{ paddingRight: '1rem', paddingLeft: '1rem', fontWeight: 600 }}>ลงเบียนผู้เข้าใช้งาน</h2>
                  <p className="text-muted" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'red !important', fontWeight: 600 }}>* จำเป็นต้องระบุ</p>
                  <CInputGroup className="mb-3">
                    <CInputGroupPrepend>
                      <CInputGroupText>
                        <CIcon name="cil-user" />
                      </CInputGroupText>
                    </CInputGroupPrepend>
                    <CInput type="text" placeholder="ชื่อ*" autoComplete="firstName" required style={{ marginRight: '0.5rem'}}/>
                    <CInput type="text" placeholder="สกุล*" autoComplete="lastName" required/>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CInputGroupPrepend>
                      <CInputGroupText>@</CInputGroupText>
                    </CInputGroupPrepend>
                    <CInput type="email" placeholder="อีเมล์*" autoComplete="email" required/>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CInputGroupPrepend>
                      <CInputGroupText>
                        <CIcon name="cil-lock-locked" />
                      </CInputGroupText>
                    </CInputGroupPrepend>
                    <CInput type="password" placeholder="รหัสผ่าน*" autoComplete="new-password" required/>
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CInputGroupPrepend>
                      <CInputGroupText>
                        <CIcon name="cil-lock-locked" />
                      </CInputGroupText>
                    </CInputGroupPrepend>
                    <CInput type="password" placeholder="ยืนยันรหัสผ่าน*" autoComplete="new-password" required/>
                  </CInputGroup>
                  <CButton type="submit" color="success" block>สมัครสมาชิก</CButton>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      {/* </CContainer> */}
    </div>
  )
}

export default Register
