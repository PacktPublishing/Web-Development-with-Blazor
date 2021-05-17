export function sayHello (hellohelperref) {
    return hellohelperref.invokeMethodAsync('SayHello')
        .then(r => console.log(r));
}