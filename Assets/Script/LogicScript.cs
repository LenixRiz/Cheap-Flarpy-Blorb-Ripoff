using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public int playerScore = 0;
    public Text gameScore;

    [ContextMenu("IncreaseScore")] //Create an enum on component
    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
        gameScore.text = playerScore.ToString();
        dingSFX.Play();
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
