<%@ Page Language="C#" Inherits="Pr.assets.pages.SignUp" AutoEventWireup="True" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
	<title>Регистрация</title>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css">
    <link rel="stylesheet" href="../css/signup.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script src="assets/js/signup.js"></script>
        
</head>
<body class="grey lighten-3">
    <form runat="server" style="width: 100%;">
        <div class="row max-width">
            <div class="col s12 white card">

                <div style="padding: 10px 0 0 0">

                </div>

                <div class="input-field col s12">
                    <input runat="server" id="name" type="text" class="validate" data-length="20">
                    <label for="name">Имя</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="last_name" type="text" class="validate" data-length="20">
                    <label for="last_name">Фамилия</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="username" type="text" class="validate" data-length="15">
                    <label for="username">Nickname</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="phone" type="text" class="validate" data-length="11">
                    <label for="phone">Номер телефона</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="email" type="text" class="validate" data-length="40">
                    <label for="email">Email</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="password" type="password" class="validate" data-length="20">
                    <label for="password">Введите пароль</label>
                </div>

                <div class="input-field col s12">
                    <input runat="server" id="password_repeat" type="password" class="validate" data-length="20">
                    <label for="password_repeat">Повторите пароль</label>
                </div>

                <div class="row center padding">
                    <a runat="server" id="send" class="waves-effect waves-light btn blue-grey ">
                        <i class="material-icons right">explore</i>Регистрация
                    </a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
