export const Courses = ({ courses }) => {
  return (
    <>
      {courses.map(course => {
        const courseTotal = course.parts.reduce((sum, part) => sum + part.exercises,0
        );

        return (
          <li key={course.id}>
            <h1>{course.name}</h1>

            <ul>
              {course.parts.map(part => (
                <li key={part.id}>
                  {part.name} {part.exercises}
                </li>
              ))}
            </ul>

            <p>Total exercises: {courseTotal}</p>
          </li>
        );
      })}
    </>
  )
}
