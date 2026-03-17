import Note from './components/Note'
import { useState } from 'react'


// const App = ({notes}) => {
//   return (
//     <div>
//       <h1>Notes</h1>
//       <ul>
//         {notes.map(note =>
//           <Note key={note.id} note={note} />)}
//       </ul>
//     </div>
//   )
// }
// export default App

// import { Courses } from './components/Course'

// const App = () => {
//   const courses = [
//    {
//     id: 1,
//     name: 'Half Stack application development',
//     parts: [
//       {
//         name: 'Fundamentals of React',
//         exercises: 10,
//         id: 1
//       },
//       {
//         name: 'Using props to pass data',
//         exercises: 9,
//         id: 2
//       },
//       {
//         name: 'State of a component',
//         exercises: 14,
//         id: 3
//       },
//       {
//          name: 'Tilines of React',
//          exercises: 7,
//          id: 4
//       }
//     ]
//   },
//   {
//    id: 2,
//    name: 'Node.js',
//    parts: [
//       {
//          name: 'Routing',
//          exercises: 3,
//          id: 1
//       },
//       {
//          name: 'Middlewares',
//          exercises: 7,
//          id: 2
//       },
//       {
//          name: 'Database',
//          exercises: 7,
//          id: 3
//       }
//    ]
//   }
// ]
//   return <Courses courses={courses} />
// }
// export default App


// const App = (props) => {
//    const [notes, setNotes] = useState(props.notes)
//    const [newNote, setNewNote] = useState('a new note...')
//    const [showAll, setShowAll] = useState(true)

//    const addNote = (event) => {
//       event.preventDefault()
//       console.log('button clicked', event.target)
//       const noteObject = {
//          content: newNote,
//          important: Math.random() < 0.5,
//          id: String(notes.length + 1),
//       }
//       setNotes(notes.concat(noteObject))
//       setNewNote('')
//    }

//    const handleNoteChange = (event) => {
//       console.log(event.target.value)
//       setNewNote(event.target.value)
//    }

//    const notesToShow = showAll ? notes : notes.filter(note => note.important)

//    return (
//       <div>
//          <h1>Notes</h1>
//          <ul>
//          <div>
//             <button onClick={() => setShowAll(!showAll)}>
//                show {showAll ? 'important' : 'all'}
//             </button>
//          </div>
//             {notesToShow.map(note =>
//                <Note key={note.id} note={note} />
//             )}
//          </ul>
//          <form onSubmit={addNote}>
//             <input value={newNote} onChange={handleNoteChange}/>
//             <button type="submit">Save</button>
//          </form>
//       </div>
//    )
// }
// export default App

import { Filter } from './components/Filter'
import { AddPerson } from './components/PersonAdd'
import { Directory } from './components/PersonsList'

const App = () => {
  const [persons, setPersons] = useState([
   { name: 'Arto Hellas', number: '040-123456', id: 1 },
    { name: 'Ada Lovelace', number: '39-44-5323523', id: 2 },
    { name: 'Dan Abramov', number: '12-43-234345', id: 3 },
    { name: 'Mary Poppendieck', number: '39-23-6423122', id: 4 }
  ]) 
  const [newName, setNewName] = useState('')
  const [newNumber, setNewNumber] = useState('')
  const [search, setSearch] = useState('')

   const handleSearchChange = (event) => {
      console.log(event.target.value)
      setSearch(event.target.value)
   }

   const handleNameChange = (event) => {
   console.log(event.target.value)
   setNewName(event.target.value)
   }

   const handleNumberChange = (event) => {
   console.log(event.target.value)
   setNewNumber(event.target.value)
   }

   const addPerson = (event) => {
      event.preventDefault()
      const noteObject = {
         name: newName,
         number: newNumber,
         id: String(persons.length + 1),
      }
      if (persons.some(person => person.name === newName)) {
         alert(`${newName} is already added to phonebook`)
         setNewName('')
         return
      }
      setPersons(persons.concat(noteObject))
      setNewName('')
      setNewNumber('')
   }

   const personsToShow = search === '' ? persons : persons.filter(person => person.name.toLowerCase().includes(search.toLowerCase()))

  return (
    <div>
      <h2>Phonebook</h2>
      <Filter search={search} handleSearchChange={handleSearchChange} />

      <h2>Add a new Person</h2>
      <AddPerson newName={newName} newNumber={newNumber} handleNameChange={handleNameChange} handleNumberChange={handleNumberChange} addPerson={addPerson} />

      <h2>Directory</h2>
      <Directory personsToShow={personsToShow} />
    </div>
  )
}
export default App
