import React, {useEffect, useState} from 'react';

const InputNumber = ({numbers, id, setId, ChangePhone}) => {


    const [number, setNumber] = useState(numbers[0])
    const [value, setValue] = useState("")
    const [inputStyle, setInputStyle] = useState('input');

    useEffect(() => {
        setNumber(numbers[id - 1])
    }, [id, numbers])

    const inputNumber = (e) => {
        numbers.forEach(el => {
                if (el.code.length <= value.length && el.count >= value.length)
                    if (value.slice(0, el.code.length) === el.code) {
                        setNumber(el)
                        setId(el.id)
                    }
            }
        )
        setValue(e.target.value.split(/[ \-()]/).join(""))

        if (+value.length === number.count) {
            let inputStr = value.split("");
            let maskArr = number.mask.split("");
            console.log(inputStr, maskArr)
            for (let i = 0, j = 0; i < maskArr.length; i++)
                if (maskArr[i] === "X") {
                    maskArr[i] = inputStr[j];
                    j++;
                }
            let num = maskArr.join("");
            setValue(num);
            ChangePhone(true, num);
            setInputStyle('input ValidInput')
        } else {
            ChangePhone(false);
            if (value.length === 0) {
                setInputStyle('input')
            } else {
                setInputStyle('input InvalidInput')
            }
        }

    }


    return (
        <div className="inputWrapper">
            <input className={inputStyle} type="tel" id="phone" name="phone"
                   placeholder={number.code + number.mask.slice(4)}
                   required onInput={inputNumber} maxLength={number.count + 3}
                   value={value}/>

        </div>
    );
};

export default InputNumber;