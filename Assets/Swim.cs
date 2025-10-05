using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Swim : MonoBehaviour
{
    [SerializeField] float swimSpeed = 1f;
    [SerializeField] float moveAmount = 1f;
    Label scoreText;
    Label youWinText;
    Rigidbody2D rb;
    [SerializeField] UIDocument uiDocument;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] GameObject followTarget;
    Button restartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        youWinText = uiDocument.rootVisualElement.Q<Label>("youWinText");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.clicked += ReloadScene;
        restartButton.style.display = DisplayStyle.None;
        youWinText.style.display = DisplayStyle.None;
    }

    void Update()
    {
        // Constant forward motion
        rb.linearVelocity = new Vector2(swimSpeed, rb.linearVelocity.y);

        // "Flap" upwards when pressing W or Up Arrow
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int coinIndexLayer = LayerMask.NameToLayer("Coin");

        if (layer == coinIndexLayer)
        {
            print("You collected a coin!");
            scoreText.text = "Score: " + (int.Parse(scoreText.text.Split(' ')[1]) + 1).ToString();
            Destroy(collision.gameObject);
        }
        else if (layer == LayerMask.NameToLayer("Target"))
        {
            print("You reached the target!");
            youWinText.style.display = DisplayStyle.Flex;
            youWinText.text = "You Win!\nScore: " + (int.Parse(scoreText.text.Split(' ')[1]) + 1).ToString();
            GameObject followTarget = GameObject.Find("followTarget");
            if (followTarget != null)
            {
                Move followScript = followTarget.GetComponent<Move>();
                if (followScript != null)
                    followScript.StopFollowing();
            }
            scoreText.style.display = DisplayStyle.None;
            swimSpeed = 0f;
        }
        else
        {
            print("You crashed!");
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            restartButton.style.display = DisplayStyle.Flex;

            GameObject followTarget = GameObject.Find("followTarget");
            if (followTarget != null)
            {
                Move followScript = followTarget.GetComponent<Move>();
                if (followScript != null)
                    followScript.StopFollowing();
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
