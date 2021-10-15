using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _startPosition;

    [SerializeField] private Vector3 _endPosition;

    [SerializeField] private float _speed;

    private bool _canMove = true;

    void Start()
    {
        _startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (_canMove)
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
        if (transform.position == _endPosition)
        {
            _endPosition = _startPosition;
            _startPosition = transform.position;
            StartCoroutine("EnemyStay");
        }
    }

    IEnumerator EnemyStay()
    {
        _canMove = false;
        yield return new WaitForSeconds(1f);

        _canMove = true;
        yield return null;
    }
}
