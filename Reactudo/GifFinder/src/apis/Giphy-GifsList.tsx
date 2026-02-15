import type { iGif } from '../apis/Giphy-Gif';

interface GiftProps {
  gifs: iGif[];
}

//Usamos esta estructura porque el ESLint exige esto; homogeniza la estrucutra de Typescript
export const GiftList = ( { gifs } : GiftProps ) => {
  return (
      <div className="gifs-container">
        { gifs.map( (gif) => (
              <div key={ gif.id } className="gif-card">
                <img src={ gif.url } alt={ gif.title } />
                <h3>{ gif.title }</h3>
                <p>{ gif.width } x { gif.height } ({ (gif.size / (1024*1024)).toFixed(2) } mB)</p> //bytes to megabytes conversion with 2 decimals
              </div> )
          )
        }
      </div>
  );
}