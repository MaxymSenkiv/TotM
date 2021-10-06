using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameManager _gm;

    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private Vector3 _direction = Vector3.zero;

    [SerializeField] private float _speed;

    [SerializeField] private Tilemap _tilemapSmallCoins;
    [SerializeField] private Tilemap _tilemapBigCoins;

    [SerializeField] private ScoreCounter _scoreCounter;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_direction == Vector3.zero)
        {
            if (Input.GetAxis("Horizontal") > 0f)
            {
                _direction = Vector3.right; 
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
                _direction = Vector3.left;
            }
            if (Input.GetAxis("Vertical") > 0f)
            {
                _direction = Vector3.up;
            } 
            if (Input.GetAxis("Vertical") < 0f)
            {
                _direction = Vector3.down;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, _direction, 0.6f))
        {
            _direction = Vector3.zero;
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x),
                Mathf.Round(this.transform.position.y),
                0.0f
                );
        }
        _rigidbody.velocity = _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Obstacle":
                _rigidbody.velocity = Vector3.zero;
                _gm.GameOver();
                break;
            case "End":
                _rigidbody.velocity = Vector3.zero;
                _gm.NextLevel();
                break;
            case "Coin":
                _scoreCounter.ChangeScore(1);
                SmallCoinCollision();
                break;
            case "BigCoin":
                _scoreCounter.ChangeScore(10);
                BigCoinCollision();
                break;
        }
    }

    private void SmallCoinCollision()
    {
        var Tile = new Vector3Int(Mathf.RoundToInt(this.transform.position.x + _direction.x / 2)-1, 
                                    Mathf.RoundToInt(this.transform.position.y + _direction.y / 2)-1,
                                    Mathf.RoundToInt(this.transform.position.z + _direction.z / 2));
        _tilemapSmallCoins.SetTile((Tile), null);
    }

    private void BigCoinCollision()
    {
        var Tile = new Vector3Int(Mathf.RoundToInt(this.transform.position.x + _direction.x / 2)-1, 
                                    Mathf.RoundToInt(this.transform.position.y + _direction.y / 2)-1,
                                    Mathf.RoundToInt(this.transform.position.z + _direction.z / 2));
        _tilemapBigCoins.SetTile((Tile), null);
    }
}
