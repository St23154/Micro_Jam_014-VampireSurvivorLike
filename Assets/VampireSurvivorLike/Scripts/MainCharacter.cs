using UnityEngine.SceneManagement;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MainCharacter : MonoBehaviour
{
    public float _speed = 2f;
    public float xp = 0;
    private float _maxXP = 50;
    public float _health = 100;
    public GameObject _arrows;
    private Vector3 _target;
    private GameObject _arrowsToDelete;
    public Camera _mainCamera;
    private Animator _animator;
    private LevelUp _levelupScript;
    private bool _isMolletteButtonDown = false;
    private bool _stop = false;
    private float _maxHealth;
    private bool _canTakeDamage = true;
    private float _time = 0;
    public Image _HealthBarFill;
    public Image _XPBarFill;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _levelupScript = GameObject.Find("Logic_manager").GetComponent<LevelUp>();
    }

    void Start()
    {
        UpdateXPBar();
        _health = 100;
        _maxHealth = _health;
        _speed = 2f;
    }
    // Update is called once per frame
    void Update()
    {
        //Click Detection
        if (Input.GetMouseButtonDown(0))
        {
            _isMolletteButtonDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMolletteButtonDown = false;
        }
        
        //Display arrows and set target where the player click

        if (_isMolletteButtonDown)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            Destroy(_arrowsToDelete);
            Instantiate(_arrows, _target, transform.rotation);
            _isMolletteButtonDown = false;
            _animator.SetBool("IsWalking", true);
            RotatePlayerAnimation(_target.x - transform.position.x, _target.y - transform.position.y);
            
        }

        //Move
    
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        //Destroy arrows if player is on
        
        if (transform.position == _target)
        {
            _arrowsToDelete = GameObject.FindGameObjectWithTag("ArrowPointer");
            _animator.SetBool("IsWalking", false);
            Destroy(_arrowsToDelete);
        }

        //Timer that allow player to take damage
        if (_canTakeDamage == false)
        {
            _time += Time.deltaTime;
            if (_time >= 1)
            {
                _canTakeDamage = true;
                _time = 0;     
            }
        }
    }

    private void RotatePlayerAnimation(float Xpos, float Ypos)
    {
        if ((Xpos != 0) || (Ypos != 0))
            {
                if (Xpos < 0)
                {
                    if (Xpos * - 1 > math.abs(Ypos))
                    {
                        _animator.SetFloat("X", -1);
                        _animator.SetFloat("Y", 0);
                    }
                }
                if (Ypos < 0)
                {
                    if (Ypos * - 1 > math.abs(Xpos))
                    {
                        _animator.SetFloat("Y", -1);
                        _animator.SetFloat("X", 0);
                    }
                }
                if (Xpos > 0)
                {
                    if (Xpos > math.abs(Ypos) )
                    {
                        _animator.SetFloat("X", 1);
                        _animator.SetFloat("Y", 0);
                    }
                }
                if (Ypos > 0)
                {
                    if (Ypos > math.abs(Xpos) )
                    {
                        _animator.SetFloat("Y", 1);
                        _animator.SetFloat("X", 0);
                    }
                }
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Coins _experience = other.GetComponent<Coins>();
        Ennemy_ZombieAI ZOMBIE = other.GetComponent<Ennemy_ZombieAI>();
        Enemy_BatAI BAT = other.GetComponent<Enemy_BatAI>();

        if(_experience != null)
        {
            _experience.Collect();
            AudioManager.instance.Play("Coin");
            xp += 10;
            UpdateXPBar();
            if (xp == _maxXP)
            {
                _levelupScript.MoreLevel();
                _maxXP *= 2;
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        Ennemy_ZombieAI ZOMBIE = other.GetComponent<Ennemy_ZombieAI>();
        Enemy_BatAI BAT = other.GetComponent<Enemy_BatAI>();

        if (ZOMBIE != null)
        {
            HeroTakeDamage(-30);
        }


        if (BAT != null)
        {
            HeroTakeDamage(-20);
        }
    }

    public void HeroTakeDamage(int _amount)
    {
        if (_canTakeDamage)
        {
            _health += _amount;
            AudioManager.instance.Play("GetHit");
            if (_health <= 0)
            {
                GameOver();
            }
            UpdateHealthBar();
            _canTakeDamage = false;
        }
    }

    public void UpdateHealthBar(){
        float targetFillAmount = _health / _maxHealth;
        _HealthBarFill.fillAmount = targetFillAmount;
    }

    private void GameOver()
    {
        AudioManager.instance.Play("GameOver");
        SceneManager.LoadSceneAsync(0);
    }

    public void UpdateXPBar()
    {
        float fillAmount = xp / _maxXP; 
        _XPBarFill.fillAmount = fillAmount;
    }

}
