using System.Collections;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private float _time = 4f;

    IEnumerator SpikeMove()
    {
        _animator.Play("SpikeTrap");
        yield return new WaitForSeconds(_time);

        _animator.Play("IdleTrap");
        yield return null;
    }
}
