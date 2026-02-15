import { useState } from "react";
import { GiftList } from "../apis/Giphy-GifsList.tsx";
import { Header } from "./shared/Header.tsx"; 
import { SearchBar, PreviousSearch } from "./shared/SearchBar.tsx";
import { getGifsByQuery } from "../apis/Giphy-Dao.ts";
import type { iGif } from "../apis/Giphy-Gif.ts";

   export const GifsApp = () => {  
  const [gifs, setGifs] = useState<iGif[]>([]); //line 9 to 22 is the project's heart
  const [previousTerms, setPreviousTerms] = useState<string[]>([]); //String array searched by user

  const handleTermClicked = (request: string) => {
    console.log({ request });
  }

  const handleSearch = async(request: string = "") => {
    request = request.trim().toLocaleLowerCase();
      
   //Arrays manipulation
    if ( (request.length === 0) || previousTerms.includes(request) ) { }
    else { setPreviousTerms([request, ...previousTerms.slice(0,7)]);  //Spread operator to limit to 8 items ... list the array
          setGifs(await getGifsByQuery(request, "10", "en"));
    } 
  }

  return ( 
    <> 
      {/* Header */}
      <Header title="Gif Finder" description="Discover and share Gifs" />

      {/* Search */} 
      <SearchBar type="text" placeholder="Search gifs" onSearch={ (request) => handleSearch(request) } />

      {/* Busquedas previas */}
      <PreviousSearch terms={ previousTerms } onLabelClicked={ (request) => handleTermClicked(request) } />
      {/* <PreviousSearchBar2 type="text" placeholder="Example 2" /> */}

      {/* Gifs results*/} 
      <GiftList gifs={ gifs } />
    </>
  );
}