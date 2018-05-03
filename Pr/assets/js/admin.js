function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
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

    $('#add').on('click', () => {
        window.location.replace('/add');
    });

    $('#main').on('click', () => {
        window.location.replace('/');
    });

    $('#exit').on('click', () => {
        window.location.replace('/signout');
    });

});
