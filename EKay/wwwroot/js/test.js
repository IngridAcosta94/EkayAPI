const url = "https://localhost:44321/api/empresa/"
const test = "https://pokeapi.co/api/v2/pokemon/1"
var Test = document.querySelector('#test')
fetch(url)
    .then(res => res.json()) //get
    .then(data => {
        console.log(data)  //mostrar en la consola

        //mostrar en la pagina
        Test.innerHTML = `
            <p>${data.data[0].nombre}</p >
            <p>${data.data[0].correo}</p >
            <p>${data.data[0].direccion}</p >
            <p>${data.data[0].id}</p >
            <p>${data.data[0].nombreRepresentante}</p >
            <p>${data.data[0].telefono}</p >
        `

    })
    