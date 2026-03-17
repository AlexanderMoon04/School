export const Filter = ({ search, handleSearchChange }) => {
  return (
    <div>
      Search by name: <input value={search} onChange={handleSearchChange} />
    </div>
  )
}


