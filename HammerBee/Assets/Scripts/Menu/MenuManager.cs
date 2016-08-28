using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public AudioClip btnClick;
    AudioSource menuAudio;

	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        menuAudio = GetComponent<AudioSource>();

	}
	
	public void ExitPress()
    {
        menuAudio.PlayOneShot(btnClick, 1f);
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        menuAudio.PlayOneShot(btnClick, 1f);
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        menuAudio.PlayOneShot(btnClick, 1f);
        SceneManager.LoadScene("House");
    }

    public void ExitGame()
    {
        menuAudio.PlayOneShot(btnClick, 1f);
        Application.Quit();
    }

}
