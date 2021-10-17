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

    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_direction == Vector3.zero)
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
        if (Physics2D.Raycast(transform.position, _direction, 0.7f))
        {
            _direction = Vector3.zero;
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x),
                Mathf.Round(this.transform.position.y),
                0.0f
                );
            _animator.Play("IdlePlayer");
        }
        _rigidbody.velocity = _direction * _speed * Time.fixedDeltaTime;
        if (_direction == Vector3.left || _direction == Vector3.right)
        {
            //ScaleHorizontalPlayer();
            _animator.Play("VerticalCompression");
        }
        if (_direction == Vector3.up || _direction == Vector3.down)
        {
            //ScaleVerticalPlayer();
            _animator.Play("HorizontalCompression");
        }
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
                _gm.Win();
                break;
            case "Coin":
                _scoreCounter.ChangeScore(1);
                SmallCoinCollision();
                break;
            case "BigCoin":
                _scoreCounter.ChangeScore(10);
                BigCoinCollision();
                break;
            case "Wall":
                ScaleNormalPlayer();
                break;
        }
    }

    private void SmallCoinCollision()
    {
        var Tile = new Vector3Int(Mathf.RoundToInt(this.transform.position.x + _direction.x / 2) - 1,
                                    Mathf.RoundToInt(this.transform.position.y + _direction.y / 2) - 1,
                                    Mathf.RoundToInt(this.transform.position.z + _direction.z / 2));
        _tilemapSmallCoins.SetTile((Tile), null);
    }

    private void BigCoinCollision()
    {
        var Tile = new Vector3Int(Mathf.RoundToInt(this.transform.position.x + _direction.x / 2) - 1,
                                    Mathf.RoundToInt(this.transform.position.y + _direction.y / 2) - 1,
                                    Mathf.RoundToInt(this.transform.position.z + _direction.z / 2));
        _tilemapBigCoins.SetTile((Tile), null);
    }

    private void ScaleVerticalPlayer()
    {
        Vector3 compressedVector = new Vector3(0.7f, 1.3f, 1.0f);
        transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), compressedVector, 1);
    }
    private void ScaleHorizontalPlayer()
    {
        Vector3 compressedVector = new Vector3(1.3f, 0.7f, 1.0f);
        transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), compressedVector, 1);
    }
    private void ScaleNormalPlayer()
    {
        Vector3 normalSize = new Vector3(1f, 1f, 1f);
        transform.localScale = Vector3.Lerp(transform.localScale, normalSize, 1);
    }

}
