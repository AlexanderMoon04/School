type CoursePart = {
   part: string;
   exercises: number;
};

type HeaderProps = {
   course: string;
};

const Header = ({ course }: HeaderProps) => {
   return <h1>{course}</h1>;
};

type ContentProps = {
   parts: CoursePart[];
};

const Content = ({ parts }: ContentProps) => {
   return (
      <div>
         <Part part={parts[0].part} exercises={parts[0].exercises} />
         <Part part={parts[1].part} exercises={parts[1].exercises} />
         <Part part={parts[2].part} exercises={parts[2].exercises} />
      </div>
   );
};

type TotalProps = {
   parts: CoursePart[];
};

const Total = ({ parts }: TotalProps) => {
   return (
      <p>
         Number of exercises {parts[0].exercises + parts[1].exercises + parts[2].exercises}
      </p>
   );
};

type PartProps = {
   part: string;
   exercises: number;
};

const Part = ({ part, exercises }: PartProps) => {
   return (
      <p>
         {part} {exercises}
      </p>
   );
};

const App = () => {
   const course = 'Half stack application development';
   const parts: CoursePart[] = [
      {
         part: 'Fundamentals of React',
         exercises: 10,
      },
      {
         part: 'Using props to pass data',
         exercises: 7,
      },
      {
         part: 'State of a component',
         exercises: 14,
      },
   ];

   return (
      <div>
         <Header course={course} />
         <Content parts={parts} />
         <Total parts={parts} />
      </div>
   );
};

export default App;