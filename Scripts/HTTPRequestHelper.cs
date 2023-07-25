using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPRequestHelper : MonoBehaviour
{
    private string baseUrl = "https://fpoly-hcm.herokuapp.com/api";

    //get
    public async Task<ListPostModel> GetAPI(string url)
    {
        try
        {
            url += baseUrl;
            using var www = UnityWebRequest.Get(url);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            var model = ListPostModel.CreateResponeFromJSON(result);
            return model;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }

    // post
    public async Task<bool> PostAPI(string url, WWWForm form)
    {
        try
        {
            url += baseUrl;
            using var www = UnityWebRequest.Post(url, form);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            var model = ResponseModel.CreateFromJSON(result);
            return model.error;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }

}

// post Respone
public class ListPostModel : ResponseModel
{
    public List<PostModel> data { get; set; }
    public static ListPostModel CreateResponeFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ListPostModel>(jsonString);
    }
}
public class PostModel
{
    public String id { get; set; }
    public String title { get; set; }
    public String content { get; set; }
}


// model Respone
public class ResponseModel
{
    public bool error { get; set; }
    public int statusCode { get; set; }

    public static ResponseModel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResponseModel>(jsonString);
    }
}
