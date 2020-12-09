
var formulario = document.getElementById('InicioSesion')

formulario.addEventListener('sumbit', function (e) {
    e.preventDefault();
    console.log('lmao')

    var dt = new FormData(formulario)
    console.log(dt)
    console.log(dt.get('Correo'))
    console.log(dt.get('Pass'))
})