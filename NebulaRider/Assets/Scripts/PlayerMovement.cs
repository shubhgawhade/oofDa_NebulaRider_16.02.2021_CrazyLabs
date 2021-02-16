using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// PLAYER MOVEMENT SCRIPT WHICH CONTROLS THE MOVEMENT AND INTERACTIONS WITH OTHER GAME OBJECTS
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region INSPECTOR VARIABLES

    [SerializeField] TrailRenderer boostTrail;
    [SerializeField] GameObject redExp;
    [SerializeField] MeshCollider meshCollider;

    #endregion
    
    #region STATIC VARIABLES

    public static Vector3 PlayerLocation;
    public static Vector3[] Lanes = new Vector3[5];

    #endregion

    #region PRIVATE VARIABLES

    private Vector2 _startPos;
    private Vector2 _endPos;
    private Vector2 _direction;
    
    private float _tempSpeed;
    private float _waitForTouch;
    private float _touchTime;
    
    private int _currentpath;
    private int _futurePath;
    
    private bool _left, _right, _jump, _isJumping;

    #endregion

    #region START

    // Start is called before the first frame update
    void Start()
    {
        //Actions are subscriber for timer related powerups
        Timer.ActionSpeedBoost += SpeedBoost;
        Timer.ActionInvincibility += Invincibility;
        
        //checks if infinite lives is not enabled before resetting lives to 5
        if (!GameManager.InfiniteLives)
        {
            GameManager.Lives = 5;
        }

        //Uses the original speed value when player is disabled mid-game during a powerup
        _tempSpeed = GameManager.PlayerSpeed;

        _currentpath = 2;
        _futurePath = 2;
        
        #region LANE ARRAY FILLER

        Lanes[0] = new Vector3(-10, 0, 0);
        Lanes[1] = new Vector3(-5, 0, 0);
        Lanes[2] = new Vector3(0, 0, 0);
        Lanes[3] = new Vector3(5, 0, 0);
        Lanes[4] = new Vector3(10, 0, 0);

        #endregion
    }

    #endregion

    #region FIXED UPDATE

    private void FixedUpdate()
    {
        //Direction to move the player
        Direction();

        PlayerLocation = transform.position;
    }

    #endregion

    #region UPDATE

    // Update is called once per frame
    void Update()
    {        
        //Moves the player forward
        transform.position += new Vector3(0, 0, GameManager.PlayerSpeed * Time.deltaTime);
        
        //Gets Input from the player
        TouchInput();
    }

    #endregion

    #region PLAYER INPUT

    public void TouchInput()
    {


        //Allows movement only when the previous move has been executed
        #region HORIZONTAL

        _waitForTouch += Time.deltaTime;
        
        if (Input.touchCount == 1 && !_right && !_left)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {   
                case TouchPhase.Began:
                    _touchTime = _waitForTouch;
                    _startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    break;

                case TouchPhase.Ended:
                    _endPos = touch.position;
                    
                    if (Mathf.Abs(_startPos.x - _endPos.x) > 100)
                    {
                        _direction = _startPos - _endPos;
                        if (_direction.x > 100)
                        {
                            if (_futurePath > 0)
                            {
                                _futurePath--;
                                _left = true;
                            }
                            //print("Left");
                        }
                        else if (_direction.x < -100)
                        {
                            if (_futurePath < 4)
                            {
                                _futurePath++;
                                _right = true;
                            }
                            //print("Right");
                        }
                    }
                    else if (Mathf.Abs((_startPos - _endPos).magnitude) < 100)
                    {
                        _waitForTouch = 0;

                        if (_touchTime < GameManager.DoubleTapThreshold && !_isJumping)
                        {
                            _jump = true;
                        }
                    }
                    break;
            }
        }

        #endregion

        //Player Jump
        #region VERTICAL

        if (_jump)
        {
            if(transform.position.y - 8 < 0.1f)
            {
                transform.position += Vector3.up * GameManager.PlayerJumpSpeed * Time.deltaTime;
                _isJumping = true;
            }
            else
            {
                _jump = false;
            }
        }
        else
        {
            if (transform.position.y -1.2f > 0.1f)
            {
                transform.position += Vector3.down * GameManager.PlayerJumpSpeed * Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        #endregion

    }
    
    #endregion

    #region RIGHT || LEFT

    private void Direction()
    {
        // Changes lanes depending on directions

        if (_right)
        {
            switch (_futurePath)
            {
                case 1:
                    if (Mathf.Abs(transform.position.x - Lanes[1].x) > 0.2f)
                    {
                        transform.position += Vector3.right * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath++;
                        _right = false;
                        break;
                    }
                    break;

                case 2:
                    if (Mathf.Abs(transform.position.x - Lanes[2].x) > 0.2f)
                    {
                        transform.position += Vector3.right * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath++;
                        _right = false;
                        break;
                    }
                    break;

                case 3:
                    if (Mathf.Abs(transform.position.x - Lanes[3].x) > 0.2f)
                    {
                        transform.position += Vector3.right * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath++;
                        _right = false;
                        break;
                    }
                    break;

                case 4:
                    if (Mathf.Abs(transform.position.x - Lanes[4].x) > 0.2f)
                    {
                        transform.position += Vector3.right * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath++;
                        _right = false;
                        break;
                    }
                    break;
            }
        }
        else if (_left)
        {
            switch (_futurePath)
            {
                case 0:
                    if (Mathf.Abs(transform.position.x - Lanes[0].x) > 0.2f)
                    {
                        transform.position += Vector3.left * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath--;
                        _left = false;
                        break;
                    }
                    break;

                case 1:
                    if (Mathf.Abs(transform.position.x - Lanes[1].x) > 0.2f)
                    {
                        transform.position += Vector3.left * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath--;
                        _left = false;
                        break;
                    }
                    break;

                case 2:
                    if (Mathf.Abs(transform.position.x - Lanes[2].x) > 0.2f)
                    {
                        transform.position += Vector3.left * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath--;
                        _left = false;
                        break;
                    }
                    break;

                case 3:
                    if (Mathf.Abs(transform.position.x - Lanes[3].x) > 0.2f)
                    {
                        transform.position += Vector3.left * GameManager.PlayerSidewaysSpeed * Time.deltaTime;
                    }
                    else
                    {
                        _currentpath--;
                        _left = false;
                        break;
                    }
                    break;
            }
        }

    }
    
    #endregion

    #region POWERUP EXECUTION

    //Speed boost 60 seconds into the game
    private void SpeedBoost()
    {
        boostTrail.emitting = true;
        GameManager.PlayerSpeed += 5;
        Timer.SpeedBoost = true;
        StartCoroutine("Wait");
    }

    //Invincibility 120 seconds into the game
    private void Invincibility()
    {
        meshCollider.enabled = false;
        Timer.Invincibile = true;
        StartCoroutine("Wait");
    }

    //Coroutine for the powerup to last 5 seconds
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        
        if (Timer.SpeedBoost)
        {
            print(GameManager.PlayerSpeed);
            GameManager.PlayerSpeed -= 5;
            boostTrail.emitting = false;
            Timer.SpeedBoost = false;
            Timer.ActionSpeedBoost -= SpeedBoost;
        }
        else if (Timer.Invincibile)
        {
            meshCollider.enabled = true;
            Timer.Invincibile = false;
            Timer.ActionInvincibility -= Invincibility;
        }
    }

    #endregion

    #region COLLISION MANAGEMENT

    //Called when player collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Obstacle"))
        {
            Instantiate(redExp, collision.transform.position, Quaternion.identity);
            if (GameManager.Lives > 0)
            {
                GameManager.Lives--;
                if (GameManager.Lives == 0)
                {
                    GameManager.Lives = 5;
                    SceneManager.LoadScene(GameManager.Level);
                }
            }
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.collider.CompareTag("Obstacle"))
        {
            collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, transform.position.z - GameManager.EnemyMaxDistance);
        }
    }

    #endregion

    #region ON DISABLE
    
    //Called when the player gets disabled
    private void OnDisable()
    {
        if(GameManager.PlayerSpeed != _tempSpeed)
        {
            GameManager.PlayerSpeed = _tempSpeed;
        }
        Timer.SpeedBoost = false;

        meshCollider.enabled = true;
        Timer.Invincibile = false;

        Timer.ActionSpeedBoost -= SpeedBoost;
        Timer.ActionInvincibility -= Invincibility;
    }

    #endregion
}

// FOR ASSIGNMENT PURPOSE ONLY UNDER oofDa STUDIOS