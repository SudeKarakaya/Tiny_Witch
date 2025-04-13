using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Variables



    [Header("Movement Variables")]

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator playerAnim;
    [SerializeField] Transform playerDir;

    [SerializeField] Vector2 leftwardForce;
    [SerializeField] Vector2 rightwardForce;
    [SerializeField] Vector2 upwardForce;
    [SerializeField] Vector2 downwardForce;

    [SerializeField] bool isMoving;

    [Header("Game Variables")]

    [SerializeField] public int collectableAmount;
    [SerializeField] int maxCollectableAmount;

    [SerializeField] UIManager uIManager;
    [SerializeField] public float currentHealth;

    [SerializeField] bool isPaused;
    [SerializeField] bool isGameConcluded;

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject winPanel;

    //

    //Events

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        GameWon();
        PlayerMovement();

        if (currentHealth > 0)
        {
            currentHealth -= 5 * Time.deltaTime;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpauseGame();
        }

    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(leftwardForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(rightwardForce);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(upwardForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(downwardForce);
        }


        if (rb.velocity.x < -5)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }
        if (rb.velocity.x > 5)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }
        if (rb.velocity.y < -5)
        {
            rb.velocity = new Vector2(rb.velocity.x, -5);
        }
        if (rb.velocity.y > 5)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collectable>())
        {
            if (collision.GetComponent<Collectable>().isCauldron)
            {
                collectableAmount++;
                collision.GetComponent<Collectable>().CollectThis();
                uIManager.DisplayCollected();
            }
            else
            {
                currentHealth += 20;
                if (currentHealth > 100)
                {
                    currentHealth = 100;
                }
                collision.GetComponent<Collectable>().CollectThis();
            }

        }
    }
    //


    // Methods

    public void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            playerAnim.SetBool("isWalking", true);
            playerDir.eulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            playerAnim.SetBool("isWalking", true);
            playerDir.eulerAngles = new Vector3(0, 0, -90);
        }

        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            playerAnim.SetBool("isWalking", true);
            playerDir.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            playerAnim.SetBool("isWalking", true);
            playerDir.eulerAngles = new Vector3(0, 0, 180);
        }



        if (Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
            playerAnim.SetBool("isWalking", false);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
            playerAnim.SetBool("isWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
            playerAnim.SetBool("isWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isMoving = false;
            playerAnim.SetBool("isWalking", false);
        }



        if (!isMoving)
        {
            rb.velocity = Vector2.zero;
        }


    }



    public void PauseUnpauseGame()
    {
        if (!isPaused)
        {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
            isPaused = true;
            return;
        }
        else
        {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

        }
         
    }
 

    public void QuitGame()
    {
        Application.Quit();
    }


    void GameOver()
    {
        if (currentHealth == 0 && !isGameConcluded)
        {
            failPanel.SetActive(true);
            Time.timeScale = 0;
            isGameConcluded = true;
        }
    }

    void GameWon()
    {
        if(collectableAmount == maxCollectableAmount && !isGameConcluded)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
            isGameConcluded = true;
        }
    }


    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_1");
    }



    //

}


   



