using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;  // Required for Image

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int health = 5;

    public TMP_Text scoreText;       // Reference to score display
    public TMP_Text healthText;      // Reference to health display
    public TMP_Text winLoseText;     // Reference to Win/Lose Text
    public Image winLoseBG;          // Reference to background image (UI panel)

    private int score = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        SetHealthText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = 5;
            score = 0;
            SetScoreText();
            SetHealthText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            // Debug.Log("You win!");

            if (winLoseText != null)
            {
                winLoseText.text = "You Win!";
                winLoseText.color = Color.black;
            }

            if (winLoseBG != null)
            {
                winLoseBG.color = Color.green;
            }
        }
    }

    private void SetScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void SetHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
}
