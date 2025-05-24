using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Required for TextMeshPro

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int health = 5;
    public TMP_Text scoreText;  // Reference to score display
    public TMP_Text healthText; // Reference to health display

    private int score = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();   // Initialize score text
        SetHealthText();  // Initialize health text
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
            // Debug.Log("Health: " + health); // Optional: comment out log
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
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
