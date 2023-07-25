using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public float Speed;
    public bool IsOnGroud;
    public Rigidbody2D rgb;

    // Time Text
    [SerializeField]
    public TextMeshProUGUI timeText;
    public int timenumber;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        Speed = 0f;
        IsOnGroud = true;


        timenumber = 200;
        StartCoroutine(Updatetime());
    }

    // Update is called once per frame
    void Update()
    {
        SetUpAnimator();
        // chayj dong ho
        
    }

    public void SetUpAnimator()
    {
        animator.SetBool("IsOnGroud", IsOnGroud);
        animator.SetFloat("Speed", Speed);
        // lấy vận tốc chuyển động
    }
    public void SetJumping(bool value)
    {
        IsOnGroud = value;
    }
    public void SetRunning(float value)
    {
        Speed = value;
    }

    IEnumerator Updatetime()
    {
        while (true)
        {
            timenumber--;
            timeText.text = timenumber +" ";
            yield return new WaitForSeconds(1);
        }

    }
}
