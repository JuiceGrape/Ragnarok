using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementAnimator : MonoBehaviour
{
    [SerializeField]
    private bool FlipX = true;

    private Animator animator;

    private Vector3 oldPos;
    void Start()
    {
        animator = GetComponent<Animator>();
        oldPos = transform.position;
    }

    void Update()
    {
        Vector3 newPos = transform.position;

        if (Vector3.Distance(newPos, oldPos) > 0.01)
        {
            animator.SetBool("IsMoving", true);
            Vector3 movement = newPos - oldPos;
            movement.Normalize();

            animator.SetFloat("Y-mov", movement.y);
            animator.SetFloat("X-mov", movement.x);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        oldPos = newPos;
    }
}
