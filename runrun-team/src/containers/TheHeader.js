import React, { useState } from 'react'
import { connect } from 'react-redux'

import {
  CDropdown,
  CToggler,
  CHeaderBrand,
  CHeaderNav,
  CDropdownItem,
  CDropdownMenu,
  CDropdownToggle,
  CCollapse,
  CNavbar,
  CNavbarNav,
  // CNavbarBrand,
  CNavLink
} from '@coreui/react'
import CIcon from '@coreui/icons-react'

// routes config
//import routes from '../routes'
import { logoutUser } from './../redux/actions/authActionCreators';

import {
  // TheHeaderDropdown,
  // TheHeaderDropdownMssg,
  // TheHeaderDropdownNotif,
  // TheHeaderDropdownTasks
} from './index'

const TheHeader = ({ user, dispatchLogoutAction }) => {
  // const dispatch = useDispatch()
  // const sidebarShow = useSelector(state => state.store.sidebarShow)
  const [isOpen, setIsOpen] = useState(false)

  // const toggleSidebar = () => {
  //   const val = [true, 'responsive'].includes(sidebarShow) ? false : 'responsive'
  //   dispatch({ type: 'set', sidebarShow: val })
  // }

  // const toggleSidebarMobile = () => {
  //   const val = [false, 'responsive'].includes(sidebarShow) ? true : 'responsive'
  //   dispatch({ type: 'set', sidebarShow: val })
  // }

  let userLogin;
  if (user.isLoggedIn) {
    userLogin = "สวัสดี " + user.firstName + " " + user.lastName;
    // let data = user.roles.filter(role => role === "Admin");
    // if (data.length > 0) {
    //   userLogin = "Hi " + user.firstName + user.lastName;
    // } else userLogin = "";
  } else {
    userLogin = "";
  }

  return (
    // <CHeader withSubheader className="bg-gray-100">
    <CNavbar expandable="sm" className="navbar navbar-light bg-dark" style={{ padding: '0' }}>
      {/* <CToggler
          inHeader
          className="ml-md-3 d-lg-none"
          onClick={toggleSidebarMobile}
        />
        <CToggler
          inHeader
          className="ml-3 d-md-down-none"
          onClick={toggleSidebar}
        /> */}
      <CHeaderBrand className="mx-auto d-lg-none" to="/">
        <CIcon name="logo" height="35" alt="Logo" />
      </CHeaderBrand>

      <CToggler inNavbar onClick={() => setIsOpen(!isOpen)} />

      <CCollapse show={isOpen} navbar>
        <CNavbarNav>
          <CNavLink to="/Dashboard" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'white', fontWeight: 600 }}>หน้าหลัก</CNavLink>
          <CNavLink to="/Dashboard" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'white', fontWeight: 600 }}>อีเว้นทั้งหมด</CNavLink>
          {!user.isLoggedIn ?
            <>
              <CNavLink to="/Register" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'white', fontWeight: 600 }}>สมัครสมาชิก</CNavLink>
              <CNavLink to="/login" style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'white', fontWeight: 600 }}>เข้าสู่ระบบ</CNavLink>
            </>
            : ""
          }

        </CNavbarNav>

        <CHeaderNav className="d-md-down-none mr-auto">
        </CHeaderNav>

        {/* <CHeaderNav className="px-4">
          {userLogin}
          <TheHeaderDropdown />
        </CHeaderNav> */}
        {user.isLoggedIn ?
          <CDropdown style={{ paddingRight: '1rem', paddingLeft: '1rem' }}>
            <CDropdownToggle style={{ paddingRight: '1rem', paddingLeft: '1rem', color: 'white', fontWeight: 600 }}>
              {userLogin}
            </CDropdownToggle>
            <CDropdownMenu>
              <CDropdownItem>โปรไฟล์</CDropdownItem>
              <CDropdownItem>อีเว้นที่เคยสมัคร</CDropdownItem>
              {/* <CDropdownItem divider /> */}
              <CDropdownItem>เปลี่ยนรหัสผ่าน</CDropdownItem>
              <CDropdownItem divider />
              <CDropdownItem onClick={logoutUser} href="/">ออกจากระบบ</CDropdownItem>
            </CDropdownMenu>
          </CDropdown> :
          ""}
      </CCollapse>
    </CNavbar>
    // </CHeader>
  )
}

const mapStateToProps = (state) => ({ user: state.user });
const mapDispatchToProps = (dispatch) => ({
  dispatchLogoutAction: () => dispatch(logoutUser())
});

export default connect(mapStateToProps, mapDispatchToProps)(TheHeader);
