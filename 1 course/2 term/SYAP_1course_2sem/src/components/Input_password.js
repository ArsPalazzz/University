import zxcvbn from "zxcvbn";
import React from "react";
import "./Input_password.css";

const PasswordStrengthMeter = ({ password }) => {
     const testResult = zxcvbn(password);
     const num = (testResult.score * 250) / 4;
     console.log(testResult);

     const createPasswordlabel = () => {
          switch (testResult.score) {
               case 0:
                    return "Слишком простой";
               case 1:
                    return "Простой";
               case 2:
                    return "Средний";
               case 3:
                    return "Сложный";
               case 4:
                    return "Очень сложный";
               default:
                    return "none";
          }
     };

     const funcProgressColor = () => {
          switch (testResult.score) {
               case 0:
                    return "#828282";
               case 1:
                    return "#EA1111";
               case 2:
                    return "#FFAD00";
               case 3:
                    return "#9bc158";
               case 4:
                    return "#00b500";
               default:
                    return "none";
          }
     };

     const changePasswordColor = () => ({
          width: `${num}px`,
          background: funcProgressColor(),
          height: "7px",
     });

     return (
          <>
               <div style={{ height: "7px" }}>
                    <div className='color' style={changePasswordColor()}></div>
               </div>
               <p className='p_password' style={{ color: funcProgressColor() }}>
                    {createPasswordlabel()}
               </p>
          </>
     );
};

export default PasswordStrengthMeter;
