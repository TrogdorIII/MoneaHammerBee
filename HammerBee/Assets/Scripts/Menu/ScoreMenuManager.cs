using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreMenuManager : MonoBehaviour
{

    public Button startText;
    public Button exitText;
    public Text scoreText;

    void Awake()
    {
        scoreText.text = PlayerPrefs.GetFloat("score").ToString();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Use this for initialization
    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();

    }

    public void ExitPress()
    {
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        Destroy(Game.GameManager.instance.gameObject);
        SceneManager.LoadScene("House");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
