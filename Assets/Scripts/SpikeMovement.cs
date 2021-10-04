using System.Collections;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    BoxCollider2D Collider;

    [SerializeField] private Animator animator;

    [SerializeField] private float Time = 4f;

    IEnumerator SpikeMove()
    {
        animator.Play("SpikeTrap");
        yield return new WaitForSeconds(Time);

        animator.Play("IdleTrap");
        yield return null;
    }
}
