using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager0 : MonoBehaviour
{
    // register
    public TMP_InputField RegisterEmail;
    public TMP_InputField RegistePassword;
    public TMP_Text RegisterFail;

    // login
    public TMP_InputField LoginEmail;
    public TMP_InputField LoginPassword;
    public TMP_Text LoginterFail;



    public async void Register()
    {
        var email = RegisterEmail.text;
        var password = RegistePassword.text;

        var url = "/users/register";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequestHelper helper = new HTTPRequestHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>>>>>" + result);

        if (!result)
        {
            // nhảy qua màn hình đăng nhập
        }
        else
        {
            RegisterFail.text = "Not Found";
        }
    }

    public async void Login()
    {
        var email = LoginEmail.text;
        var password = LoginPassword.text;

        var url = "auth/login";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequestHelper helper = new HTTPRequestHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>>>>>" + result);

        if (!result)
        {
            // nhảy qua màn hình đăng nhập
            SceneManager.LoadScene(Constanes.Screen0_INDEX);
        }
        else
        {
            RegisterFail.text = "Đăng nhập không thành công";
        }
    }
}
