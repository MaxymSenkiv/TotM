using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameManager gm;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction = Vector2.zero;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(direction == Vector2.zero)
        {
            if (Input.GetAxis("Horizontal") > 0f)
            {
                direction = Vector2.right; 
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
                direction = Vector2.left;
            }
            if (Input.GetAxis("Vertical") > 0f)
            {
                direction = Vector2.up;
            } 
            if (Input.GetAxis("Vertical") < 0f)
            {
                direction = Vector2.down;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, direction, 0.6f))
        {
            direction = Vector2.zero;
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x),
                Mathf.Round(this.transform.position.y),
                0.0f
                );
        }
        _rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Obstacle":
                _rigidbody.velocity = Vector2.zero;
                gm.GameOver();
                break;
            case "End":
                _rigidbody.velocity = Vector2.zero;
                gm.NextLevel();
                break;
        }
    }
}
