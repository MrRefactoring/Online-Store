$(document).ready(() => {

    $('#main').on('click', () => {
        window.location.replace("/");
    });

    $('#exit').on('click', () => {
        window.location.replace("/signout");
    });

});
