import Header from "./components/Header";
import Footer from "./components/Footer";
import classes from "./App.module.scss";
import { Route, Routes } from "react-router-dom";
import MainPage from "./components/MainPage";
import AlbumBig from "./components/AlbumBig";
import InfForPages from "./components/InfForPages";
import React, { useState } from "react";
import OrderPage from "./components/OrderPage";
import AboutUs from "./components/AboutUs";
import DeliveryAndPayment from "./components/DeliveryAndPayment";
import Catalog from "./components/Catalog";

export class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      orders: [],
    };

    this.addToOrder = this.addToOrder.bind(this);
    this.deleteOrder = this.deleteOrder.bind(this);
  }

  render() {
    return (
      <div className={classes.container}>
        <Header orders={this.state.orders} onDelete={this.deleteOrder} />

        <Routes>
          <Route path="*" element={<MainPage onAdd={this.addToOrder} />} />

          <Route path="/about" element={<AboutUs />} />
          <Route path="/deliveryAndPayment" element={<DeliveryAndPayment />} />

          <Route
            path="/orderPage"
            element={<OrderPage orders={this.state.orders} />}
          />

          {InfForPages.map((el, index) => (
            <Route
              key={index}
              path={el.path}
              element={<AlbumBig onAdd={this.addToOrder} allObj={el} />}
            />
          ))}

          <Route
            path="/catalog"
            element={<Catalog onAdd={this.addToOrder} />}
          />
        </Routes>
        <Footer />
      </div>
    );
  }

  deleteOrder(id) {
    this.setState({ orders: this.state.orders.filter((el) => el.id !== id) });
  }

  addToOrder(item) {
    let isInArray = false;
    this.state.orders.forEach((el) => {
      if (el.id === item.id) isInArray = true;
    });

    if (!isInArray) this.setState({ orders: [item, ...this.state.orders] });
  }
}

export default App;
