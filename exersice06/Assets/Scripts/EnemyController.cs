using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public PlayerController pc;
    public GameManager gm;
    NavMeshAgent nma;
    float newPositionTimer = 0;

    //UI
    public int score = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the reference to the NavMeshAgent on this gameObject.
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is an example of using float variables and Time.deltaTime
        // to track how much time has passed (i.e. it is a timer).
        newPositionTimer = newPositionTimer - Time.deltaTime;
        if (newPositionTimer < 0)
        {
            newPositionTimer = Random.Range(1, 15);
            // Compute a random position and assign it to the NavMeshAgent.
            Vector3 randomPosition = RandomNavmeshLocation(Random.Range(10, 30));
            nma.SetDestination(randomPosition);
        }
    }

    // This function will find a random position located on the NavMesh. I wouldn't
    // worry about understanding it at this point. But you can use it to compute
    // random positions on a NavMesh.
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            pc.coinOnScene = pc.coinOnScene - 1;
            score = score + 1;
            scoreText.text = "Enemy: " + score.ToString() + "/8";
            gm.CreateEnemies(1);
        }
    }
}