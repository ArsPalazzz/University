import Header from './components/Header';
import Footer from './components/Footer';
import classes from './App.module.scss';
import { Route, Routes } from 'react-router-dom';
import MainPage from './components/MainPage'
import AlbumBig from './components/AlbumBig';
import InfForPages from './components/InfForPages';
import React, {useState} from 'react'
import OrderPage from './components/OrderPage'



export class App extends React.Component {

  // const [orders, setItems] = useState([''])
  constructor(props) {
    super(props)
    this.state = {
      orders: []
    }

    this.addToOrder = this.addToOrder.bind(this)
    this.deleteOrder = this.deleteOrder.bind(this)
  }

  //  const setItemsB = (item) => {
  //   setItems(item)(
  //     orders = [...orders, item]
  //   )
  // };

  render() {
    return (
      <div className={classes.container}>
        <Header orders={this.state.orders} onDelete={this.deleteOrder}/>
  
        <Routes>
          <Route path='*' element={<MainPage onAdd={this.addToOrder} />} />

          <Route path='/orderPage' element={<OrderPage orders={this.state.orders}/>}/>
  
          {/* back={InfForPages.queenBohRhap.back} image1={InfForPages.queenBohRhap.image1} image2={InfForPages.queenBohRhap.image2} image3={InfForPages.queenBohRhap.image3} image4={InfForPages.queenBohRhap.image4} name={InfForPages.queenBohRhap.name} acticle={InfForPages.queenBohRhap.article} priceUSD={InfForPages.queenBohRhap.priceUSD} a1={InfForPages.queenBohRhap.a1} a2={InfForPages.queenBohRhap.a2} a3={InfForPages.queenBohRhap.a3} a4={InfForPages.queenBohRhap.a4} a5={InfForPages.queenBohRhap.a5} a6={InfForPages.queenBohRhap.a6} b1={InfForPages.queenBohRhap.b1} b2={InfForPages.queenBohRhap.b2} b3={InfForPages.queenBohRhap.b3} b4={InfForPages.queenBohRhap.b4} b5={InfForPages.queenBohRhap.b5} b6={InfForPages.queenBohRhap.b6} genre1={InfForPages.queenBohRhap.genre1} genre2={InfForPages.queenBohRhap.genre2} genre3={InfForPages.queenBohRhap.genre3} year={InfForPages.queenBohRhap.year} description={InfForPages.queenBohRhap.description} */}
          <Route path={InfForPages[0].path} element={<AlbumBig onAdd={this.addToOrder} allObj={InfForPages[0]}  />} />
          <Route path={InfForPages[1].path} element={<AlbumBig onAdd={this.addToOrder}  allObj={InfForPages[1]}/>} />
          <Route path={InfForPages[2].path} element={<AlbumBig onAdd={this.addToOrder} allObj={InfForPages[2]}  />} />
          <Route path={InfForPages[3].path} element={<AlbumBig onAdd={this.addToOrder}  allObj={InfForPages[3]}/>} />
          <Route path={InfForPages[4].path} element={<AlbumBig onAdd={this.addToOrder} allObj={InfForPages[4]}  />} />
          <Route path={InfForPages[5].path} element={<AlbumBig onAdd={this.addToOrder}  allObj={InfForPages[5]}/>} />
          <Route path={InfForPages[6].path} element={<AlbumBig onAdd={this.addToOrder} allObj={InfForPages[6]}  />} />
          <Route path={InfForPages[7].path} element={<AlbumBig onAdd={this.addToOrder}  allObj={InfForPages[7]}/>} />
          {/* back={InfForPages.scarDxxm2.back} image1={InfForPages.scarDxxm2.image1} image2={InfForPages.scarDxxm2.image2} image3={InfForPages.scarDxxm2.image3} image4={InfForPages.scarDxxm2.image4} name={InfForPages.scarDxxm2.name} acticle={InfForPages.scarDxxm2.article} priceUSD={InfForPages.scarDxxm2.priceUSD} a1={InfForPages.scarDxxm2.a1} a2={InfForPages.scarDxxm2.a2} a3={InfForPages.scarDxxm2.a3} a4={InfForPages.scarDxxm2.a4} a5={InfForPages.scarDxxm2.a5} a6={InfForPages.scarDxxm2.a6} b1={InfForPages.scarDxxm2.b1} b2={InfForPages.scarDxxm2.b2} b3={InfForPages.scarDxxm2.b3} b4={InfForPages.scarDxxm2.b4} b5={InfForPages.scarDxxm2.b5} b6={InfForPages.scarDxxm2.b6} genre1={InfForPages.scarDxxm2.genre1} genre2={InfForPages.scarDxxm2.genre2} genre3={InfForPages.scarDxxm2.genre3} year={InfForPages.scarDxxm2.year} description={InfForPages.scarDxxm2.description} */}
        </Routes>
        
        <Footer />
  
      </div>
    );
  }


  deleteOrder(id) {
    this.setState({orders: this.state.orders.filter(el => el.id !== id)})
  }
    


    addToOrder(item) {
      let isInArray = false;
      this.state.orders.forEach(el => {
        if(el.id === item.id)
          isInArray = true
      })
  
      if(!isInArray)
       this.setState({orders : [item, ...this.state.orders] })
    }
}


export default App;
