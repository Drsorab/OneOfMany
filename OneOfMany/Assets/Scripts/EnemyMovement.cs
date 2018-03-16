using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyProperties))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private EnemyProperties enemy;
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 ahead = new Vector3(0, 0, 0);
    public Vector3 ahead2 = new Vector3(0, 0, 0);
    public Vector3 avoidForce = new Vector3(0, 0, 0);
    public float maxEyeSight =5;
    public float maxAvoidForce = 5;
    public int maxSpeed = 10;
    private int waypointIndex = 0;
    public int arriveRadius = 5;
    List<GameObject> Players = new List<GameObject>();
    GameObject seekingPlayer;

    bool avoid = false;
    // Use this for initialization
    void Start () {
        target = Waypoints.points[0];
        enemy = GetComponent<EnemyProperties>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Players.Add(player);
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWaypoint();
        }

        //ClosestPlayer();
        //GetAhead();

        //    RaycastHit();
        //if (avoidForce != Vector3.zero)
        //    avoidForce = Vector3.Lerp(avoidForce, Vector3.zero, Time.time/100);
        //GetComponent<Rigidbody>().velocity=Seek()+avoidForce;

    }

    private void GetNextWaypoint()
    {

        if (Waypoints.points.Length>0 && waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void GetAhead() {
        ahead = transform.position + GetComponent<Rigidbody>().velocity.normalized * maxEyeSight;
        ahead2 = ahead / 2;
    }

    private double Distance(Vector3 a, Vector3 b ) {
        return Math.Sqrt((a.x - b.x) * (a.x - b.x)  + (a.y - b.y) * (a.y - b.y));
    }
    private void RaycastHit () {

        Ray ray = new Ray(transform.position, -(transform.position-ahead));
        RaycastHit hit ;
        float distance = (float)Distance(transform.position, ahead);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform != null && !hit.transform.name.Contains("Node"))
                AvoidanceForce(hit.transform);
        }
            
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.white);
    
    }

    private void AvoidanceForce(Transform obstacle) {
        Vector3 avoidanceForce = ahead - obstacle.position;
        avoidanceForce = avoidanceForce.normalized * maxAvoidForce;
        Debug.DrawLine(transform.position, avoidanceForce);
        avoidForce= avoidanceForce;

        Debug.DrawLine(transform.position, avoidanceForce,Color.red);
    }

    void EndPath() {
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
        PlayerStats.lives--;
    }

    public Vector3 Seek()
    {
        Vector3 diff = seekingPlayer.transform.position - transform.position;
        Vector3 desired_V = diff.normalized * maxSpeed;
        Debug.DrawLine(transform.position, desired_V - velocity, Color.blue);
        return desired_V - velocity;
    }

    public Vector3 Arrive()
    {
        Vector3 toTarget = seekingPlayer.transform.position - transform.position;
        double distance = toTarget.magnitude;
        if (distance > 0)
        {
            double speed = maxSpeed * (distance / arriveRadius);
            speed = Math.Min(speed, maxSpeed);
            Vector3 desired_V = toTarget * (float)(speed / distance);
            return desired_V - velocity;
        }
        return new Vector3(0, 0);
    }

    void ClosestPlayer() {
        float minDist = 0;
        foreach (GameObject p in Players) {
            if (Vector3.Distance(transform.position, p.transform.position) < minDist || minDist == 0) {
                seekingPlayer = p;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, arriveRadius);
    }
}
