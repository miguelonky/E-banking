jQuery.extend(jQuery.validator.messages, {
    required: "Debe completar este campo.",
    remote: "Please fix this field.",
    email: "Introduzca un email valido.",
    url: "Introduzca una URL valida.",
    date: "Inserte una fecha valida.",
    dateISO: "Inserte una fecha valida (ISO).",
    number: "Inserte un numero valido.",
    digits: "Introduzca solo numeros.",
    creditcard: "Introduzca un numero de tarjeta valido.",
    equalTo: "Introduzca el mismo valor nuevamente.",
    accept: "Introduzca un valor con extension valida.",
    maxlength: jQuery.validator.format("No introduzca mas de {0} caracteres."),
    minlength: jQuery.validator.format("Introduzca al menos {0} caracteres."),
    rangelength: jQuery.validator.format("Introduzca un valor entre {0} y {1} caracteres."),
    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    max: jQuery.validator.format("Introduzca un valor menor o igual a {0}."),
    min: jQuery.validator.format("Introduzca un valor igual o mayor a {0}.")
});