import header_img from '../img/header-img.jpg';
import clock_1 from '../img/clock-1.png'
import clock_2 from '../img/clock-2.png'
import ellipse from '../img/Ellipse-1.png'
import '../scss/style/App.css';

function App() {
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
          <img className="clocks" src={clock_1} />
          <img className="clocks-2" src={clock_2} />
          <img className="clocks-3" src={clock_2} />
      </header>

    <div id="all_routs" className="content">
      <div className="available">
        <h1>Доступные маршруты</h1>
        <div className="all-routes">
        <a href="App.js">
          <div className="route-1">
            <p>
              Минск -&gt;
            </p>
            <p>
              Дзержинск
            </p>
          </div>
          </a>
          <a href="#route-M-F">
            <div className="route-1 first-route">
            <p>
              Минск -&gt;
            </p>
            <p>
              Фаниполь
            </p>
          </div>
          </a>
          <a href="D-M.js">
          <div className="route-1">
            <p>
              Дзержинск -&gt;
            </p>
            <p>
              Минск
            </p>
          </div>
          </a>
          <a href="F-M.js">
          <div className="route-1">
            <p>
              Фаниполь -&gt;
            </p>
            <p>
              Минск
            </p>
          </div>
          </a>
        </div>
      </div>

      <div id="route-M-F" className="route-M-D">
        <h1>Маршрут: Минск-Дзержинск</h1>

        <div className="route-bar">
          <div className="route-date">
              <div className="route-data-yesterday">
                <p>23 июня (вчера)</p>
              </div>
              <div className="route-data-today">
                <p>24 июня {'('}сегодня{')'}</p>
              </div>
              <div className="route-data-tomorrow">
                <p>25 июня (завтра)</p>
              </div>
          </div>
          <div className="sorting">
            <h1>Сортировка:</h1>
            <p>Время отправки</p>
            <p>Время поездки</p>
          </div>
        </div>

        <div className="route-data">
          <div className="route-1">
              <div className="data-1">
                <p>9:39</p>
                <p>Минск (Институт Культуры)</p>
              </div>
              <div className="data-2">
                <p>51 минута</p>
                <p>1.25р</p>
              </div>
              <div className="data-3">
                <p>10:30</p>
                <p>Фаниполь</p>
              </div>
          </div>
          <div className="route-1">
              <div className="data-1">
                <p>12:03</p>
                <p>Минск (Институт Культуры)</p>
              </div>
              <div className="data-2">
                <p>51 минута</p>
                <p>1.25р</p>
              </div>
              <div className="data-3">
                <p>12:54</p>
                <p>Дзержинск</p>
              </div>
          </div>
          <div className="route-1">
              <div className="data-1">
                <p>17:05</p>
                <p>Минск (Институт Культуры)</p>
              </div>
              <div className="data-2">
                <p>52 минуты</p>
                <p>1.25р</p>
              </div>
              <div className="data-3">
                <p>17:57</p>
                <p>Дзержинск</p>
              </div>
          </div>
          <div className="route-1">
              <div className="data-1">
                <p>19:58</p>
                <p>Минск (Минск-Пассажирский)</p>
              </div>
              <div className="data-2">
                <p>1ч 10мин</p>
                <p>1.25р</p>
              </div>
              <div className="data-3">
                <p>20:56</p>
                <p>Дзержинск</p>
              </div>
          </div>
          <div className="route-1">
              <div className="data-1">
                <p>21:46</p>
                <p>Минск (Минск-Пассажирский)</p>
              </div>
              <div className="data-2">
                <p>53 минуты</p>
                <p>1.25р</p>
              </div>
              <div className="data-3">
                <p>22:39</p>
                <p>Дзержинск</p>
              </div>
          </div>
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
