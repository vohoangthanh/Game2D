using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoScripts : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float bounce;
    // vij tris ban dau cua pirana



    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(Goup());

    }


    // bong chay le
    IEnumerator Goup()
    {
        while (true)
        {
            Vector2 currentPosition = transform.localPosition;
            currentPosition.y += speed * Time.deltaTime;
            // nếu đi lên tới giờ hạn  -- dừng lại
            if (currentPosition.y >= originalPosition.y + bounce)
            {
                break;
            }
            transform.localPosition = currentPosition;
            yield return null;


        }
        StartCoroutine(GoDown());
    }

    IEnumerator GoDown()
    {

        // bien dung
        bool isStop = false;
        while (isStop)
        {
            yield return new WaitForSeconds(3);
            isStop = true;
        }
        while (true)
        {
            Vector2 currentPosition = transform.localPosition;
            currentPosition.y -= speed * Time.deltaTime;
            // nếu đi lên tới giờ hạn  -- dừng lại
            if (currentPosition.y <= originalPosition.y)
            {
                break;
            }
            transform.localPosition = currentPosition;
            yield return null;

        }
        StartCoroutine(Goup());
    }
    // bong chay xuong
    // Update is called once per frame
    void Update()
    {

    }
}
