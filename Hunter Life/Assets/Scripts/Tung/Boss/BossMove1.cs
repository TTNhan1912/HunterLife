﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove1 : MonoBehaviour
{
    private bool roaming = true;
    private float moveSpeed;
    private float nextWPDistance = 0.3f;
    public SpriteRenderer characterSR;
    public bool isAttack = false;

    public Seeker seeker;
    Path path;
    Coroutine moveCoroutine;
    bool reachDestination = false;
    private bool updateContinuesPath;

    //public GameObject Pos;
    private Vector3 initPos;

    private Animator animator;

    public Transform target;
    public Transform positionEnemies;
    public float chaseRadius;

    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
        moveSpeed = 3f;

        // lấy vị trí ban đầu
        initPos = positionEnemies.position;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(positionEnemies.position, target.position);

        if (distanceToTarget <= chaseRadius)
        {
            roaming = false;
            updateContinuesPath = true;
            Debug.Log("Vị trí ban đầu: " + initPos);
            // dí theo nhân vật và tấn công :>>
            // tăng tốc chạy
            moveSpeed = 3.3f;
            if (distanceToTarget < 1f)
            {
                // Xử lý sự kiện khi quái vật gần chạm nhân vật
                animator.SetTrigger("isAttack");
                Debug.Log("Chém");
            }
        }
        else
        {
            roaming = true;
            updateContinuesPath = false;
            // đi bình thường thì animator run bình thường
            moveSpeed = 3f;
            animator.SetFloat("isWalk", 0.2f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

            animator.SetFloat("isWalk", direction.sqrMagnitude);

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    characterSR.transform.localScale = new Vector3(-8f, 8f, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(8f, 8f, 0);
                }
            }

            yield return null;

        }
        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        //Vector3 isPos = Pos.transform.position;
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        if (roaming)
        {
            return (Vector2)initPos + (Random.Range(2f, 4f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return playerPos;
        }
    }
}