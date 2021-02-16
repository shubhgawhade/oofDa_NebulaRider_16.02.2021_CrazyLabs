using UnityEngine;

/// <summary>
/// CONTROLS THE ENEMY BY ACTIVATING AND DEACTIVATING ENEMIES NO LONGER IN USE AND CHANGING THEIR SPRITES
/// </summary>
public class EnemyController : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject[] enemies = new GameObject[4];
    [SerializeField] Mesh spaceBall;
    [SerializeField] Mesh ufo;

    #endregion

    #region STATIC VARIABLES

    public static float ActiveEnemes;

    #endregion

    #region START

    // Start is called before the first frame update
    void Start()
    {
        //Number od enemies active in the scene
        ActiveEnemes = 4;
    }

    #endregion

    #region UPDATE

    // Update is called once per frame
    void Update()
    {
        #region ENEMY STATE

        //Loops through the enemies in the scene moving, deactivating and reactivating the enemy game objects
        foreach (GameObject a in enemies)
        {
            a.transform.position += new Vector3(0, 0, GameManager.EnemySpeed * Time.deltaTime);

            //Attacks the player if closeby
            if (a.transform.position.z > PlayerMovement.PlayerLocation.z - 4)
            {
                a.transform.LookAt(PlayerMovement.PlayerLocation);
                a.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * GameManager.EnemyAttackForce * Time.deltaTime);
            }

            //Setting enemy to active with new positions if disabled
            if (a.activeInHierarchy == false)
            {
                #region CHOOSING SPRITE TO SPAWN
                
                float rr = Random.Range(0.0f, 1f);

                if (rr > 0.5f)
                {
                    MeshCollider aa = a.gameObject.GetComponent<MeshCollider>();
                    aa.sharedMesh = spaceBall;
                    aa.enabled = true;
                    a.GetComponent<MeshFilter>().mesh = spaceBall;

                }
                else
                {
                    MeshCollider aa = a.gameObject.GetComponent<MeshCollider>();
                    aa.sharedMesh = ufo;
                    aa.enabled = true;

                    a.GetComponent<MeshFilter>().mesh = ufo;
                }

                #endregion

                a.transform.position = new Vector3(PlayerMovement.Lanes[Random.Range(0, 5)].x, 1.2f, PlayerMovement.PlayerLocation.z - GameManager.EnemySpawnDistance);
                a.transform.rotation = Quaternion.identity;
                a.GetComponent<Rigidbody>().velocity = Vector3.zero;
                a.SetActive(true);
            }

            //Deactivates enemy if its too far away from the player
            if (Mathf.Abs((PlayerMovement.PlayerLocation - a.transform.position).magnitude) > GameManager.EnemyMaxDistance)
            {
                a.SetActive(false);
            }
        }

        #endregion
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS