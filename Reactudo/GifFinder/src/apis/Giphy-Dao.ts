import type { iGif, iGiphyResponse } from "./Giphy-Gif";
import type { iGiphyGif } from "./Giphy-Gif";

const BASE_URL = "https://api.giphy.com/v1/gifs/search";

//Es una tarea que conviene tratar en paralelo (fetch delay)
//Aqui estamos "tipificando" el regreso de la funcion asincrona (i.e. es un objeto tipo Promise)
export const getGifsByQuery = async (request: string, limit: string, lang: string) : Promise<iGif[]> => { 
  const response = await fetch(`${BASE_URL}?api_key=${import.meta.env.VITE_GIPHY_API_KEY}&q=${request}&limit=${limit}+&lang=${lang}}`);
   
  return  (await response.json() as iGiphyResponse).data.map( (gif: iGiphyGif) => ({ //Mapper (DTO)
          id: gif.id,
          title: gif.title,
          url: gif.images.original.url,
          width: Number(gif.images.original.width),
          height: Number(gif.images.original.height),
          size: Number(gif.images.original.size)
        })
  );
}
