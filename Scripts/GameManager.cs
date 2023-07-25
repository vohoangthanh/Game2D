using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float TimeEnemy1, CoutEnemy1;
    public GameObject EnemyGFX;
    public GameObject Player;
    public float NumberEnemy1;

    public float TimeClock, CountClock;
    public Sprite clock0,clock1, clock2, clock3, clock4, clock5, clock6,clock7, clock8, clock9, clock10;
    public int NumberClock;
    public GameObject ClockImage;

   
    



    // Start is called before the first frame update
    void Start()
    {
        TimeEnemy1 = 1f;
        CoutEnemy1 = TimeEnemy1;
        NumberEnemy1 = 0;

        // 
        TimeClock = 1f;
        CountClock = TimeClock;
        NumberClock = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (NumberEnemy1 < 3) RandomEnemy();
        UpdtaClockImage();
    }

    // tạo random con quạ 1s 1 con, vị trí ngẫu nhiên
    void RandomEnemy()
    {
        CoutEnemy1 -= Time.deltaTime;
        if(CoutEnemy1 <= 0)
        {
            NumberEnemy1++;
            CoutEnemy1 = TimeEnemy1;
            GameObject go1 = Instantiate(EnemyGFX);
            go1.GetComponent<EnemyGFX>().IntantiatePlaye(Player);
            go1.transform.position = new Vector3(Random.Range(-1,43),-4f,0);
            //Destroy(go1, 5f);
        }
    }

    void UpdtaClockImage()
    {
        CountClock -= Time.deltaTime;
        if(CountClock <= 0)
        {
            CountClock = TimeClock;
            Sprite[] sprites = new Sprite[] { clock0, clock1, clock2, clock3, clock4, clock7, clock8,clock9,clock10};
            ClockImage.GetComponent<Image>().sprite = sprites[NumberClock];
            NumberClock++;
            if (NumberClock > 10) NumberClock = 0;
        }
    }

   
}
