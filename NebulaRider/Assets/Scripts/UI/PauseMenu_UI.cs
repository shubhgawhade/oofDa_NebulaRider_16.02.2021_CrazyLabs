using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// BASIC UI UPDATE DURING GAMEPLAY
/// </summary>
public class PauseMenu_UI : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI timerDisplay;

    [SerializeField] TextMeshProUGUI speedBoostText;
    [SerializeField] TextMeshProUGUI invincibleText;

    #endregion

    #region PRIVATE VARIABLES

    private bool _isPaused;

    #endregion

    #region UPDATE

    // Update is called once per frame
    void Update()
    {
        //Displays the timer and updates values
        TimerCount();

        //Displays the lives and updates vaules
        LivesCount();

        //Displays the current state of the powerups
        PowerupUI();
    }

    #endregion

    #region PAUSE BUTTON

    public void PauseButton()
    {
        _isPaused = true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    #endregion

    #region MENU BUTTON

    public void MenuButton()
    {
        _isPaused = false;
        SceneManager.LoadScene(0);
    }

    #endregion

    #region RESUME BUTTON

    public void ResumeButton()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        _isPaused = false;
    }

    #endregion

    #region QUIT BUTTON

    public void QuitButton()
    {
        Application.Quit();
    }

    #endregion

    #region TIMER COUNT

    private void TimerCount()
    {
        timerDisplay.text = Timer.TimerDuration.ToString("#0.00" + "s");

        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    #endregion

    #region LIVES COUNT

    private void LivesCount()
    {
        livesText.text = "Lives: " + GameManager.Lives.ToString();
    }

    #endregion

    #region POWERUP

    private void PowerupUI()
    {
        if (Timer.SpeedBoost)
        {
            speedBoostText.color = Color.white;
            print("SPEED");
        }
        else if (Timer.Invincibile)
        {
            invincibleText.color = Color.white;
            print("INV");
        }
        else
        {
            speedBoostText.color = Color.grey;
            invincibleText.color = Color.grey;
        }
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS