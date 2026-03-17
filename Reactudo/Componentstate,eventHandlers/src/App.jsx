import { useState } from 'react' // Importing useState hook from React


// const Hello = ({ name, age }) => { // Destructuring props

//    const bornYear = () => new Date().getFullYear() - age

//    return(
//       <>
//          <p>
//             Hello {name}!, you are {age} years old.
//          </p>
//          <p>So you were probably born in {bornYear()}</p>
//       </>
//    )
// }

// const App = () => {
//    const name = 'John China'
//    const age = 344

//    return(
//       <>
//          <h1>Greetings</h1>
//          <Hello name="Yomero" age={30+15}/>
//          <Hello name={name} age={age}/>
//       </>
//    )
// }

// export default App

//------------------------------------------------------------------------------------------------------

// import { useState } from 'react' // Importing useState hook from React

// const Display = ({ counter }) => <div>{counter}</div>

// const Button = ({onClick, text}) => <button onClick={onClick}>{text}</button>

// const App = () => {

//   const [ counter, setCounter ] = useState(0)

//   console.log('rendering...', counter)

//   return (
//    <>
//       <Display counter={counter} />
//       <Button onClick={() => setCounter(counter + 1)} text="Plus ultra madafaka" />
//       <Button onClick={() => setCounter(counter - 1)} text="Minus ultra madafaka" />
//       <Button onClick={() => setCounter(0)} text="Zero" />
//    </>
//   )
// }

// export default App

//  import { useState } from 'react' // Importing useState hook from React

// const App = () => {
//    const [clicks, setClicks] = useState({
//       left: 0, right: 0
//    })
//    //a state update in React happens asynchronously,
//    //  so the new state value is not immediately available after calling the state update function.
//    const handleLeftClick = () => 
//       setClicks({ ...clicks, left: clicks.left+1})

//    const handleRightClick = () => 
//       setClicks ({ ...clicks, right: clicks.right+1})
//    //It is forbidden to mutate the state directly, 
//    // so we create a new object with the spread operator and update the specific property we want to change.
//    return(
//       <>
//          {clicks.left}
//          <button onClick={handleLeftClick}>Left</button>
//          <button onClick={handleRightClick}>Right</button>
//          {clicks.right}
//       </>
//    )
// }
// export default App


// const History = (props) => {
//    if (props.allClicks.length === 0) {
//       return (
//          <div>
//             the app is used by pressing the buttons
//          </div>
//       )
//    }
//    return (
//       <div>
//          button press history: {props.allClicks.join(' ')}
//       </div>
//    )
// }

// const Button = ({ onClick, text}) => <button onClick={onClick}>{text}</button>

// const App = () =>{
//    const [left, setLeft] = useState(0)
//    const [right, setRight] = useState(0)
//    const [allClicks, setAll] = useState([])

//    const handleLeftClick = () => {
//       setAll(allClicks.concat('L'))
//       setLeft(left + 1)
//    }

//    const handleRightClick = () => {
//       setAll(allClicks.concat('R'))
//       setRight(right + 1)
//    }

//    return(
//    <div>
//       {left}
//       <Button onClick={handleLeftClick} text='left' />
//       <Button onClick={handleRightClick} text='right' />
//       {right}
//       <History allClicks={allClicks} />
//    </div>
//    )
// }
// export default App 

// const App =() => {
//    const [value, setValue] = useState(10)

//    const hello = (who) => () => {
//       console.log('hello', who)
//    }

//    const setToValue = (newValue) => () => {
//       console.log('value now', newValue)
//       setValue(newValue)
//    }

//    return (
//       <>
//       {value}
//       <button onClick={hello('world')}>Hello</button>
//       <button onClick={hello('tilin')}>Hello</button>
//       <button onClick={hello('react')}>Hello</button>
//       <button onClick={setToValue(1500)}>Thousand</button>
//       <button onClick={setToValue(0)}>Reset</button>
//       <button onClick={setToValue(value + 1)}>Increment</button>
//       </>
//    )
// }
// export default App

// const Button = ({ onClick, text }) => <button onClick={onClick}>{text}</button>

// const StaticLine = ({ text, value }) => (
//    <tr>
//       <td>{text}</td>
//       <td>{value}</td>
//    </tr>
// )

// const Statistics = ({ good, neutral, bad }) => {
//    const total = good + neutral + bad
//    const average = (good - bad) / total
//    const positive = (good / total) * 100

//    if (total === 0) {
//       return <div>No feedback given</div>
//    }
//    return (
//       <table>
//          <tbody>
//             <StaticLine text="Good" value={good} />
//             <StaticLine text="Neutral" value={neutral} />
//             <StaticLine text="Bad" value={bad} />
//             <StaticLine text="Total" value={total} />
//             <StaticLine text="Average" value={average.toFixed(2)} />
//             <StaticLine text="Positive" value={`${positive.toFixed(2)}%`} />
//          </tbody>
//       </table>
//    )
// }


// const App = () => {
//    //save clicks of each button to its own state
//    const [good, setGood] = useState(0)
//    const [neutral, setNeutral] = useState(0)
//    const [bad, setBad] = useState(0)

//    const handleGoodClick = () => setGood(good + 1)
//    const handleNeutralClick = () => setNeutral(neutral + 1)
//    const handleBadClick = () => setBad(bad + 1)

//    return(
//       <>
//       <h1>Give feedback</h1>
//       <Button onClick={handleGoodClick} text='good' />
//       <Button onClick={handleNeutralClick} text='neutral' />
//       <Button onClick={handleBadClick} text='bad' />

//       <h1>Statistics</h1>
//       <Statistics good={good} neutral={neutral} bad={bad} />
//       </>
//    )
// }
// export default App

const Button = ({ onClick, text }) => <button onClick={onClick}>{text}</button>

const App = () => {
  const anecdotes = [
    'If it hurts, do it more often.',
    'Adding manpower to a late software project makes it later!',
    'The first 90 percent of the code accounts for the first 90 percent of the development time...The remaining 10 percent of the code accounts for the other 90 percent of the development time.',
    'Any fool can write code that a computer can understand. Good programmers write code that humans can understand.',
    'Premature optimization is the root of all evil.',
    'Debugging is twice as hard as writing the code in the first place. Therefore, if you write the code as cleverly as possible, you are, by definition, not smart enough to debug it.',
    'Programming without an extremely heavy use of console.log is same as if a doctor would refuse to use x-rays or blood tests when diagnosing patients.',
    'The only way to go fast, is to go well.'
  ]

  const randomAnecdote = () => Math.floor(Math.random() * anecdotes.length)
   
  const [selected, setSelected] = useState(0)
  const [votes, setVotes] = useState(Array(anecdotes.length).fill(0))

  const handleVote = () => {
      const votesCopy = [...votes]
      votesCopy[selected] += 1
      setVotes(votesCopy)
  }

  return (
    <div>
      <h1>Anecdote of the day</h1>
      {anecdotes[selected]}
      <div>
         has {votes[selected]} votes
      </div>
      <Button onClick={handleVote} text='Vote' />
      <Button onClick={() => setSelected(randomAnecdote())} text='Next Anecdote' />
      <h1>Most voted anecdote</h1>

      {/* finds the anecdote with the most votes through the index*/}
      {anecdotes[votes.indexOf(Math.max(...votes))]} 
      <div>has {Math.max(...votes)} votes</div>

    </div>
  )
}

export default App