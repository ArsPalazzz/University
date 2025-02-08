import React, {useState} from 'react';
import header_img from './img/header-img.jpg';
import ellipse from './img/Ellipse-1.png'
import Clock from './components/Clock'
import './scss/style/App.css';
import MyRoutes from './components/MyRoutes';
import Path from './components/Path';
import {Routes, Route} from "react-router-dom";
import AllInfAboutPath from './components/AllInfAboutPath';
import { NavLink } from 'react-router-dom';


// let summer = document.getElementById("summer");
// let route_yesterday = document.getElementById("route_data_yesterday");
// summer.onClick = function() {
//   route_yesterday.style.color = 'black';
// }

function App(props) {

    const theBestPlacesInTheWorld = [
      { id: 1, from: 'Минск' , to: 'Дзержинск'},
      { id: 2, from: 'Минск', to: 'Фаниполь' },
      { id: 3, from: 'Дзержинск', to: 'Минск' },
      { id: 4, from: 'Фаниполь', to: 'Минск' }
    ];

    const places = ['minskdzerjinsk', 'minskfanipol', 'dzerjinskminsk', 'fanipolminsk'];

    let date = new Date();

  return (
    <div className="body">

      <header>
        <img className="header-img" src={header_img} />
          <nav>
            <ul>
              <a href="#about_us"><li>О нас</li></a>
              <a href="#all_routs"><li>Маршруты</li></a>
              <a href="#about_us"><li>Контакты</li></a>
            </ul>
          </nav>
          <h1>Не упусти свой поезд</h1>
           <div className='container'>
            <div className="clock-1">
              <Clock cities="Париж" id="1" time="+1" />
            </div>
            <div className="clock-2">
             <Clock cities="Минск" id="2" time="+3" />
            </div>
            <div className="clock-3">
              <Clock cities="Нью-Йорк" id="3" time="-4" />
            </div>
          </div>
      </header>

    <div id="all_routs" className="content">
      <div className="available">
        <h1>Доступные маршруты</h1>
        <div className="all-routes">
          <NavLink to={'/' + places[0]}>
            <Path id={theBestPlacesInTheWorld[0].id} from={theBestPlacesInTheWorld[0].from} to={theBestPlacesInTheWorld[0].to} />
          </NavLink>
          <NavLink to={'/' + places[1]}>
            <Path id={theBestPlacesInTheWorld[1].id} from={theBestPlacesInTheWorld[1].from} to={theBestPlacesInTheWorld[1].to} />
          </NavLink>
          <NavLink to={'/' + places[2]}>
            <Path id={theBestPlacesInTheWorld[2].id} from={theBestPlacesInTheWorld[2].from} to={theBestPlacesInTheWorld[2].to} />
          </NavLink>
          <NavLink to={'/' + places[3]}>
            <Path id={theBestPlacesInTheWorld[3].id} from={theBestPlacesInTheWorld[3].from} to={theBestPlacesInTheWorld[3].to} />
          </NavLink>
        </div>
      </div>

      <div className="route-M-D">
        <Routes>
          <Route path={'/' + places[0] + '/*'} element={<h1>Минск-Дзержинск</h1>} />
          <Route path={'/' + places[1] + '/*'} element={<h1>Минск-Фаниполь</h1>} />
          <Route path={'/' + places[2] + '/*'} element={<h1>Дзержинск-Минск</h1>} />
          <Route path={'/' + places[3] + '/*'} element={<h1>Фаниполь-Минск</h1>} />
        </Routes>

        <div className="route-bar">
          <div className="route-date">
              <div id="route_data_yesterday" className="route-data-yesterday">
                <NavLink to={'/' + places[0] + '/yesterday'}><p id="summer">{30} июня (вчера)</p></NavLink>
              </div>
              <div className="route-data-today">
                <NavLink to={'/' + places[0] + '/today'}><p>{date.getDate()} июля {'('}сегодня{')'}</p></NavLink>
              </div>
              <div className="route-data-tomorrow">
                <NavLink to={'/' + places[0] + '/tomorrow'}><p>{date.getDate() + 1} июля (завтра)</p></NavLink>
              </div>
          </div>

        </div>
        <div className="route-data">
          <Routes>
            <Route path='/minskdzerjinsk/yesterday'element={MyRoutes.minskdz.yesterday.map( e => <AllInfAboutPath id={e.id} 
                                                         time = {29} month={'июня'}
                                                         time1={e.time1} place1={e.place1} 
                                                         time2={e.time2} cost={e.cost} 
                                                         time3={e.time3} place2={e.place2}/>)}/>
             <Route path='/minskdzerjinsk/today'element={MyRoutes.minskdz.today.map( e => <AllInfAboutPath id={e.id} 
                                                         time = {0} month={'июля'}
                                                         time1={e.time1} place1={e.place1} 
                                                         time2={e.time2} cost={e.cost} 
                                                         time3={e.time3} place2={e.place2}/>)}/>
             <Route path='/minskdzerjinsk/tomorrow'element={MyRoutes.minskdz.tomorrow.map( e => <AllInfAboutPath id={e.id} 
                                                         time = {1} month={'июля'}
                                                         time1={e.time1} place1={e.place1} 
                                                         time2={e.time2} cost={e.cost} 
                                                         time3={e.time3} place2={e.place2}/>)}/>
          </Routes> 
      </div>
    </div>
    </div>
    <footer>
      <h1>В проектировании веб-сайта учавствовали:</h1>
      <div className="footer-content">
        <div className="footer-name">
          <p>Вакуленчик Владислав</p>
          <p>Палазник Арсений</p>
        </div>
        <div className="footer-ellipse">
          <img src={ellipse}/>
          <img src={ellipse} />
        </div>
        <div className="footer-part">
          <p>верстка и дизайн</p>
          <p>js-developer</p>
        </div>
        <div className="footer-ellipse">
          <img src={ellipse} />
          <img src={ellipse} />
        </div>
        <div className="footer-social">
          <p>@mega.vlad0n</p>
          <p>@arspalazzz</p>
        </div>
      </div>
      <hr />
      <div id="about_us" className="footer-extra_content">
        <p>Проект создан в некоммерческих целях и разрабатывался для прохождения практики в БГТУ у Евгения Валерьевича Барковского.</p>
        <p>Copyright © 2022 Palvak Co. Limited. All rights reserved.</p>
      </div>
    </footer>

    </div>
  );
}

export default App;
