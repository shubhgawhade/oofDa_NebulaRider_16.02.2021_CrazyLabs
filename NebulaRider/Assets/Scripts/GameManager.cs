using UnityEngine;

/// <summary>
/// GAME MANAGER FOR VARIABLES AND THEIR DEFAULT VALUES
/// </summary>
public class GameManager : MonoBehaviour
{
    #region STATIC VARIABLES
    public static int Level { get; set; }

    public static int Lives { get; set; }
    public static bool InfiniteLives { get; set; }
    public static float WinningCondition { get; set; }

    public static float FOV { get; set; }
    public static float DoubleTapThreshold { get; set; }
    public static float PlayerSpeed { get; set; }
    public static float PlayerSidewaysSpeed { get; set; }
    public static float PlayerJumpSpeed { get; set; }
    public static float EnemySpeed { get; set; }
    public static float EnemySpawnDistance { get; set; }
    public static float EnemyMaxDistance { get; set; }
    public static float EnemyAttackForce { get; set; }

    public static bool called;

    #endregion

    #region INITITALIZE VALUES

    // Start is called before the first frame update
    void Start()
    {
        //Initializes default values
        if (!called)
        {
            GameManager.Lives = 5;
            GameManager.FOV = 100;
            GameManager.DoubleTapThreshold = 0.5f;
            GameManager.PlayerSpeed = 5;
            GameManager.PlayerSidewaysSpeed = 10;
            GameManager.PlayerJumpSpeed = 10;
            GameManager.EnemySpeed = 5.5f;
            GameManager.EnemySpawnDistance = 8;
            GameManager.EnemyMaxDistance = 25;
            GameManager.EnemyAttackForce = 500;
            called = true;
        }

        //Sets the FOV of the camera
        Camera.main.fieldOfView = FOV;
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS