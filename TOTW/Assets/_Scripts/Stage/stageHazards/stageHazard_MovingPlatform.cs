using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard_MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stopDelay = 0.33f;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] waypoints;

    private bool stop = false;
    private int currentPoint;

    
    void Start()
    {
        this.transform.position = waypoints[startPoint].position;
    }

    
    void Update()
    {
        if (!stop)
        {
            MoveTo();
            if(Vector2.Distance(transform.position, waypoints[currentPoint].position) <= 0.02f)
            {
                StartCoroutine(StopAtWaypoint());
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
               
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    private void MoveTo()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, waypoints[currentPoint].position, speed * Time.deltaTime);
    }

    private IEnumerator StopAtWaypoint()
    {
        stop = true;
        yield return new WaitForSeconds(stopDelay);
        stop = false;
        SwitchWaypoint();
    }

    private void SwitchWaypoint()
    {
        currentPoint++;
        if (currentPoint == waypoints.Length)
        {
            currentPoint = 0;
        }
    }
}
