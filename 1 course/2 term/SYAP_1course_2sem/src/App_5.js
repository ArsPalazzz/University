import "./App_5.css";
import PhoneInput from 'react-phone-number-input';
import Input_email from "./components/Input_email";
import Input_password from "./components/Input_password";
import { useState } from "react";

function App() {
     const [password, setPassword] = useState("");
     const [password1, setPassword1] = useState("");
     const [value, setValue] = useState();
     function controlPassword() {
          if (password != password1) {
               return "Пароли не совпадают!";
          }
     }

     return (
          <div className='App'>
               <div className='diver'>
                    <div>
                         <h3 className='h3'>Регистрация</h3>
                    </div>

                    <div>
                         <p className='p1'>Введите Email:</p> <Input_email />
                    </div>

                    <div>
                         <p className='p1'>Введите пароль:</p>
                         <input
                              className='input_password'
                              type='password'
                              placeholder='Пароль'
                              onChange={(e) => setPassword(e.target.value)}
                         />
                    </div>
                    <div>
                         <Input_password password={password} />
                    </div>
                    <div>
                         <p className='p1'>Подтвердите пароль:</p>
                         <input
                              className='input_password1'
                              type='password'
                              placeholder='Подтвердите пароль'
                              onChange={(e) => setPassword1(e.target.value)}
                         />
                    </div>
                    <div className='paragraph'>
                         <p style={{ color: "red" }}>{controlPassword()}</p>
                    </div>
                    <div>
                         <p className='p1'>Введите фамилию:</p>
                         <input
                              className='input_password2'
                              placeholder='Фамилия'
                              type='text'
                         />
                    </div>
                    <div>
                         <p className='p1'>Введите имя:</p>
                         <input
                              className='input_password2'
                              placeholder='Имя'
                              type='text'
                         />
                    </div>
                    <div>
                         <p className='p1'>Введите отчество:</p>
                         <input
                              className='input_password2'
                              placeholder='Отчество'
                              type='text'
                         />
                    </div>
                    <div className='input_male'>
                         <p className='p1'>Выберите пол:</p>
                         <label>Мужской</label>
                         <input className='radio' name='radio' type='radio' />
                         <br></br>
                         <label>Женский</label>
                         <input className='radio' name='radio' type='radio' />
                    </div>
                    <div className='divop'>
                         <p className='p1'>Выберите дату рождения:</p>
                         <select placeholder='День'>
                              <option value='' disabled selected>
                                   День
                              </option>
                              <option>1</option>
                              <option>2</option>
                              <option>3</option>
                              <option>4</option>
                              <option>5</option>
                              <option>6</option>
                              <option>7</option>
                              <option>8</option>
                              <option>9</option>
                              <option>10</option>
                              <option>11</option>
                              <option>12</option>
                              <option>13</option>
                              <option>14</option>
                              <option>15</option>
                              <option>16</option>
                              <option>17</option>
                              <option>18</option>
                              <option>19</option>
                              <option>20</option>
                              <option>21</option>
                              <option>22</option>
                              <option>23</option>
                              <option>24</option>
                              <option>25</option>
                              <option>26</option>
                              <option>27</option>
                              <option>28</option>
                              <option>29</option>
                              <option>30</option>
                              <option>31</option>
                         </select>
                         <select>
                              <option value='' disabled selected>
                                   Месяц
                              </option>
                              <option>Январь</option>
                              <option>Февраль</option>
                              <option>Март</option>
                              <option>Апрель</option>
                              <option>Май</option>
                              <option>Июнь</option>
                              <option>Июль</option>
                              <option>Август</option>
                              <option>Сентябрь</option>
                              <option>Октябрь</option>
                              <option>Ноябрь</option>
                              <option>Декабрь</option>
                         </select>
                         <select>
                              <option value='' disabled selected>
                                   Год
                              </option>
                              <option>2000</option>
                              <option>2001</option>
                              <option>2002</option>
                              <option>2003</option>
                              <option>2004</option>
                              <option>2005</option>
                         </select>
                    </div>
                    <div>
                    <PhoneInput
                    className="phone_content"
                    placeholder="Напишите свой номер пжпж, я вам позвоню &#128527;"
                    value={value}
                    onChange={setValue}
                    />
                    </div>
                    <div>
                         <button className='btn1'>Отправить</button>
                    </div>
               </div>
          </div>
     );
}

export default App
