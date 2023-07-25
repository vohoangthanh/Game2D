using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public bool Isleft;
    public GameObject Player;
    public float Speed;
    //public AIPath aIPath;

    // Update is called once per frame
    void Update()
    {

        /* if (aIPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (aIPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            } */
        Rotation();
        Motivation();
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    void Motivation()
    {
        float direction = transform.localScale.x;
        if (direction <= 0)
        {
            // qua trai
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }

    // xoay mat con quai
    public void Rotation()
    {
        if (Player != null)
        {
            float PlayerX = Player.transform.position.x;
            float PositionX = transform.position.x;
            Isleft = PlayerX <= PositionX;
            Vector3 scale = transform.localScale;
            if (Isleft)
            {
                if (scale.x < 0) scale.x *= -1;

            }
            else
            {
                if (scale.x > 0) scale.x *= -1;
            }
            transform.localScale = scale;
        }
    }
    public void IntantiatePlaye(GameObject gameObject)
    {
        Player = gameObject;
    }


    private void OnTriggerEnter2D(Collider2D player)
    {
        // quái chạm nhân vật
        if (player.transform.position.y > (transform.position.y ))
        {
            Debug.Log("Treen");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Khasc");
        }
    }
}
