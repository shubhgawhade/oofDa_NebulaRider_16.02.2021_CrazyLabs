using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// RUNS TIMER FOR LEVELS
/// </summary>
public class Timer : MonoBehaviour
{
    #region STATIC VARIABLES

    public static float TimerDuration;
    public static bool SpeedBoost, Invincibile;

    #endregion

    #region ACTIONS

    public static Action ActionSpeedBoost;
    public static Action ActionInvincibility;

    #endregion

    #region START

    // Start is called before the first frame update
    void Start()
    {
        //sets powerups to false
        SpeedBoost = false;
        Invincibile = false;

        //changes timer values according to levels
        switch (GameManager.Level)
        {
            case 1:
                GameManager.WinningCondition = 60;
                break;

            case 2:
                GameManager.WinningCondition = 120;
                break;

            case 3:
                GameManager.WinningCondition = 180;
                break;

            case 4:
                GameManager.Level = 0;
                break;

            default:
                GameManager.WinningCondition = 60;
                break;
        }

        TimerDuration = GameManager.WinningCondition;
    }

    #endregion

    #region UPDATE

    // Update is called once per frame
    void Update()
    {
        #region RUNS THE TIMER

        if (TimerDuration > 0.1)
        {
            TimerDuration -= Time.deltaTime;
        }
        else
        {
            if (GameManager.Level < 3)
            {
                GameManager.Level++;
                SceneManager.LoadScene(GameManager.Level);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        #endregion

        #region TIMER AND LEVEL BASED POWERUPS

        if (TimerDuration < 60 && !SpeedBoost && !Invincibile)
        {
            switch (GameManager.Level)
            {
                case 2:
                    if (ActionSpeedBoost != null)
                    {
                        ActionSpeedBoost();
                    }
                    break;

                case 3:
                    if (ActionInvincibility != null)
                    {
                        ActionInvincibility();
                    }
                    break;
            }
        }

        if (GameManager.Level == 3 && TimerDuration < 120 && !SpeedBoost && !Invincibile)
        {
            if (ActionSpeedBoost != null)
            {
                ActionSpeedBoost();
            }
        }

        #endregion
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS