using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float coinTimeLeft = 8f;
    
    //public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinTimeLeft -= Time.deltaTime;
        if (coinTimeLeft < 0)
        {
            //Vector3 randomPosition = new Vector3(Random.Range(-84.8f, 75.2f), 2, Random.Range(-91.3f, 87.5f));
            transform.position = GameManager.getRandomPosition(-84.8f, 75.2f, -91.3f, 87.5f);
            coinTimeLeft = 8f;
        }
    }
}
