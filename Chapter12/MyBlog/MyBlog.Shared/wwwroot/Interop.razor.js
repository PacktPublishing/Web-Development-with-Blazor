export function sayHello (dotnetHelper) {
    return dotnetHelper.invokeMethodAsync('SayHello')
        .then(r => console.log(r));
}