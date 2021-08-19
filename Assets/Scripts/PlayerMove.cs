using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameManager gm;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction = Vector3.zero;
    [SerializeField] private Tilemap _tilemap;
    private int _score = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tilemap.SetTile(new Vector3Int(0, -1, 0), null);
    }

    private void Update()
    {
        if(direction == Vector3.zero)
        {
            if (Input.GetAxis("Horizontal") > 0f)
            {
                direction = Vector3.right; 
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
                direction = Vector3.left;
            }
            if (Input.GetAxis("Vertical") > 0f)
            {
                direction = Vector3.up;
            } 
            if (Input.GetAxis("Vertical") < 0f)
            {
                direction = Vector3.down;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, direction, 0.6f))
        {
            direction = Vector3.zero;
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
                _rigidbody.velocity = Vector3.zero;
                gm.GameOver();
                break;
            case "End":
                _rigidbody.velocity = Vector3.zero;
                gm.NextLevel();
                break;
            case "Coin":
                _score++;
                Vector3Int Tile = new Vector3Int (Mathf.RoundToInt(this.transform.position.x + direction.x / 2), Mathf.RoundToInt(this.transform.position.y + direction.y / 2),
                    Mathf.RoundToInt(this.transform.position.z + direction.z / 2));
                _tilemap.SetTile((Tile), null);
                Debug.Log(Tile);
                break;
        }
    }
}
