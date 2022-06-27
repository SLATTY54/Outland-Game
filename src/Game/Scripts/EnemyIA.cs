using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Pathfinding;


public class EnemyIA : MonoBehaviour
{
    public Transform target;
    
    public float speed = 200f;

    public float nextWaitPointDistance = 3f;

    Path path;

    private int CurrentWayPoint = 0;

    private bool ReachedEndOfPath = false;

    private Seeker seeker;

    private Rigidbody2D rb;

    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath",0f,.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWayPoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;
        if (CurrentWayPoint >= path.vectorPath.Count)
        {
            ReachedEndOfPath = true;
            return;
        }
        else
        {
            ReachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[CurrentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position,path.vectorPath[CurrentWayPoint]);

        if (distance < nextWaitPointDistance)
        {
            CurrentWayPoint++;
        }
        
        if(force.x>=0.01f)
        {
            enemy.localScale=new Vector3(-1f,1f,1f);
        }else if(force.x<=-0.01f)
        {
            enemy.localScale = new Vector3(1f,1f,1f);
        }    
        
    }

}
