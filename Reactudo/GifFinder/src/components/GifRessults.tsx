
interface GifRessultsProps {
   type?: string;
   placeholder?: string;
}

export const GifRessults2 = ( {type, placeholder}: GifRessultsProps ) => {
  return (
    <div>GifRessults {type} {placeholder}</div>
  )
}
