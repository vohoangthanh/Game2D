using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // gọi Api lấy thông tin và lưu bộ nhớ
        Getsetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void Getsetting()
    {
        var url = "articles";

        HTTPRequestHelper helper = new HTTPRequestHelper();
        ListPostModel result = await helper.GetAPI(url);
        Debug.Log(" >>>>>>" + result);
        
    }
}
