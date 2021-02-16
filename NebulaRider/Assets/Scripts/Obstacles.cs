using UnityEngine;

/// <summary>
/// CONTROLS SPAWNING OF OBSTACLES AND REUSING THEM
/// </summary>
public class Obstacles : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject[] obstacles = new GameObject[4];

    #endregion

    #region SPAWN || RESPAWN

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject a in obstacles)
        {
            //Respawn obstacles if they are too far behind or far from the player
            if ((PlayerMovement.PlayerLocation.z - a.transform.position.z) > 7)
            {
                a.transform.position = new Vector3(PlayerMovement.Lanes[Random.Range(0, 5)].x, 1.2f, PlayerMovement.PlayerLocation.z + 18);
                a.transform.rotation = Quaternion.identity;
                //a.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(Mathf.Abs((a.transform.position-PlayerMovement.PlayerLocation).magnitude)> 25)
            {
                a.transform.position = new Vector3(PlayerMovement.Lanes[Random.Range(0, 5)].x, 1.2f, PlayerMovement.PlayerLocation.z + 18);
                a.transform.rotation = Quaternion.identity;
                //a.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS