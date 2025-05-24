using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import TextMeshPro namespace

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int health = 5;
    private int score = 0;

    private Rigidbody rb;
    public TMP_Text scoreText;  // Use TMP_Text for TextMeshPro UI

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();  // Initialize score display
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
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
            Debug.Log("Health: " + health);
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
}

