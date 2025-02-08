import React, {useEffect, useState} from 'react';

export const OperatorsButtonList = ({numberFormats, id}) => {

    const [currentFormat, setCurrentFormat] = useState(numberFormats[0])

    useEffect( () => {
        switch (id) {
            case 1:
                setCurrentFormat(numberFormats[0]);
                break;
            case 2:
                setCurrentFormat(numberFormats[1]);
                break;
            case 3:
                setCurrentFormat(numberFormats[2]);
                break;
            case 4:
                setCurrentFormat(numberFormats[3]);
                break;
            case 5:
                setCurrentFormat(numberFormats[4]);
                break;
            case 6:
                setCurrentFormat(numberFormats[5]);
                break;
            default:
                break;
        }
    }, [id, numberFormats])


    return (
        <div className="operators">
            {currentFormat.operators.map(operator => (
                <>
                <div className="operator">
                    <input defaultChecked={true}  type={"radio"} value={operator} name="operator"/>
                </div>
                    <label className="operatorLabel">{operator}</label>
                </>
            ))}
        </div>
    );
};