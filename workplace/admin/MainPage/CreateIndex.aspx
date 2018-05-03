<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateIndex.aspx.cs" Inherits="admin_MainPage_CreateIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script src="../js/jquery1.3.js" type="text/javascript" language="javascript"></script>
    <script>
  $(document).ready(function() {
  $("#btnCreate").click(function(){
    $.ajax({
     type: "POST",
      url: "../ImageHadder/CreateHtml.ashx",
      beforeSend :function(){$("#msgSpan").show();$("#msgSpan").html("正在进行网站首页提速...请稍候");},
      success: function(msg){$("#msgSpan").html(msg) }
    });
     });

  });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <div id="msgSpan" style="border: solid 2px #A91718; line-height: 25px; font-size: 20px;
                    font-weight: bold; margin: 5px 10px; display: none;">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnCreate" value="网站首页提速" style="height: 40px; width: 200px;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
