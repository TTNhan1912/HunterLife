using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1Script : MonoBehaviour
{
    private bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    public SpriteRenderer characterSR;

    public Seeker seeker;
    Path path;
    Coroutine moveCoroutine;
    bool reachDestination = false;
    public bool updateContinuesPath;

    //public GameObject Pos;
    private Vector3 initPos;

    public Transform target;
    public Transform positionEnemies;
    public float chaseRadius;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;

        // lấy vị trí ban đầu
        initPos = positionEnemies.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(positionEnemies.position, target.position);


        if (distanceToTarget <= chaseRadius)
        {
            roaming = true;
            updateContinuesPath = true;
            Debug.Log("Vị trí ban đầu: " + initPos);
        }
        else
        {
            roaming = true;
            updateContinuesPath = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var name = collision.gameObject.tag;

    }

    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            //animator.SetFloat("isRun", direction.sqrMagnitude);

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    characterSR.transform.localScale = new Vector3(5f, 5f, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(-5f, 5f, 0);
                }
            }

            yield return null;

        }
        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos);

        if (roaming)
        {
            // If the character is within the specified radius, evade the character
            if (distanceToPlayer <= chaseRadius)
            {
                Vector2 directionToPlayer = (transform.position - playerPos).normalized;
                Vector2 evadePosition = (Vector2)initPos + directionToPlayer * (chaseRadius + 1.0f); // Add some buffer to the evade distance
                return evadePosition;
            }
            else
            {
                // Otherwise, roam freely within a specified range around the initial position
                return (Vector2)initPos + (Random.Range(3f, 6f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
            }
        }
        else
        {
            // If not roaming, always chase the character
            return playerPos;
        }
    }
}
