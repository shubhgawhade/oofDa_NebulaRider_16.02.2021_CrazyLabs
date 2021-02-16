using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// LANDING PAGE USER INTERFACE
/// </summary>
public class Scene01_UI : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject landingPage;
    [SerializeField] GameObject debugMenu;

    [Space]
    [Header("LEVEL VARIABLES")]
    [Header("")]
    [SerializeField] Slider levelSlider;
    [SerializeField] TextMeshProUGUI levelTextValue;

    [Space]
    [Header("FOV VARIABLES")]
    [Header("")]
    [SerializeField] Slider fovSlider;
    [SerializeField] TextMeshProUGUI fovTextValue;

    [Space]
    [Header("DOUBLE TAP THRESHOLD VARIABLES")]
    [Header("")]
    [SerializeField] Slider doubleTapThresholdSlider;
    [SerializeField] TextMeshProUGUI doubleTapThresholdTextValue;

    [Space]
    [Header("PLAYER SPEED VARIABLES")]
    [Header("")]
    [SerializeField] Slider playerSpeedSlider;
    [SerializeField] TextMeshProUGUI playerSpeedTextValue;

    [Space]
    [Header("PLAYER SIDEWAYS SPEED VARIABLES")]
    [Header("")]
    [SerializeField] Slider playerSidewaysSpeedSlider;
    [SerializeField] TextMeshProUGUI playerSidewaysSpeedTextValue;

    [Space]
    [Header("PLAYER JUMP SPEED VARIABLES")]
    [Header("")]
    [SerializeField] Slider playerJumpSpeedSlider;
    [SerializeField] TextMeshProUGUI playerJumpSpeedTextValue;

    [Space]
    [Header("ENEMY SPEED VARIABLES")]
    [Header("")]
    [SerializeField] Slider enemySpeedSlider;
    [SerializeField] TextMeshProUGUI enemySpeedTextValue;

    [Space]
    [Header("ENEMY SPAWN DISTANCE VARIABLES")]
    [Header("")]
    [SerializeField] Slider enemySpawnDistanceSlider;
    [SerializeField] TextMeshProUGUI enemySpawnDistanceTextValue;

    [Space]
    [Header("ENEMY MAX DISTANCE VARIABLES")]
    [Header("")]
    [SerializeField] Slider enemyMaxDistanceSlider;
    [SerializeField] TextMeshProUGUI enemyMaxDistanceTextValue;

    [Space]
    [Header("ENEMY ATTACK FORCE VARIABLES")]
    [Header("")]
    [SerializeField] Slider enemyAttackForceSlider;
    [SerializeField] TextMeshProUGUI enemyAttackForceTextValue;

    [Space]
    [Header("INFINITE LIVES")]
    [Header("")]
    [SerializeField] Toggle infiniteLives;

    #endregion

    #region START BUTTON

    public void StartButton()
    {
        //print(GameManager.Level);
        switch (GameManager.Level)
        {
            case 1:
                GameManager.Level = 1;
                SceneManager.LoadScene(1);
                break;

            case 2:
                SceneManager.LoadScene(2);
                break;

            case 3:
                SceneManager.LoadScene(3);
                break;

            default:
                GameManager.Level = 1;
                SceneManager.LoadScene(1);
                break;
        }
    }

    #endregion

    #region DEBUG MENU BUTTON

    public void DebugMenuButton()
    {
        landingPage.SetActive(false);
        debugMenu.SetActive(true);

        #region LEVEL
        levelSlider.value = GameManager.Level;
        #endregion

        #region FOV
        fovSlider.value = GameManager.FOV;
        fovTextValue.text = GameManager.FOV.ToString("#0.00");
        #endregion

        #region DOUBLE TAP THRESHOLD
        doubleTapThresholdSlider.value = GameManager.DoubleTapThreshold;
        doubleTapThresholdTextValue.text = GameManager.DoubleTapThreshold.ToString("#0.00");
        #endregion

        #region PLAYER SPEED
        playerSpeedSlider.value = GameManager.PlayerSpeed;
        playerSpeedTextValue.text = GameManager.PlayerSpeed.ToString("#0.00");
        #endregion

        #region PLAYER SIDEWAYS SPEED
        playerSidewaysSpeedSlider.value = GameManager.PlayerSidewaysSpeed;
        playerSidewaysSpeedTextValue.text = GameManager.PlayerSidewaysSpeed.ToString("#0.00");
        #endregion

        #region PLAYER JUMP SPEED
        playerJumpSpeedSlider.value = GameManager.PlayerJumpSpeed;
        playerJumpSpeedTextValue.text = GameManager.PlayerJumpSpeed.ToString("#0.00");
        #endregion

        #region ENEMY SPEED
        enemySpeedSlider.value = GameManager.EnemySpeed;
        enemySpeedTextValue.text = GameManager.EnemySpeed.ToString("#0.00");
        #endregion

        #region ENEMY SPAWN DISTANCE
        enemySpawnDistanceSlider.value = GameManager.EnemySpawnDistance;
        enemySpawnDistanceTextValue.text = GameManager.EnemySpawnDistance.ToString("#0.00");
        #endregion

        #region ENEMY MAX DISTANCE
        enemyMaxDistanceSlider.value = GameManager.EnemyMaxDistance;
        enemyMaxDistanceTextValue.text = GameManager.EnemyMaxDistance.ToString("#0.00");
        #endregion

        #region ENEMY ATTACK FORCE
        enemyAttackForceSlider.value = GameManager.EnemyAttackForce;
        enemyAttackForceTextValue.text = GameManager.EnemyAttackForce.ToString("#0.00");
        #endregion

        #region INFINITE LIVES
        infiniteLives.isOn = GameManager.InfiniteLives;
        #endregion
    }

    #endregion

    #region QUIT BUTTON

    public void QuitButton()
    {
        Application.Quit();
    }

    #endregion

    #region DEBUG MENU CHANGES

    public void LevelChange()
    {
        GameManager.Level = int.Parse(levelSlider.value.ToString());
        levelTextValue.text = GameManager.Level.ToString();
    }

    public void FOVChange()
    {
        GameManager.FOV = fovSlider.value;
        fovTextValue.text = GameManager.FOV.ToString("#0.00");
    }

    public void DoubleTapThresholdChange()
    {
        GameManager.DoubleTapThreshold = doubleTapThresholdSlider.value;
        doubleTapThresholdTextValue.text = GameManager.DoubleTapThreshold.ToString("#0.00");
    }

    public void PlayerSpeedChange()
    {
        GameManager.PlayerSpeed = playerSpeedSlider.value;
        playerSpeedTextValue.text = GameManager.PlayerSpeed.ToString("#0.00");
    }

    public void PlayerSidewaysSpeedChange()
    {
        GameManager.PlayerSidewaysSpeed = playerSidewaysSpeedSlider.value;
        playerSidewaysSpeedTextValue.text = GameManager.PlayerSidewaysSpeed.ToString("#0.00");
    }

    public void PlayerJumpSpeedChange()
    {
        GameManager.PlayerJumpSpeed = playerJumpSpeedSlider.value;
        playerJumpSpeedTextValue.text = GameManager.PlayerJumpSpeed.ToString("#0.00");
    }

    public void EnemySpeedChange()
    {
        GameManager.EnemySpeed = enemySpeedSlider.value;
        enemySpeedTextValue.text = GameManager.EnemySpeed.ToString("#0.00");
    }

    public void EnemySpawnDistanceChange()
    {
        GameManager.EnemySpawnDistance = enemySpawnDistanceSlider.value;
        enemySpawnDistanceTextValue.text = GameManager.EnemySpawnDistance.ToString("#0.00");
    }

    public void EnemyMaxDistanceChange()
    {
        GameManager.EnemyMaxDistance = enemyMaxDistanceSlider.value;
        enemyMaxDistanceTextValue.text = GameManager.EnemyMaxDistance.ToString("#0.00");
    }

    public void EnemyAttackForceChange()
    {
        GameManager.EnemyAttackForce = enemyAttackForceSlider.value;
        enemyAttackForceTextValue.text = GameManager.EnemyAttackForce.ToString("#0.00");
    }

    public void InfiniteLives()
    {
        if (infiniteLives.isOn)
        {
            GameManager.InfiniteLives = true;
            GameManager.Lives = 0;
        }
        else
        {
            GameManager.InfiniteLives = false;
            GameManager.Lives = 5;
        }
    }

    #endregion

    #region DEBUG MENU BACK BUTTON

    public void DebugMenuBack()
    {
        landingPage.SetActive(true);
        debugMenu.SetActive(false);
    }

    #endregion

    #region RESET BUTTON

    public void ResetButton()
    {
        GameManager.Level = 1;
        GameManager.FOV = 100;
        GameManager.DoubleTapThreshold = 0.5f;
        GameManager.PlayerSpeed = 5;
        GameManager.PlayerSidewaysSpeed = 10;
        GameManager.PlayerJumpSpeed = 10;
        GameManager.EnemySpeed = 5.5f;
        GameManager.EnemySpawnDistance = 8;
        GameManager.EnemyMaxDistance = 25;
        GameManager.EnemyAttackForce = 500;
        GameManager.InfiniteLives = false;

        DebugMenuButton();
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS