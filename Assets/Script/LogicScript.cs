using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public PipeSpawnerScript pipeSpawner;
    public int playerScore = 0;
    public Text gameScore;

    void Start()
    {
        pipeSpawner = GameObject.FindFirstObjectByType<PipeSpawnerScript>();
    }

    [ContextMenu("IncreaseScore")] //Create an enum on component
    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
        gameScore.text = playerScore.ToString();
        dingSFX.Play();
        AddDifficulty();
    }

    public void AddDifficulty()
    {
        if (playerScore >= 15)
        {
            pipeSpawner.moveSpeed = 48F;
            Debug.Log($"Pipe move speed increased to {pipeSpawner.moveSpeed}");
        }
        else if (playerScore >= 5)
        {
            pipeSpawner.moveSpeed = 24F;
            Debug.Log($"Pipe move speed increased to {pipeSpawner.moveSpeed}");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load the current scene
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
