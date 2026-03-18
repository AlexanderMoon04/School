const baseDeDatos=[
   {id: "silla", nombre: "Silla", precio: 1000},
   {id: "mesa", nombre: "Mesa", precio: 2000},
   {id: "lámpara", nombre: "Lámpara", precio: 500},
   {id: "sofá", nombre: "Sofá", precio: 3000},
];

const pedirProductos =() => {
   return new Promise((resolve, reject) => {
      setTimeout(() => {
         resolve(baseDeDatos)
      }, 2000);
   })
}

let productos = [];
const lista = document.querySelector('#lista-productos')

function mostrarProductos(array) {
   array.forEach(item => {
      const li = document.createElement('li')
      li.textContent = `${item.nombre} - $${item.precio}`
      lista.appendChild(li)
   })
}
