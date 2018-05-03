<%@ Page Language="C#" Inherits="Pr.Index"%>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>MOTO MARKET</title>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css">
    <link rel="stylesheet" href="css/style.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script src="assets/js/index.js"></script>

    <script>
            function toast (message){
            M.toast({html: message, classes: 'rounded'});
            }
    </script>
        
</head>
<body class="grey lighten-4">


        
    <div class="row">
        <div class="col s12 white card header">
            <div class="col s4 container">
                <span id="brand">MOTO MARKET</span>
            </div>
            <div class="col s8 container">
                <div class="entry">
                    <%
                        generateEntryControllers();
                    %>
                </div>
            </div>
        </div>
    </div>

    <form runat="server">
    <div class="row">

        <%
            generatePageBody();
        %>
            
    </div>

    <asp:ScriptManager runat="server" ID="sm">
     </asp:ScriptManager>
     <asp:updatepanel runat="server">
     <ContentTemplate>
        <a runat="server" id="buy" class="hidden"></a>
     </ContentTemplate>
     </asp:updatepanel>
            
    <input runat="server" id="field" value="notSelected" type="text" class="hidden">
            
    </form>
</body>
</html>
