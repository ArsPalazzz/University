import React from "react";
import vinyl from "./../images/other/vinyl4.svg";
import heart from "./../images/other/heart.svg";
import cart from "./../images/other/cart.svg";
import settings from "./../images/other/settings.svg";
import classes from "./../sassModules/Header.module.scss";
import { Link } from "react-router-dom";
import { RiShoppingBasketFill } from "react-icons/ri";
import { BsMoon } from "react-icons/bs";
import { useState } from "react";
import Order from "./Order";
import bagImg from "./../images/other/bagbag.svg";

const showOrders = (props) => {
  let summa = 0;
  props.orders.forEach((el) => (summa += Number.parseFloat(el.price)));

  return (
    <>
      <div className={classes.myorders}>
        <div className={classes.myorders2}>
          {props.orders.map((el) => (
            <Order onDelete={props.onDelete} key={el.id} item={el} />
          ))}
        </div>
      </div>
      <p className={classes.summa}>Total cost: {summa.toFixed(2)}$</p>
    </>
  );
};

const showNothing = () => {
  return (
    <div className={classes.empty}>
      <h2>There aren't any products</h2>
    </div>
  );
};

const Header = (props) => {
  let [cartOpen, setCartOpen] = useState(false);

  return (
    <div className={classes.befNav}>
      <nav>
        <div className={classes.leftHeader}>
          <div className={classes.myVinyl}>
            <Link href="#myMainBlock" className={classes.linkStylesLogo} to="*">
              <p>My</p>
              <img src={vinyl} alt="vinyllogo" className={classes.vinylLogo} />
              <p>Vinyl</p>
            </Link>
          </div>
        </div>
        <div className={classes.middleHeader}>
          <div className={classes.aboutUs}>
            <Link to="/about" className={classes.linkStylesAbout}>
              <p>About us</p>
            </Link>
          </div>
          <div className={classes.delAndPay}>
            <Link to="/deliveryAndPayment" className={classes.linkStylesAbout}>
              <p>Delivery and Payment</p>
            </Link>
          </div>
          <div className={classes.contacts}>
            <a className={classes.linkStylesAbout} href="#myFooter">
              <p>Contacts</p>
            </a>
          </div>
        </div>
        <div className={classes.rightHeader}>
          <div className={classes.icons}>
            <img
              src={bagImg}
              className={`${classes.cart} ${cartOpen && classes.active}`}
              onClick={() => setCartOpen((cartOpen = !cartOpen))}
            />
            {/*если cartOpen true */}{" "}
            {cartOpen && (
              <div className={classes.shopCart}>
                {props.orders.length > 0 ? showOrders(props) : showNothing()}
              </div>
            )}
            {props.orders.length > 0 && (
              <div className={classes.counterOrd}>{props.orders.length}</div>
            )}
          </div>
        </div>
      </nav>
    </div>
  );
};

export default Header;
