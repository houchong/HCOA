<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsToWcf.aspx.cs" Inherits="WebApp.JsToWcf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">       
    <script lang="javascript" type="text/javascript">
        function GetValueFromServer() {
            var name = "hc";
            $.ajax({
                type: 'post',
                url: 'http://localhost:60494/JsToWcf.svc/SayHello',
                contentType: 'text/json',
                data: '{"name":"' + name + '"}',
                success: function (msg) {
                    var a = eval('(' + msg + ')');
                    alert(a);
                    if (String(a.d).length > 0) { alert(a.d); }
                    else { alert("服务器超时"); }
                }
            });
        }
        function onSuccess(result) {
            document.getElementById('labelResult').value = result;
        }

        function onFailure(result) {
            window.alert(result);
        }

    </script>
    <div>
        <input id="btnServiceCaller" runat="server" type="button" value="Get Value" onserverclick="GetValueFromServer" />
        <input id="txtValueContainer" type="text" value="" /> 
        <input id="labelResult" runat="server" type="text" value="" />
    </div>
    </form>
</body>
</html>
