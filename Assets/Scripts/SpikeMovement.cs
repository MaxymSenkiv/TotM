using System.Collections;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Animator _animator;

    private float _time = 2.5f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    IEnumerator SpikeMove()
    {
        _animator.Play("SpikeTrap");
        yield return new WaitForSeconds(_time);

        _animator.Play("IdleTrap");
        yield return null;
    }
}
