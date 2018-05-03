$(document).ready(() => {

    $('#back').on('click', () => {
        window.location.replace('/admin');
    });

    let price = $('#price');

    price.on('keyup', () => {
        price.val(price.val().replace(/[^0-9]+/g, ''))
    });
    
});