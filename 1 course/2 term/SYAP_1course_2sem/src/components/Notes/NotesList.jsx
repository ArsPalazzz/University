import React from "react"
import NoteItem from "./NoteItem"

const NotesList = ({notes, deleteNote, changeNote}) => {
    return (
        <div className={'notes_container'} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}>
            <h2>Notes</h2>
            {notes.map((note, index) =>
                index > 6 ?
                    <NoteItem note={note} deleteNote={deleteNote} styleClass={'noteItemRed'} key={note.id}/>
                    : <NoteItem note={note} deleteNote={deleteNote} changeNote={changeNote} styleClass={'noteItem'} key={note.id} style={{borderColor:'grey', borderRadius:'0px', marginLeft:'0px', backgroundColor:'white'}}/>
                )}
        </div>
    )
}

export default NotesList