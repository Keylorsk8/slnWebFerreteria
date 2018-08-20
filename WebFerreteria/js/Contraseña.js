function ModificarContra(){
    if (document.getElementById('txtContraseña').value == document.getElementById('txtContraseña2').value) {
        alert('Contraseña Modificada, presione Guardar para conservar los cambios')
    } else {
        alert('Las contraseñas no coinciden,Intentelo de nuevo')
    }
}