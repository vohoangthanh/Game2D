using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float Left;
    public float Right;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            float PlayerX = Player.transform.position.x;
            float PlayerY = Player.transform.position.y;

            float CameraX = transform.position.x;
            float CameraY = transform.position.y;

            if(PlayerX > Left && PlayerX < Right)
            {
                CameraX = PlayerX;
            }
            else if (PlayerX <= Left)
            {
                CameraX = Left;
            }
            else if(PlayerX >= Right)
            {
                CameraX = Right;
            }

            
            CameraY = Mathf.Max(0, PlayerY);
            transform.position = new Vector3(CameraX, CameraY, -10);
        }
    }
}
