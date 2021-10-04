using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 _start_position;
    [SerializeField] private Vector3 _end_position;
    [SerializeField] private float _speed;
    private bool _can_move = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _start_position = transform.position;
    }

    private void FixedUpdate()
    {
        if (_can_move == true)
            transform.position = Vector3.MoveTowards(transform.position, _end_position, _speed * Time.deltaTime);
        if (transform.position == _end_position)
        {
            _end_position = _start_position;
            _start_position = transform.position;
            StartCoroutine("EnemyStay");
        }
    }

    IEnumerator EnemyStay()
    {
        _can_move = false;
        yield return new WaitForSeconds(1f);
        _can_move = true;
        yield return null;
    }
}
