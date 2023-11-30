using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public SpriteRenderer characterRenderer;
    public Vector2 PointerPosition { get; set; }



    public float delay = 0.3f;
    private bool attackBlocked;

    public bool IsAttacking { get; private set; }


    public float radius;
    [Header("Weapon1")]
    public SpriteRenderer weaponRenderer1;
     public Animator animator1;
    public Transform circleOrigin1;
    [Header("Weapon2")]
    public SpriteRenderer weaponRenderer2;
     public Animator animator2;
    public Transform circleOrigin2;

    //
     private SpriteRenderer weaponRenderer;
     private Animator animator;
     private Transform circleOrigin;
   
  void Start()
    {
        //   attackArea = transform.GetChild(0).gameObject;
        weaponRenderer = weaponRenderer1;
        animator = animator1;
        circleOrigin = circleOrigin1;
    }

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            //  Debug.Log(collider.name);
            Health health;
            if (health = collider.GetComponent<Health>())
            {
                health.GetHit(1, transform.parent.gameObject);

            }
             HealthBoss healthBoss;
            if (healthBoss = collider.GetComponent<HealthBoss>())
            {
                healthBoss.GetHit(1, transform.parent.gameObject);

            }
        }
    }
}