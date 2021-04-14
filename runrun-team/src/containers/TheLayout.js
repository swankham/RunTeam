import React from 'react';
import { connect } from 'react-redux';
import {
  TheContent,
  TheSidebar,
  TheFooter,
  TheHeader
} from './index'

const TheLayout = ({ user }) => {

  let sidebar;
  if (user.isLoggedIn) {
    let data = user.roles.filter(role => role === "Admin");
    if (data.length > 0) {
      sidebar = <TheSidebar />;
    } else sidebar = "";
  } else {
    sidebar = "";
  }

  return (
    <div className="c-app c-default-layout">
      {sidebar}
      <div className="c-wrapper">
        <TheHeader />
        <div className="c-body">
          <TheContent />
        </div>
        <TheFooter />
      </div>
    </div>
  )
}

const mapStateToProps = (state) => ({ user: state.user });

export default connect(mapStateToProps)(TheLayout);