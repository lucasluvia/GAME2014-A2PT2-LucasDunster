// PlayerBehaviour.cs
// Lucas Dunster 101230948
// DLM: 12/12/21
// Controls all player movement and processes player character input

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Touch Input")]
    [SerializeField] private Joystick joystick;
    [Header("Movement")]
    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundOrigin;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] [Range(0.1f, 0.9f)] private float airControlFactor;
    [Header("Animation")]
    [SerializeField] private AnimationState animationState;

    private bool doubleJump = true;
    private int lives = 5;
    private int coins = 0;

    private Rigidbody2D rigidbody;
    private Animator animatorController;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("lives", lives);
    }

    void Update()
    {
        CheckLives();
        CheckIfGrounded();
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        float jump = Input.GetAxisRaw("Jump") + ((UIController.isJumpButtonPressed) ? 1.0f : 0.0f);


        if (isGrounded)
        {
            doubleJump = true;
            if (x != 0)
            {
                x = FlipAnimation(x);
                animatorController.SetInteger("PlayerState", (int)AnimationState.RUN);
                animationState = AnimationState.RUN;
            }
            else
            {
                animatorController.SetInteger("PlayerState", (int)AnimationState.IDLE);
                animationState = AnimationState.IDLE;
            }

            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce;
            float mass = rigidbody.mass * rigidbody.gravityScale;

            rigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            rigidbody.velocity *= 0.99f;
        }
        else
        {
            
            animatorController.SetInteger("PlayerState", (int)AnimationState.JUMP);
            animationState = AnimationState.JUMP;

            if (x != 0)
            {
                x = FlipAnimation(x);

                float horizontalMoveForce = x * horizontalForce * airControlFactor;
                float mass = rigidbody.mass * rigidbody.gravityScale;

                rigidbody.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);
            }
        }
    }

    void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);
        isGrounded = (hit) ? true : false;
        
    }

    private float FlipAnimation(float x)
    {
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }

    public void IncrementCoins()
    {
        coins++;
    }
    
    public int GetCoins()
    {
        return coins;
    }
    
    public void DecrementPlayerLives()
    {
        lives--;
        PlayerPrefs.SetInt("lives", lives);
    }
    
    public int GetLives()
    {
        return lives;
    }

    private void CheckLives()
    {
        if(lives <= 0)
        {
            //save required data
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            IncrementCoins();
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }
}
