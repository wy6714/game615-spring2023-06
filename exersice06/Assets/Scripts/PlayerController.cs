using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    //public GameObject gmObj;
    public GameManager gm;
    public NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        // This is an example for how we can get a component that is located on
        // the object via code (rather than making the NavMeshAgent variable
        // public and assigning a value to it using the Unity Inspector).
        nma = gameObject.GetComponent<NavMeshAgent>();
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
            gm.IncrementScore();
        }
    }
}
