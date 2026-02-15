//rafc 

interface SearchBar2Props {
  type: string;
  placeholder: string;
}

export const SearchBar2 = ( {type, placeholder}: SearchBar2Props ) =>  {
   return (
     <div className="search-container">
      <p> {type} {placeholder} </p>
       <h1>SearchBar2 Component</h1>
     </div>
   );

}


export const PreviousSearchBar2 = ( {type, placeholder}: SearchBar2Props ) =>  {
   return (
     <div className="previous-search-container">
      <p> {type} {placeholder} </p>
       <h1>PreviousSearchBar2 Component</h1>
     </div>
   );
}
