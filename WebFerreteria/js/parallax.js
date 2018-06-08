window.onload = function () {
    document.onmousemove = function (ev) {
        var x = -ev.clientX / 50;
        var y = -ev.clientY / 50;

        document.getElementById("ImageInicio").style.backgroundPosition = x + 'px ' + y + 'px';
    };
};