// Asincronias y promesas

// Sincronia 
// Se ejecuta una tarea a la vez, y en orden de cascada

// Asincronia
// Se puede trabajar con funciones que pueden ser ejecutadas en paralelo.
// por ejemplo setTimeout, setInterval, fetch, etc.
// Util para traer info de una base de datos, o hacer una consulta a una API, etc.
// La informacion se guarda en un espacio extra, y se ejecuta cuando esta lista, sin bloquear el resto del codigo.

setTimeout(() => { //funcion que se ejecuta despues de un tiempo determinado
    console.log('Hola mundo')
},2000)

setInterval(() => { //funcion que se ejecuta cada cierto tiempo, hasta que se detenga
    console.log('Hola mundo')
},2000)

clearInterval() //funcion que detiene el setInterval, se puede configurar para ser llamada tras cumplir cierta condicion

// Promesas
// Un objeto que representa un evento a futuro, lo mas comun es informacion que viene de una base de datos
// No se sabe que va a traer, pero es un evento a futuro que va a generar una respuesta



const eventoFuturo = (res) => {
   return new Promise((resolve, reject) => { //constructor de la promesa, recibe una funcion con dos parametros: resolve y reject   
      setTimeout(() => { //simulamos un evento a futuro con setTimeout
         res === true ? resolve('La promesa se cumplio') : reject('La promesa no se cumplio') //si res es true, se cumple la promesa, si es false, no se cumple
      }, 2000);
   })
}

const valor = true;


eventoFuturo(valor)
   .then((respuesta) => {
      console.log(respuesta) //si la promesa se cumple, se ejecuta el bloque de codigo dentro de then, con el valor que se retorno en resolve
   })
   .catch((respuesta) => {
      console.log(respuesta) //si la promesa no se cumple, se ejecuta el bloque de codigo dentro de catch, con el valor que se retorno en reject
   })
   .finally(() => {
      console.log('El proceso ha finalizado') //se ejecuta siempre, sin importar si la promesa se cumplio o no
   })