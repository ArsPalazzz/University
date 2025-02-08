const CalendarHead = ({ currentMonth, currentYear, handlePrevClick, handleNextClick }) => {
	const daysShorts = ['ПН', 'ВТ', 'СР', 'ЧТ', 'ПТ', 'СБ', 'ВС']
    const monthsNames = [
        'Январь',
        'Февраль',
        'Март',
        'Апрель',
        'Май',
        'Июнь',
        'Июль',
        'Август',
        'Сентябрь',
        'Октябрь',
        'Ноябрь',
        'Декабрь',
    ]

    return (
        <>
            <div className={'calHead'}>
                <div className={'month'}>{monthsNames[currentMonth]}</div>
                <div className={'year'}>{currentYear}</div> 
                <div className={'cell'} onClick={handlePrevClick}>{'<'}</div>
                <div className={'cell'} onClick={handleNextClick}>{'>'}</div>
                {
                    daysShorts.map((element, index) => {
                        return <div key={index} className={'cell'}>{element}</div>
                    })
                }
            </div>
        </>
    )
}

export default CalendarHead
