function matematicas(numero1,numero2, operacion){
   let opcion = operacion.toLowerCase();
    switch(opcion){
        case "suma":
            console.log("La suma de los numeros es: " + (numero1+numero2));
            break;
        case "resta":
            console.log("La resta de los numeros es: " + (numero1-numero2));
            break;
        case "multiplicacion":
            console.log("La multiplicacion de los numeros es: " + (numero1 * numero2));
            break;
        case "division":
         if(numero2 === 0){
            console.log("No se puede dividir por cero");
         }else{
            console.log("La division de los numeros es: " + (numero1 / numero2));
            break;
         }
         case "default":            
            console.log("Operacion no valida");
             break;
    }
}

function area(parametro1,parametro2, figura){
   let operacion = figura.toLowerCase();
   const pi = 3.1416;
   if(parametro1 <= 0 || parametro2 < 0){
    console.log("Los parametros deben ser mayores a cero");
    return;
   }
    switch(operacion){
        case "circulo":
            console.log("El area del circulo es: " + (pi * parametro1 * parametro1));
            break;
        case "cuadrado":
            console.log("El area del cuadrado es: " + (parametro1 * parametro1));
            break;
        case "triangulo":
            console.log("El area del triangulo es: " + (0.5 * parametro1 * parametro2));
            break;
         case "default":            
            console.log("Operacion no valida");
             break;
    }
}
area(-5,0,"circulo");
area(5,0,"cuadrado");
area(5,10,"triangulo");
console.log("--------------------------------------------------");
matematicas(10,5,"suma");
matematicas(10,5,"resta");
matematicas(10,5,"multiplicacion");
matematicas(10,5,"division");

