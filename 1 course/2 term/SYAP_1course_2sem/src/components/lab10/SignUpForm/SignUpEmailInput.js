import {useState} from "react";
import PropTypes from "prop-types";
import React from "react";

export function SignUpEmailInput({IsEmailValid}) {

    const [email, setEmail] = useState('');
    const [isEmailValid, setIsEmailValid] = useState(false);
    const [EmailInputStyle, setEmailInputStyle] = useState("");

    const changeEmail = (event) => {
        const inputText = event.target.value;
        setEmail(event.text);

        let check = /\S+@\S+\.\S+/;

        let isValid = check.test(inputText);

        if (isValid !== isEmailValid) {
            setIsEmailValid(isValid);
            IsEmailValid(isValid,inputText);
        }
        if (isValid) {
            setEmailInputStyle("ValidInput");
        } else {
            if (inputText.length === 0) setEmailInputStyle("");
            else setEmailInputStyle("InvalidInput");
        }
    }

    return (
        <div className="formField email">
            <label htmlFor="email">Email</label>
            <input type="email" onChange={changeEmail} className={EmailInputStyle} id="email" placeholder="Email"/>
        </div>
    );
}
SignUpEmailInput.propTypes = {
    IsEmailValid: PropTypes.func.isRequired //PropTypes экспортирует ряд валидаторов, исп для того, чтобы убедиться, что входные данные, корректные (совпадают типу).
};