import React, {useState} from "react";
import PhoneInput from 'react-phone-number-input';


const Form = () => {
    const [value, setValue] = useState();
    return (
        <div className="content">
            <h1>ВВЕДИТЕ ТЕКСТ ВВЕДИТЕ ТЕКСТ ВВЕДИТЕ ТЕКСТ ВВЕДИТЕ ТЕКСТ ВВЕДИТЕ ТЕКСТ ВВЕДИТЕ ТЕК</h1>
        <form>
                <h2>Регистрация постоянного клиента</h2>
                <hr/>
            <div className="text_field">
                <label for="sur">Фамилия:</label><input id="sur" type="text" />
            </div>
            <div className="text_field">
                <label for="name">Имя:</label><input id="name" type="text" />
            </div>
            <div>
                <label for="male">Пол:</label>
                <input type="radio" name="dot" id="male" /><p>Мужской</p>
                <input type="radio" name="dot" id="male" /><p>Женский</p>
            </div>
            <div className="mobile_field">
                <label for="country">Ваш номер:</label>
                <section className="phone">
                    <PhoneInput
                    className="phone_content"
                    placeholder="Напишите свой номер пжпж, я вам позвоню &#128527;"
                    value={value}
                    onChange={setValue}
                    />
                </section>
            </div>
            <div>
                <label for="select">Откуда вы о нас узнали?</label>
                    <select id="select">
                        <option>Случайная реклама</option>
                        <option>Брошюра на остановке</option>
                        <option>Рассказали знакомые</option>
                        <option>Случайно узнал</option>
                    </select>
            </div>
            <div className="buttons">
                    <input type="submit" value="Регистрация" className="button1" />
                    <input type="submit" value="Отмена" />   
            </div>
        </form>
        </div>
    );
};

export default Form