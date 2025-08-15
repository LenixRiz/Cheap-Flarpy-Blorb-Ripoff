using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidbody2D;
    public LogicScript logicScript;
    public TextMeshProUGUI gameText;
    public float flapStrength = 5f;
    private bool isWarned = false;
    private float warningCooldown = 1f;
    private float warningTimer = 0f;
    public bool birdIsAlive = true;
    private float gameTextTime = 1;
    private float topGameDeadZone = 30;
    private float bottomGameDeadZone = -30;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Yoga Manuk";
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (birdRigidbody2D != null)
        {
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
            {
                GameTextActive(true);
                gameText.color = Color.green;
                gameText.text = "You pressed Spacebar!";
                birdRigidbody2D.linearVelocity = Vector2.up * flapStrength;
                warningTimer = 0f; // reset timer kalau tekan space
                gameTextTime -= Time.deltaTime;

                if (gameTextTime <= 0)
                {
                    GameTextActive(false);
                    gameTextTime = 1;
                }
            }
            else if (Keyboard.current == null)
            {
                Debug.LogWarning("Keyboard is not recognized by Unity.");
            }
            else
            {
                warningTimer += Time.deltaTime;
                if (warningTimer >= warningCooldown)
                {
                    GameTextActive(true);
                    gameText.gameObject.SetActive(true);
                    gameText.color = Color.red;
                    gameText.text = "Press Spacebar to flap!";
                    Debug.LogWarning("Player did not press space.");
                    warningTimer = 0f; // reset biar nunggu 1 detik lagi
                    gameTextTime -= Time.deltaTime;

                    if (gameTextTime <= 0)
                    {
                        GameTextActive(false);
                        gameTextTime = 1;
                    }
                }
            }
        }
        else
        {
            if (!isWarned)
            {
                Debug.LogWarning("Rigidbody 2D not yet referenced.");
                isWarned = true;
            }
        }

        if (gameObject.transform.position.y >= topGameDeadZone || gameObject.transform.position.y <= bottomGameDeadZone)
        {
            logicScript.GameOver();
            birdIsAlive = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }

    void GameTextActive(bool isActive)
    {
        gameText.gameObject.SetActive(isActive);
    }

}
