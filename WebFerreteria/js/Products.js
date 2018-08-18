function MostrarProducto(Id) {
    sessionStorage['Producto'] = Id;
}

window.onload = function Modal() {
    if (sessionStorage['Producto'] != "") {
        document.querySelector('#Producto').innerText = sessionStorage['Producto'];
    }
}