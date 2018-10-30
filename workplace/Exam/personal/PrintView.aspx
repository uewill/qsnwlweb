<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintView.aspx.cs" Inherits="Exam_personal_PrintView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="print.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="printbtn.css" media="print" />
</head>

<body>
    <form id="form1" runat="server">
        <div style="width: 210mm; height: 40px; text-align: center; margin-top: 20px;" class="printbtn">
            <input type="button" value="打印本页" onclick="window.print();" />
            打印预览配置中：请将显示背景勾选上,并将边距设为0。
        </div>
        <div style="width: 210mm; height: 297mm; background-image: url('./printimgs/gmkj.jpg'); background-repeat: no-repeat; background-size: contain;">
            <table style="padding-top: 190px;">
                <tr style="height: 40px; vertical-align: bottom">
                    <td style="width: 210px;"></td>
                    <td style="width: 90px;"></td>
                    <td><%=examModel.ExamNumber  %></td>
                    <td style="width: 110px;"></td>
                    <td><%=examModel.CreateTime.Value.ToString("yyyy/MM/dd") %></td>
                </tr>
                <tr style="height: 40px; vertical-align: bottom">
                    <td></td>
                    <td></td>
                    <td><%=examModel.UserName %></td>
                    <td style="width: 110px;"></td>
                    <td><%=examModel.Sex %></td>
                </tr>
                <tr style="height: 40px; vertical-align: bottom">
                    <td></td>
                    <td></td>
                    <td><%=examModel.UserNamePY %></td>
                    <td style="width: 110px;"></td>
                    <td><%=examModel.Mingzu %></td>
                </tr>
                <tr style="height: 40px; vertical-align: bottom">
                    <td></td>
                    <td></td>
                    <td><%=examModel.Birthday %></td>
                    <td style="width: 110px;"></td>
                    <td><%=examModel.Country %></td>
                </tr>
                <tr style="height: 50px; vertical-align: bottom">
                    <td></td>
                    <td colspan="4" style="letter-spacing:17px;"><%=examModel.IDNumber.Trim()%></td>
                </tr>
                <tr style="height: 40px; vertical-align: bottom">
                    <td></td>
                    <td colspan="4"><%=examModel.HomeAddress %></td>
                </tr>
                <tr style="height: 42px; vertical-align: bottom">
                    <td></td>
                    <td><%=examModel.Contactor %></td>
                    <td></td>
                    <td colspan="2" style="padding-left: 50px;"><%=examModel.ContactorPhone %></td>
                </tr>
                <tr style="height: 40px; vertical-align: bottom">
                    <td></td>
                    <td><%=examModel.ClassID %></td>
                    <td></td>
                    <td><%=examModel.ClassLevel %></td>
                    <td><%=examModel.HaveMaxLevel %></td>
                </tr>


            </table>
            <table style="margin-top: 195px;">
                <tr>
                    <td style="width: 205px; height: 30px"></td>
                    <td style="width: 185px;"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 90px"><%=examModel.UserName %></td>
                    <td style="width: 45px"></td>
                    <td style="width: 70px"></td>
                </tr>
                <tr>
                    <td style="height: 40px"></td>
                    <td></td>
                    <td></td>
                    <td><%=examModel.Birthday %></td>
                    <td></td>
                    <td><%=examModel.Sex %></td>
                </tr>
                <tr>
                    <td style="height: 40px"></td>
                    <td></td>
                    <td></td>
                    <td colspan="3"><%=examModel.ClassID %></td>
                </tr>
                <tr>
                    <td style="height: 35px"></td>
                    <td></td>
                    <td></td>
                    <td colspan="3"><%=examModel.ClassLevel %></td>
                </tr>

                <tr>
                    <td style="height: 50px"></td>
                    <td></td>
                    <td></td>
                    <td colspan="3">
                        <%=planModel.TestTimeAMStart.Value.ToString("yyyy") %>&nbsp;&nbsp;&nbsp;&nbsp;
                        <%=planModel.TestTimeAMStart.Value.ToString("MM") %>&nbsp;&nbsp;&nbsp;&nbsp;
                        <%=planModel.TestTimeAMStart.Value.ToString("dd") %>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                
                <tr>
                    <td style="height: 20px"></td>
                    <td></td>
                    <td></td>
                    <td colspan="3"><%=planModel.TestTimeAMStart.Value.ToString("hh:mm:ss") %>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%=planModel.TestTimeAMEnd.Value.ToString("hh:mm:ss") %></td>
                </tr>
                 <tr>
                    <td style="height: 50px"></td>
                    <td><%=examModel.ExamNumber %></td>
                    <td></td>
                    <td colspan="3"><%=planModel.Address %></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
