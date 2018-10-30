using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;

public partial class Exam_sendmsg : System.Web.UI.Page
{
    TFXK.BLL.TestingPerson testingPerson = new TFXK.BLL.TestingPerson();
    TFXK.BLL.TestingCenter testingCenter = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        int type = 0;
        int.TryParse(Request.Form["type"] + "", out type);
        string phoneNumber = Request.Form["number"] + "";
        var flag = FindModelByPhoneNumber(type, phoneNumber);
        if (!flag)
        {
            Response.Write("{\"result\":-1,\"errmsg\":\"未能找到数据\"}");
            Response.End();
        }
        SendMessage(type, phoneNumber);
    }
    private bool FindModelByPhoneNumber(int type, string phoneNumber)
    {
        if (type == 0)
        {
            var model = testingCenter.GetModelByName(phoneNumber);
            if (model != null)
            {
                return true;
            }
        }
        else if (type == 1)
        {
            var model = testingPerson.GetModelByPhone(phoneNumber);
            if (model != null)
            {
                return true;
            }
        }

        return false;
    }
    private void SendMessage(int type, string phoneNumber)
    {
        // 短信应用SDK AppID
        int appid = 122333333;
        // 短信应用SDK AppKey
        string appkey = "9ff91d87c2cd7cd0ea762f141975d1df37481d48700d70ac37470aefc60f9bad";

        // 短信模板ID，需要在短信应用中申请
        int templateId = 7839; // NOTE: 这里的模板ID`7839`只是一个示例，真实的模板ID需要在短信控制台中申请
        // 签名
        string smsSign = "腾讯云"; // NOTE: 这里的签名只是示例，请使用真实的已申请的签名, 签名参数使用的是`签名内容`，而不是`签名ID`


        Random random = new Random();
        string valCode = random.Next(1000, 9999) + "";
        Session["valicode"+ phoneNumber] = valCode;

        try
        {
            SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
            var result = ssender.sendWithParam("86", phoneNumber,
                templateId, new[] { valCode }, smsSign, "", "");  // 签名参数未提供或者为空时，会使用默认签名发送短信
            Response.Write(result);
        }
        catch (JSONException e)
        {
            Console.WriteLine(e);
        }
        catch (HTTPException e)
        {
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}