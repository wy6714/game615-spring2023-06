using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{
    //public GameObject gmObj;
    public GameManager gm;
    public NavMeshAgent nma;

    //UI
    int score = 0;
    public TMP_Text scoreText;

    //Coin
    public int coinOnScene =0;
    public int coinInTotal = 0;
    //public float coinTimeLeft = 8f;
    public GameObject pill; //for dragging to slot

    // Start is called before the first frame update
    void Start()
    {
        // This is an example for how we can get a component that is located on
        // the object via code (rather than making the NavMeshAgent variable
        // public and assigning a value to it using the Unity Inspector).
        nma = gameObject.GetComponent<NavMeshAgent>();
        gm.CreateEnemies(15);
    }

    // Update is called once per frame
    void Update()
    {
        // This is a demo of how to draw a ray from the player's position for
        // the position, the direction is the player's forward, and the length
        // or magnitude of the line/ray is 10.
        Vector3 rayStartPos = transform.position;
        // Raise the position up 1.5 units
        rayStartPos.y = rayStartPos.y + 1.5f;
        Debug.DrawRay(rayStartPos, transform.forward * 10);

        //3 coin show
        while(coinOnScene < 3 && coinInTotal < 15)
        {
      
            GameObject coins = Instantiate(pill, GameManager.getRandomPosition(-84.8f, 75.2f, -91.3f, 87.5f), Quaternion.identity);
            coinOnScene++;
            coinInTotal++;
        }
        
    }



    // Unity will tell the function below to run under the following conditions:
    //  1. Two objects with colliders are colliding
    //  2. At least one of the objects' colliders are marked as "Is Trigger"
    //  3. At least one of the objects has a Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        // 'other' is the name of the collider that just collided with the object
        // that this script ("PlayerController") is attached to. So the if statment
        // below checks to see that that object has the tag "coin". Remember that
        // the tags for GameObjects are assigned in the top left area of the
        // inspector when you select the obect.
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinOnScene = coinOnScene - 1;
            score = score + 1;
            scoreText.text = "Player: " + score.ToString() + "/15";
            
        }
    }

    

}
