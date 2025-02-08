import React, { useState } from "react";
import validator from "validator";
import "./Input_email.css";

export default function Input_email() {
     const [emailError, setEmailError] = useState("");
     const validateEmail = (e) => {
          var email = e.target.value;

          if (validator.isEmail(email)) {
               setEmailError("");
          } else {
               setEmailError("Ваш Email некорректен!");
          }
     };

     return (
          <div>
               <div>
                    <input
                         type='text'
                         id='userEmail'
                         placeholder='Email'
                         onChange={(e) => validateEmail(e)}></input>
               </div>

               <div>
                    <span
                         className='span_email'
                         style={{
                              color: "red",
                         }}>
                         {emailError}
                    </span>
               </div>
          </div>
     );
}
