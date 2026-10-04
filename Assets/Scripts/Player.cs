using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D _playerRb;
    Animator _playerSpriteAnimator; 
    
    float _xDir;
    
    [SerializeField] float speedX; 

    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerSpriteAnimator = GetComponent<Animator>(); 
    }
    
    void OnMove(InputValue inputValue)
    {
        _xDir = inputValue.Get<Vector2>().x;
    }
    
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        _playerRb.linearVelocityX = _xDir * speedX;
        bool isRunning = Mathf.Abs(_playerRb.linearVelocityX) > Mathf.Epsilon;
        _playerSpriteAnimator.SetBool("IsRunning", isRunning);
        if (isRunning)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        transform.localScale = new Vector3(Mathf.Sign(_playerRb.linearVelocityX), 1, 1);
    }
}