function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
}

function eventFire(el, etype){
    if (el.fireEvent) {
        el.fireEvent('on' + etype);
    } else {
        let evObj = document.createEvent('Events');
        evObj.initEvent(etype, true, false);
        el.dispatchEvent(evObj);
    }
}

$(document).ready(() => {

    let carouselArray = $('.carousel.carousel-slider');

    for (let i = 0; i < carouselArray.length; i++){
        let carousel = $(carouselArray[i]);

        carousel.carousel({
            fullWidth: true,
            indicators: true,
            duration: 300
        });

        let instance = M.Carousel.getInstance(carousel);

        setInterval(() => {
            instance.next();
        }, getRandomArbitrary(3000, 4000))

    }

    $('#main').on('click', () => {
        window.location.replace('/');
    });

    $('#exit').on('click', () => {
        window.location.replace('/signout');
    });

    $('.moto').on('click', () => {
        window.location.replace('/payment');
    });

    $('.d').on('click', (e) => {
        $('#field').val(e.currentTarget.attributes[0].value);
        eventFire(document.getElementById('delete'), 'click');
    });

});
