import React, {useEffect, useState} from 'react'
import NotesList from "./NotesList"

import './style/Notes.css'

let currentSchedule = {}

const Notes = ({checkedDaysList, pickedDay}) => {
    const [notes, setNotes] = useState([])
    const [note, setNote] = useState({title: '', text: ''})
    const [warning, setWarning] = useState('')

    useEffect(() => {
        currentSchedule = {day: pickedDay.date, notes: []}

        for (let i = 0; i < checkedDaysList.length; i++)
            if (checkedDaysList[i].day.getTime() === currentSchedule.day.getTime()) {
                currentSchedule.notes = checkedDaysList[i].notes
                checkedDaysList.splice(i, 1)
            }

        checkedDaysList.push(currentSchedule)

        for (let i = 0; i < checkedDaysList.length; i++)
            if (checkedDaysList[i].day.getTime() === pickedDay.date.getTime())
                setNotes(checkedDaysList[i].notes)
    }, [pickedDay])

    useEffect(() => {
        currentSchedule.notes = notes
    }, [notes])

    const addNewNote = (e) => {
        e.preventDefault()
        if (note.title === '')
            alert('Input note title!')
        else {
            setNotes([...notes, {...note, id: Date.now()}])
            setNote({title: '', text: ''})
        }
    }

    const deleteAll = (e) => {
        e.preventDefault()
        setNotes([])
    }

    const deleteNote = (noteItem) => {
        setNotes(notes.filter((n) => n.id !== noteItem.id))
    }

    // мб можно сделать решение лучше, но мне лень
    const changeNote = (noteItem) => {
        for (let i=0; i<notes.length; i++)
            if(notes[i].id === noteItem.id) {
                let copy = notes.slice()
                copy[i] = {...note, id: Date.now()}
                setNotes(copy)
            }
        setNote({title: '', text: ''})
    }

    useEffect(() => {
        if (notes.length < 8) setWarning('')
        else setWarning('you have a lot of notes')
    }, [notes])

    return (
        <>
            <form className={'noteForm'} style={{margin:'0px', backgroundColor:'white', width:'210px'}}>
                <h2>Notes for {pickedDay.date && pickedDay.date.toLocaleDateString()}</h2>
                <h3 style={{color: 'red'}}>{warning}</h3>
                <input style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', width:'210px'}}
                    className={'noteInput'}
                    type="text"
                    placeholder={'Note'}
                    value={note.title}
                    onChange={e => setNote({...note, title: e.target.value})}
                />
                <input style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', width:'210px'}}
                    className={'noteInput'}
                    type="text"
                    placeholder={'Description'}
                    value={note.text}
                    onChange={e => setNote({...note, text: e.target.value})}
                />
                <button className={'noteBtn'} onClick={addNewNote} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}>New note</button>
                <button className={'noteBtn'} onClick={deleteAll} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}>Delete all</button>
            </form>
            <br/>
            {notes.length !== 0 && <NotesList notes={notes} deleteNote={deleteNote} changeNote={changeNote}/>}
        </>

    )
}

export default Notes