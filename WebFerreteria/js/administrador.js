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
}

showPanel(0);