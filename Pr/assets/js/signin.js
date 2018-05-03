function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

$(document).ready(() => {

    let email = $('#email');
    let password = $('#password');

    let enter = $('#enter');

    email.on('change', () => {
        let classes = enter.attr('class').split(' ');
        if (validateEmail(email.val()) && password.val() !== ''){
            if (classes.includes('disabled')){
                enter.removeClass('disabled');
            }
        } else {
            if (!classes.includes('disabled')){
                enter.addClass('disabled');
            }
        }

        classes = email.attr('class').split(' ');
        if (email.val() !== ''){  // Если email введен
            if (validateEmail(email.val())){  // Если введенный email верный
                if (!classes.includes('valid')){  // Если valid еще не добавлен
                    email.addClass('valid');
                }
                if (classes.includes('invalid')){
                    email.removeClass('invalid');
                }
            } else {
                if (!classes.includes('invalid')){  // Если invalid еще не добавлен
                    email.addClass('invalid');
                }
                if (classes.includes('valid')){
                    email.removeClass('valid');
                }
            }
        } else {
            if (classes.includes('valid')){
                email.removeClass('valid');
            }
            if (classes.includes('invalid')){
                email.removeClass('invalid');
            }
        }

    });

    password.on('change', () => {
        let classes = enter.attr('class').split(' ');
        if (validateEmail(email.val()) && password.val() !== ''){
            if (classes.includes('disabled')){
                enter.removeClass('disabled');
            }
        } else {
            if (!classes.includes('disabled')){
                enter.addClass('disabled');
            }
        }
    });

    //$('input').characterCounter();

});