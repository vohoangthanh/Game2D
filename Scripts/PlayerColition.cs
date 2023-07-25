using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColition : MonoBehaviour
    
{
    // nhạc 
    [SerializeField]
    public AudioClip clip;
    public AudioSource source;
    [SerializeField]
    public AudioClip coinclip;

    // cointText
    [SerializeField]
    public TextMeshProUGUI cointext;
    public int coinnumber;

    public PlayerAnimation playeranimation;
    // Start is called before the first frame update
    void Start()
    {
        playeranimation = GetComponent<PlayerAnimation>();

        source = GetComponent<AudioSource>();
        coinnumber = 0;
        cointext.text = coinnumber + "";


    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playeranimation.SetJumping(true);
        }
        else if (collision.gameObject.CompareTag("Bo") || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Ron") || collision.gameObject.CompareTag("Sen"))
        {
            Vector3 direction = collision.GetContact(0).normal;
            float dicrectionX = direction.x; // dicrection > 0, else trai
            float dicrectionY = direction.y; // dicrection > 1 , else duoi
            Debug.Log(">>>:X " + direction + ">>>>Y: " + dicrectionY);

            if (dicrectionX != 0 && dicrectionY == 0)
            {
                // phải trái nấm --> maro lên trời
                Destroy(gameObject);// xóa mario
                Time.timeScale = 0;// dừng game 
            }
            else if (dicrectionY > 0 && dicrectionX == 0)
            {
                // trên nấm --> nấm lên trời
                Destroy(collision.gameObject);// xóa caay nấm
            }

        }
        else if (collision.gameObject.CompareTag("BulletBoss") || collision.gameObject.CompareTag("Hoa") 
            || collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Dirana"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("tron"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coints"))
        {
            // phát nhạc
            source.PlayOneShot(coinclip);
            // tăng điểm
            coinnumber++;
            cointext.text = coinnumber + "";
        }
    }


}
