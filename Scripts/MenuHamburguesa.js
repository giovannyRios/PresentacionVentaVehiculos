const iconoMenu = document.querySelector('#icono-menu'),
    menu = document.querySelector('#menu'),
    cuerpo = document.querySelector('#contenedor');

iconoMenu.addEventListener('click', e => {

    menu.classList.toggle('active');
    cuerpo.classList.toggle('opacity');

    const rutaActual = e.target.getAttribute('src');
    if (rutaActual == '~/Content/Images/open-menu.png') {
        e.target.setAttribute('src', '~/Content/Images/open-menu2.png');
    } else {
        e.target.setAttribute('src', '~/Content/Images/open-menu2.png');
    }

});