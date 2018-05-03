function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

$(document).ready(() => {

    let name = $('#name');
    let lastName = $('#last_name');
    let userName = $('#username');

    let email = $('#email');
    let phone = $('#phone');

    let password = $('#password');
    let passwordRepeat = $('#password_repeat');

    let send = $('#send');

    function check(){
        if (
            name.val() !== '' &&
            lastName.val() !== '' &&
            userName.val() !== '' &&
            phone.val().length === 11 &&
            validateEmail(email.val()) &&
            password.val() !== '' &&
            passwordRepeat.val() !== '' &&
            password.val() === passwordRepeat.val()
        ){
            if (send.attr('class').split(' ').includes('disabled'))
                send.removeClass('disabled');
        } else {
            if (!send.attr('class').split(' ').includes('disabled'))
                send.addClass('disabled');
        }
    }

    name.on('change', check);
    lastName.on('change', check);
    userName.on('change', check);
    phone.on('change', check);
    email.on('change', check);
    password.on('change', check);
    passwordRepeat.on('change', check);

    email.on('keyup', () => {
        let classes = email.attr('class').split(' ');
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

    email.on('change', () => {
        let classes = email.attr('class').split(' ');
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

    phone.on('keyup', () => {
        phone.val(phone.val().replace(/[^0-9]+/g, ''));
        if (phone.val().length > 11){
            phone.val(phone.val().slice(0, 11))
        }
    });

    password.on('keyup', () => {
        if (password.val() !== ''){  // Если поле password заполнено
            if (passwordRepeat.val() === password.val()){  //  Если значение полей одинаково
                password.removeClass('invalid');
                passwordRepeat.removeClass('invalid');
                password.addClass('valid');
                passwordRepeat.addClass('valid');
            } else {
                password.removeClass('valid');
                passwordRepeat.removeClass('valid');
                password.addClass('invalid');
                passwordRepeat.addClass('invalid');
            }
        }
    });

    passwordRepeat.on('keyup', () => {
        if (password.val() !== ''){  // Если поле password заполнено
            if (passwordRepeat.val() === password.val()){  //  Если значение полей одинаково
                password.removeClass('invalid');
                passwordRepeat.removeClass('invalid');
                password.addClass('valid');
                passwordRepeat.addClass('valid');
            } else {
                password.removeClass('valid');
                passwordRepeat.removeClass('valid');
                password.addClass('invalid');
                passwordRepeat.addClass('invalid');
            }
        }
    });

    $('input').characterCounter();

});