import React from "react";
import NavBar from "../components/NavBar";

const Layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <>
      <NavBar />
      {children}
    </>
  );
};

export default Layout;
