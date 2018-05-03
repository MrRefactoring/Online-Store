<%@ Page Language="C#" Inherits="Pr.assets.pages.admin.AddItem" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
	<title>Добавить новый товар</title>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css">
    <link rel="stylesheet" href="../../css/add.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script src="assets/js/add.js"></script>

        <script>
            function toast (message){
            M.toast({html: message, classes: 'rounded'});
            }
    </script>
        
</head>
<body class="grey lighten-4">
	<form id="form1" runat="server" style="width: 100%;">

        <div class="row white card max-width" style="margin: 0 auto">
        <div class="row padding">
            <div class="col s6">
                <a id="back" class="waves-effect waves-light btn blue-grey lighten-1"><i class="material-icons left">arrow_back</i>Назад</a>
            </div>
            <div class="col s6" style="text-align: right">
                <asp:ScriptManager runat="server" ID="sm">
                </asp:ScriptManager>
                <asp:updatepanel runat="server">
                <ContentTemplate>
                    <a runat="server" id="addButton" class="waves-effect waves-light btn green"><i class="material-icons right">done</i>Добавить товар</a>
                </ContentTemplate>
                </asp:updatepanel>
            </div>
        </div>
        <div class="row side-padding">
            <div class="input-field col s12">
                <input runat="server" id="title" type="text" class="validate">
                <label for="title">Название</label>
            </div>
        </div>
        <div class="row side-padding">
            <div class="input-field col s12">
                <textarea runat="server" id="description" class="materialize-textarea"></textarea>
                <label for="description">Описание</label>
            </div>
        </div>
        <div class="row side-padding">
            <div class="input-field col s12">
                <input runat="server" id="price" type="text" class="validate">
                <label for="price">Цена (₽)</label>
            </div>
        </div>

        <div class="row side-padding">
            <div class="input-field col s12">
                <input runat="server" id="photos" type="text" class="validate">
                <label for="photos">Добавте ссылки на фотографии через пробел</label>
            </div>
        </div>
    </div>
            
	</form>
</body>
</html>
