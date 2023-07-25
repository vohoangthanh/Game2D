using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovevation : MonoBehaviour
{

    [SerializeField]
    public float HorizontalSpeed;
    public float VerticalSpeed;

    public bool Isright;

    public PlayerAnimation playeranimation;
    // Start is called before the first frame update
    void Start()
    {
        playeranimation = GetComponent<PlayerAnimation>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMoving();
        VerticalMoving();
    }
    public void HorizontalMoving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            // di chuyeern qua phai
            transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
            playeranimation.SetRunning(1);
            Scaling(true);
        }
        else if (horizontalInput < 0)
        {
            // di chuyeern qua trai
            transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime);
            playeranimation.SetRunning(1);
            Scaling(false);
        }
        else
        {
            playeranimation.SetRunning(0);
        }
    }
    public void VerticalMoving()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            transform.Translate(Vector3.up * VerticalSpeed * Time.deltaTime);
            playeranimation.SetJumping(false);
        }

    }
    
    public void Scaling(bool right)
    {
        if (right != Isright)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Isright = right;
        }
       
    }

}
