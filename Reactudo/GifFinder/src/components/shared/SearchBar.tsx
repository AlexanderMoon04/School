import { useState, useEffect } from "react";

interface SearchBarProps {
  type: string;
  placeholder?: string;
  onSearch: (request: string) => void;
}

interface PreviousSearchProps {
  terms: string[];
  onLabelClicked: (term: string) => void;
}

export const SearchBar = ( {type, placeholder = "", onSearch}: SearchBarProps ) => {
  const [request, setRequest] = useState (""); //it defines a local variable 'request' and a function 'setRequest' to update it.
//   Use state: Hook de React que permite gestionar el estado de un componente funcional
//State: valor que puede cambiar a lo largo del tiempo y que afecta la representación del componente

  
  useEffect( () => {
      const timeOutId = setTimeout( () => { onSearch(request) }, 700 );
      return clearTimeout(timeOutId);  
    }, [request, onSearch] 
  ); 

  const handleKeyDown = (event: React.KeyboardEvent) => {
    event.key === "Enter" ? finishSearch() : ""; //event.key || event.keycode
  };

  const finishSearch = () => { 
    onSearch(request); 
    setRequest(""); 
  };

  return (  
      <div className="search-container">
        <input type={ type } placeholder={ placeholder } value={ request } 
               onChange={ (event)=>setRequest(event.target.value) } 
               onKeyDown={ handleKeyDown }
        />
        <button onClick={ finishSearch }>Search</button>
      </div>
  );
}

export const PreviousSearch = ( {terms, onLabelClicked}: PreviousSearchProps ) => {
  return (  
      <div className="previous-searches">
        <h2>Previous Searches</h2>
        <ul className="previous-searches-list">
         {/* map function to iterate over terms array */}
          { terms.map( (term) => (<li key={ term } onClick={ () => onLabelClicked(term) }>{ term }</li>) ) }  
        </ul>
      </div>    
  );
}