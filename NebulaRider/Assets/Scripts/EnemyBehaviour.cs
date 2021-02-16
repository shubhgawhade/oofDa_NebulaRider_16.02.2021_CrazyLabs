using UnityEngine;

/// <summary>
/// COLLISION CODE FOR ENEMIES
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] GameObject EnemyExplosion;

    #endregion

    #region COLLISION MANAGEMENT

    //Called hwen the enemy collides with another 
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Enemy":
                //Resets the object
                collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.zero);
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.zero);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                
                //Particle system instantiation
                Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
                break;

            case "Obstacle":
                Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
                break;
        }

        //Disables objects active in collision
        gameObject.SetActive(false);
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS