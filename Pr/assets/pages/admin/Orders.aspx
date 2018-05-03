<%@ Page Language="C#" Inherits="Pr.assets.pages.admin.Orders" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Заказы</title>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css">
    <link rel="stylesheet" href="../../css/style.css">
    <link rel="stylesheet" href="../../css/orders.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script src="assets/js/orders.js"></script>
        
</head>
<body class="grey lighten-4">

    <div class="row">
        <div class="col s12 white card header">
            <div class="col s4 container">
                <span id="brand">MOTO MARKET</span>
            </div>
            <div class="col s8 container">
                <div class="entry">
                    <span class="welcome">Добро пожаловать, Величайший</span>
                    <a id="main" class="waves-effect waves-light btn blue-grey lighten-1">Главная</a>
                    <a id="exit" class="waves-effect waves-light btn blue-grey lighten-1">Выйти</a>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
                <div class="col s12 white card" style="padding: 20px">
                    <span>Еще ни один из покупателей не оплатил заказы</span>
                </div>
        </div>
    </div>
        
</body>
</html>
