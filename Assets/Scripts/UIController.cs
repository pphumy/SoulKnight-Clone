using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider healthSlider;
    public Text healthText;
    public GameObject deathScreen;
    public GameObject completedScreen;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public bool isPause;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        PauseUnpause();
    }
    public void ReturToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
    public void PauseUnpause()
    {
        if (!isPause)
        {
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
            isPause = true;
            AudioManager.instance.levelMusic.Pause();
            Time.timeScale = 0f;

        }
        else
        {
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            isPause = false;
            AudioManager.instance.levelMusic.UnPause();
            Time.timeScale = 1f;
            
        }
    }
}
