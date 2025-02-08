import React from "react"

const NoteItem = ({note, styleClass, deleteNote, changeNote}) => {
    return (
        <div className={styleClass}>
            <div className={'titleNote'}>{note.title}</div>
            <div className={'textNote'}>{note.text}</div>
            <button className={'noteItemBtn'} onClick={() => deleteNote(note)} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}>Delete</button>
            <button className={'noteItemBtn'} onClick={() => changeNote(note)} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}>Change</button>
        </div>
    )
}

export default NoteItem