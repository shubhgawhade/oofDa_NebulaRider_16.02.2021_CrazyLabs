using UnityEngine;

/// <summary>
/// MOVES THE SIDE BOUDS ALONG WITH THE PLAYER
/// </summary>
public class Line : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject player;

    #endregion

    #region UPDATE

    // Update is called once per frame
    void Update()
    {
        //changes the Z positions of the side bounds
        transform.position = new Vector3(transform.position.x, transform.position.x, player.transform.position.z + 5);
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS