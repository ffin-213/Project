using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Grandpa : MonoBehaviour
{
    [SerializeField] List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField] int currentWayPoint = 0;
    [SerializeField] float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 goal = wayPoints[currentWayPoint].transform.position;
        Vector2 newPos = Vector2.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
        transform.position = newPos;

        if (Mathf.Abs(transform.position.x - goal.x) < .1 && Mathf.Abs(transform.position.y - goal.y) < .1)
        {
            currentWayPoint = (currentWayPoint + 1) % wayPoints.Count;
        }
    }
}
