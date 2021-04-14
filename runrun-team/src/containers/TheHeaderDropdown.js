import React from 'react';
import { connect, useSelector } from 'react-redux';
import {
  CBadge,
  CDropdown,
  CDropdownItem,
  CDropdownMenu,
  CDropdownToggle,
  CImg
} from '@coreui/react';
import CIcon from '@coreui/icons-react';
import { logoutUser } from './../redux/actions/authActionCreators';
// import { Redirect } from 'react-router-dom';


const TheHeaderDropdown = ({ dispatchLogoutAction }) => {

  const isLogIn = useSelector(state => state.user.isLoggedIn)

  const logoutUser = () => {
    //e.preventDefault();
    dispatchLogoutAction();
    console.log("LogOut Completed.")
  };

  return (
    <CDropdown
      inNav
      className="c-header-nav-items mx-2"
      direction="down"
    >
      <CDropdownToggle className="c-header-nav-link" caret={false}>
        <div className="c-avatar">
          <CImg
            src={'/avatars/6.jpg'}
            className="c-avatar-img"
            alt="admin@bootstrapmaster.com"
          />
        </div>
      </CDropdownToggle>
      <CDropdownMenu className="pt-0" placement="bottom-end">
        <CDropdownItem
          header
          tag="div"
          color="light"
          className="text-center"
        >
          {/* <strong>Account</strong> */}
        </CDropdownItem>
        <CDropdownItem>
          <CIcon name="cil-bell" className="mfe-2" />
          หน้าหลัก
        </CDropdownItem>
        <CDropdownItem>
          <CIcon name="cil-envelope-open" className="mfe-2" />
          อีเว้นทั้งหมด
          <CBadge color="success" className="mfs-auto">42</CBadge>
        </CDropdownItem>
        <CDropdownItem
          header
          tag="div"
          color="light"
          className="text-center"
        >
        {isLogIn ? <strong>ตั้งค่า</strong> : ""}
        </CDropdownItem>
        {isLogIn ?
          <div>
            <CDropdownItem>
              <CIcon name="cil-user" className="mfe-2" />
                โปรไฟล์
              </CDropdownItem>
            <CDropdownItem>
              <CIcon name="cil-credit-card" className="mfe-2" />
                อีเว้นของฉัน
                <CBadge color="secondary" className="mfs-auto">42</CBadge>
            </CDropdownItem>
            <CDropdownItem divider />
            <CDropdownItem >
              <CIcon name="cil-settings" className="mfe-2" />
                เปลี่ยนรหัสผ่าน
              </CDropdownItem>
            <CDropdownItem onClick={logoutUser} href="/">
              <CIcon name="cil-lock-locked" className="mfe-2" />
                ออกจากระบบ
              </CDropdownItem>
          </div> : <div><CDropdownItem to="/login">
              <CIcon name="cil-lock-locked" className="mfe-2" />
                เข้าสู่ระบบ
              </CDropdownItem></div>
        }
      </CDropdownMenu>
    </CDropdown>
  )
}

// const mapStateToProps = (state) => ({ user: state.user });
const mapDispatchToProps = dispatch => ({
  dispatchLogoutAction: () => dispatch(logoutUser())
});

export default connect(null, mapDispatchToProps)(TheHeaderDropdown);
