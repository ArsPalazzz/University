import React, {useState} from 'react'
import Notes from "./Notes/Notes"
import Calendar from "./Calendar/Calendar"

const checkedDaysList = []

const Scheduler = () => {//KALENDAR
    const [pickedDay, setPickedDay] = useState({})

    return (
        <>
            <Calendar pickedDay={pickedDay} setPickedDay={setPickedDay} checkedDaysList={checkedDaysList}/>
            {pickedDay.date && <Notes checkedDaysList={checkedDaysList} pickedDay={pickedDay}/>}
        </>
    )
}

export default Scheduler
