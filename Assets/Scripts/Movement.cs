/*  Amal Presingu
 *  9/17/2021
 *  Moving the pickup objects in random directions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    private int randomPlace;
    public Transform[] movePlace; //creating array for rocks to bounce off

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomPlace = Random.Range(0, movePlace.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePlace[randomPlace].position, speed * Time.deltaTime); //setting rocks in motion to random places

        if (Vector2.Distance(transform.position, movePlace[randomPlace].position) < 0.2f) { 
            if (waitTime <= 0) { 
                randomPlace = Random.Range(0, movePlace.Length); //randomly picking from array of positions
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime; 
            }
        }
    }
}
