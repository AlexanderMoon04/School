//interface for props
//Create common structures 
//Rules structure to interact with the component
//In react, props are forced to work in a specific way
//Typescript interacts here
interface HeaderProps { //declared as an object
  title: string;
  description?: string; //optional prop
}
// Props destructuring, get their parts directly in the function parameters
// The function is typed with the interface
export const Header = ({ title, description }: HeaderProps) => {
  return ( //A block with title and description is retourned when the component is used
   <div className = "content-center">
      <h1>{title}</h1>
      {description != null ? <p>{description}</p> : ""}
   </div>
  );
}