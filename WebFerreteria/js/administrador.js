var tabButtons = document.querySelectorAll(".tabsContainer .btnContainer a");
var tabPanels = document.querySelectorAll(".tabsContainer .tabPanel");

function showPanel(panelIndex) {
    tabButtons.forEach(function (node) {
        node.style.backgroundColor = "";
        node.style.color = "";
    });
    tabButtons[panelIndex].style.backgroundColor = 'seagreen';
    tabButtons[panelIndex].style.color = "white";
    tabPanels.forEach(function (node) {
        node.style.display = "none";
    });
    tabPanels[panelIndex].style.display = "block";
    tabPanels[panelIndex].style.backgroundColor = 'white';
    tabPanels[panelIndex].style.color = "black";
    if (panelIndex == 2) {
        document.getElementById('txtNombreProducto').removeAttribute('required');
        document.getElementById('txtDescripcionProducto').removeAttribute('required');
        document.getElementById('cmbCategoria').removeAttribute('required');
        document.getElementById('fluImagen').removeAttribute('required');
        document.getElementById('NudPrecio').removeAttribute('required');
        document.getElementById('NudPrecio').removeAttribute('required');
        document.getElementById('txtNombre').setAttribute('required');
        document.getElementById('txtDescripcion').setAttribute('required');
    }
    if (panelIndex == 1) {
        document.getElementById('txtNombreProducto').setAttribute('required');
        document.getElementById('txtDescripcionProducto').setAttribute('required');
        //document.getElementById('cmbCategoria').setAttribute('required');
        document.getElementById('fluImagen').setAttribute('required');
        document.getElementById('NudPrecio').setAttribute('required');
        document.getElementById('NudPrecio').setAttribute('required');
        document.getElementById('txtNombre').removeAttribute('required');
        document.getElementById('txtDescripcion').removeAttribute('required');
    }
}

showPanel(0);