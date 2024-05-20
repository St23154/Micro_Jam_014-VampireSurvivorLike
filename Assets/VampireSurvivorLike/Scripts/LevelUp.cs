using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    PauseMenuScript _pauseManager;
    private string ch1;
    private string ch2;
    private string ch3;
    public List<string> _effectsList;
    private int _scoreForLevelUp = 0;
    private int i;
    private List<string> _choice1list;
    private List<string> _choice2list;
    private List<string> _choice3list;
    private string _choice1;
    private string _choice2;
    private string _choice3;
    public GameObject _mainPlayer;
    public GameObject _bullet;
    public GameObject _gun;
    public GameObject _logicManager;

    [Header("Boost")]
    public float _damageToAdd = 100;
    public float _speedToAdd = 10;
    public float _bulletPerSecondToAdd = 3;
    public float _healthToAdd = 30;
    public float _slownessToAdd = 3;
    

    private void Awake()
    {
        _pauseManager = GameObject.Find("Logic_manager").GetComponent<PauseMenuScript>();
    }

    void Start()
    {
        _effectsList = new List<string>{"Speed", "RateOfFire", "Life", "TimeToDraw"};
    }

    public void CloseLevelUp()
    {
        _pauseManager.Resume();
        panel.SetActive(false);
    }
    
    public void OpenLevelUp(string choice1, string choice2, string choice3)
    {
        text1.text = choice1;
        text2.text = choice2;
        text3.text = choice3;
        ch1 = choice1;
        ch2 = choice2;
        ch3 = choice3;
        _pauseManager.Pause();
        panel.SetActive(true);
    }

    public void Choix1()
    {
        Debug.Log("choix1 : " + ch1);
        if (ch1 == "Speed")
        {
            Debug.Log("Speed actual : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
            _mainPlayer.GetComponent<MainCharacter>()._speed += _speedToAdd;
            Debug.Log("Now : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
        }
        else if (ch1 == "RateOfFire")
        {
            Debug.Log("Rate : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
            _gun.GetComponent<GunPivotScript>()._bulletPerSecond += _bulletPerSecondToAdd;
            Debug.Log("Now : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
        }
        else if (ch1 == "Life")
        {
            Debug.Log("Life");
            _mainPlayer.GetComponent<MainCharacter>()._health += _healthToAdd;
            _mainPlayer.GetComponent<MainCharacter>().UpdateHealthBar();
            Debug.Log("good");
        }
        else if (ch1 == "TimeToDraw")
        {
            Debug.Log("TmDr");
            _logicManager.GetComponent<LogicScript>()._slowness += _slownessToAdd;
            Debug.Log("good");
        }
        else
        {
            Debug.Log("rien");
        }
    }

    public void Choix2()
    {
        if (ch2 == "Speed")
        {
            Debug.Log("Speed actual : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
            _mainPlayer.GetComponent<MainCharacter>()._speed += _speedToAdd;
            Debug.Log("Now : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
        }
        else if (ch2 == "RateOfFire")
        {
            Debug.Log("Rate : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
            _gun.GetComponent<GunPivotScript>()._bulletPerSecond += _bulletPerSecondToAdd;
            Debug.Log("Now : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
        }
        else if (ch2 == "Life")
        {
            _mainPlayer.GetComponent<MainCharacter>()._health += _healthToAdd;
            _mainPlayer.GetComponent<MainCharacter>().UpdateHealthBar();
        }
        else if (ch2 == "TimeToDraw")
        {
            _logicManager.GetComponent<LogicScript>()._slowness += _slownessToAdd;
        }
    }

    public void Choix3()
    {
        if (ch3 == "Speed")
        {
            Debug.Log("Speed actual : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
            _mainPlayer.GetComponent<MainCharacter>()._speed += _speedToAdd;
            Debug.Log("Now : " + _mainPlayer.GetComponent<MainCharacter>()._speed);
        }
        else if (ch3 == "RateOfFire")
        {
            Debug.Log("Rate : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
            _gun.GetComponent<GunPivotScript>()._bulletPerSecond += _bulletPerSecondToAdd;
            Debug.Log("Now : " + _gun.GetComponent<GunPivotScript>()._bulletPerSecond);
        }
        else if (ch3 == "Life")
        {
            _mainPlayer.GetComponent<MainCharacter>()._health += _healthToAdd;
            _mainPlayer.GetComponent<MainCharacter>().UpdateHealthBar();
        }
        else if (ch3 == "TimeToDraw")
        {
            _logicManager.GetComponent<LogicScript>()._slowness += _slownessToAdd;
        }
    }

    public void MoreLevel()
    {
        // Tout ca ca choisis juste 3 choix parmis la liste effect, ils sont différents
        _choice1list = _effectsList;
        _choice1 = _choice1list[UnityEngine.Random.Range(0,_choice1list.Count)];
        _choice2list = new List<string>();
        _choice3list = new List<string>();
        
        for (int a = 0; a < _choice1list.Count; a++)
        {
            if(_choice1list[a] != _choice1)
            {
               _choice2list.Add(_choice1list[a]);
            }
        }
  
        _choice2 = _choice2list[UnityEngine.Random.Range(0,_choice2list.Count)];
        for (int a = 0; a < _choice2list.Count; a++)
        {
            if(_choice2list[a] != _choice2)
            {
                _choice3list.Add(_choice2list[a]);
            }
        }
        _choice3 = _choice3list[UnityEngine.Random.Range(0,_choice3list.Count)];

        // Puis ca open le level Up avec les 3 choixs

        OpenLevelUp(_choice1,_choice2,_choice3);
    }
}
