using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player;
    private LevelTransition levelTransition;
    private SoundManager soundManager;
    private LevelCompleted levelCompleted;
    private GameCompleted gameCompleted;
    private GameOver gameOver;
    private PlayerDied playerDied;
    private LifeManager lifeManager;
    private CollectiblesManager collectiblesManager;
    private SaveData saveData;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isGrounded;
    private bool jump;
    private bool facingRight;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        facingRight = true;

        soundManager = FindObjectOfType<SoundManager>();
        levelTransition = FindObjectOfType<LevelTransition>();
        levelCompleted = FindObjectOfType<LevelCompleted>();
        gameCompleted = FindObjectOfType<GameCompleted>();
        gameOver = FindObjectOfType<GameOver>();
        playerDied = FindObjectOfType<PlayerDied>();
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
        lifeManager = FindObjectOfType<LifeManager>();
        saveData = FindObjectOfType<SaveData>();

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        MovePlayer(horizontal);
        Flip(horizontal);
        HandleLayers();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            soundManager.PlayPlayerJumpSound();
        }
    }

    private void MovePlayer(float horizontal)
    {
        if(rigidBody.velocity.y < 0)
        {
            animator.SetBool("land", true);
        }

        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (isGrounded && jump)
        {
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0, jumpForce));
            animator.SetTrigger("jump");
        }

        ResetValues();
    }

    private bool IsGrounded()
    {
        if (rigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        animator.ResetTrigger("jump");
                        animator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void ResetValues()
    {
        jump = false;
    }

    private void Flip(float horizontal)
    {
        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    //za izmjenu animacija za skakanje
    private void HandleLayers()
    {
        if(!isGrounded)
        {
            //ako je igrač u zraku, AirLayer se postavlja na 1 i prikaže se animacija za skakanje
            animator.SetLayerWeight(1, 1);
        }

        else
        {
            //inače animacija za padanje
            animator.SetLayerWeight(1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.tag.Equals(Tags.Coin))
        {
            collectiblesManager.IncreaseCoinsCounter();
            PlayerCollectedCoin(otherObject);
        }

        else if (otherObject.tag.Equals(Tags.SlimeBlue) || otherObject.tag.Equals(Tags.SlimeGreen)
                    || otherObject.tag.Equals(Tags.SlimePurple) || otherObject.tag.Equals(Tags.Spike))
        {
            lifeManager.TakeOneLife();
            collectiblesManager.ResetCoinsCount();
            PlayerDied(player);
        }

        else if(otherObject.tag.Equals(Tags.JewelBlue))
        {
            collectiblesManager.IncreaseBlueJewelCounter();
            levelTransition.FirstLevelIsPassed();
            PlayerCollectedBlueJewel(otherObject);
        }

        else if (otherObject.tag.Equals(Tags.JewelGreen))
        {
            collectiblesManager.IncreaseGreenJewelCounter();
            levelTransition.SecondLevelIsPassed();
            PlayerCollectedGreenJewel(otherObject);
        }

        else if (otherObject.tag.Equals(Tags.JewelRed))
        {
            collectiblesManager.IncreaseRedJewelCounter();
            PlayerCollectedRedJewel(otherObject);
        }
    }

    private void PlayerCollectedRedJewel(Collider2D otherObject)
    {
        soundManager.StopBackgroundMusic();
        gameCompleted.GetGameCompletedCanvas().SetActive(true);
        soundManager.PlayGameCompletedSound();
        saveData.SavePlayerScore();
        Destroy(otherObject.gameObject);
    }

    private void PlayerCollectedGreenJewel(Collider2D otherObject)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        levelCompleted.GetLevelCompletedCanvas().SetActive(true);
        Destroy(otherObject.gameObject);
    }

    private void PlayerCollectedBlueJewel(Collider2D otherObject)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        levelCompleted.GetLevelCompletedCanvas().SetActive(true);
        Destroy(otherObject.gameObject);
    }

    private void PlayerCollectedCoin(Collider2D otherObject)
    {
        soundManager.PlayCoinPickedSound();
        Destroy(otherObject.gameObject);
    }

    private void PlayerDied(GameObject player)
    {
        if(lifeManager.GetLifeCounter() > 0)
        {
            playerDied.GetPlayerDiedCanvas().SetActive(true);
            soundManager.PlayPlayerDeadSound();
            Destroy(player);
        }

        else
        {
            gameOver.GetGameOverCanvas().SetActive(true);
            soundManager.StopBackgroundMusic();
            soundManager.PlayGameOverSound();
            Destroy(player);
        }
    }
}