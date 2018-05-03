<%@ Page Language="C#" Inherits="Pr.assets.pages.SignIn" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Вход</title>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css">
    <link rel="stylesheet" href="../css/signin.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script src="assets/js/signin.js"></script>
        
</head>
<body class="grey lighten-3">

    <form runat="server" style="width: 100%;">
            <div class="row max-width">
        <div class="col s12 white card">

            <div style="padding: 10px 0 0 0">

            </div>

            <div class="input-field col s12">
                <input runat="server" id="email" type="text" class="validate" data-length="40">
                <label for="email">Email</label>
            </div>

            <div class="input-field col s12">
                <input runat="server" id="password" type="password" class="validate" data-length="20">
                <label for="password">Пароль</label>
            </div>

            <div class="col s12 center padding">
                <div class="row">
                    <a runat="server" id="enter" class="waves-effect waves-light btn blue-grey disabled"><i class="material-icons right">explore</i>Войти</a>
                </div>
            </div>

        </div>
    </div>

    <div runat="server" id="errorBox">
                
    </div>
            
    </form>
        
</body>
</html>
