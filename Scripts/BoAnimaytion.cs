using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoAnimaytion : MonoBehaviour
{
   // bieen di chuyển
    [SerializeField]
    private float leftBound;
    [SerializeField]
    private float rightBound;

    // tốc độ di chuyển 
    [SerializeField]
    private float speed;

    // huownsg
    [SerializeField]
    private bool isOnRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.localPosition.x;
        
        if(positionX <= leftBound)
        {
            isOnRight = true;
            
        }else if(positionX >= rightBound)
        {
            isOnRight = false;
            
        }
        if (isOnRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    // rua cham vao dan ---> rua len troi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
