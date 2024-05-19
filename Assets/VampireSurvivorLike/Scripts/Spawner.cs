using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _spawner1;
    public GameObject _spawner2;
    public GameObject _spawner3;
    public GameObject _spawner4;
    public GameObject _zombie;
    public GameObject _bat;
    public TextMeshProUGUI _waveUIText;
    public GameObject _meshZone;
    public Canvas _cameraCanvas;
    public float _timeBetweenEachWaves;
    private float _time = 25;
    private float i = 0;
    private List<int> _zombieList = new List<int>();
    private List<int> _batList = new List<int>();
    private List<GameObject> _spawnerList = new List<GameObject>();
    private int _spawnerChoice;
    private int _wave;
    private float _difficulty;
    public GameObject _logicManager;
    public GameObject _lineTuto;
    public GameObject _triangleTuto;
    public GameObject _squareTuto;
    PauseMenuScript _pauseManager;

    [Header("Wave - 1")]
    [SerializeField]
    private int _zombie1;
    [SerializeField]
    private int _bat1;

    [Header("Wave - 2")]
    [SerializeField]
    private int _zombie2;
    [SerializeField]
    private int _bat2;

    [Header("Wave - 3")]
    [SerializeField]
    private int _zombie3;
    [SerializeField]
    private int _bat3;

    [Header("Wave - 4")]
    [SerializeField]
    private int _zombie4;
    [SerializeField]
    private int _bat4;

    [Header("Wave - 5")]
    [SerializeField]
    private int _zombie5;
    [SerializeField]
    private int _bat5;

    [Header("Wave - 6")]
    [SerializeField]
    private int _zombie6;
    [SerializeField]
    private int _bat6;

    [Header("Wave - 7")]
    [SerializeField]
    private int _zombie7;
    [SerializeField]
    private int _bat7;

    [Header("Wave - 8")]
    [SerializeField]
    private int _zombie8;
    [SerializeField]
    private int _bat8;

    [Header("Wave - 9")]
    [SerializeField]
    private int _zombie9;
    [SerializeField]
    private int _bat9;

    [Header("Wave - 10")]
    [SerializeField]
    private int _zombie10;
    [SerializeField]
    private int _bat10;

    void Start()
    {
        _pauseManager = GameObject.Find("Logic_manager").GetComponent<PauseMenuScript>();
        if (LogicScriptMenu._Difficulté != 0)
        {
            _difficulty = LogicScriptMenu._Difficulté;
        }
        else
        {
            _difficulty = 1;
        }
        _wave = 1;
        _zombieList.Add(_zombie1);
        _zombieList.Add(_zombie2);
        _zombieList.Add(_zombie3);
        _zombieList.Add(_zombie4);
        _zombieList.Add(_zombie5);
        _zombieList.Add(_zombie6);
        _zombieList.Add(_zombie7);
        _zombieList.Add(_zombie8);
        _zombieList.Add(_zombie9);
        _zombieList.Add(_zombie10);
        _batList.Add(_bat1);
        _batList.Add(_bat2);
        _batList.Add(_bat3);
        _batList.Add(_bat4);
        _batList.Add(_bat5);
        _batList.Add(_bat6);
        _batList.Add(_bat7);
        _batList.Add(_bat8);
        _batList.Add(_bat9);
        _batList.Add(_bat10);
        _spawnerList.Add(_spawner1);
        _spawnerList.Add(_spawner2);
        _spawnerList.Add(_spawner3);
        _spawnerList.Add(_spawner4);
        _meshZone.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeBetweenEachWaves)
        {
            if (_wave == 2)
            {
                _lineTuto.SetActive(true);
                _pauseManager.Pause();
            }
            if (_wave == 4)
            {
                _triangleTuto.SetActive(true);
                _pauseManager.Pause();
            }
            if (_wave == 6)
            {
                _squareTuto.SetActive(true);
                _pauseManager.Pause();
            }
            _waveUIText.text = "Wave " + _wave;
            Instantiate(_waveUIText, transform.position, transform.rotation, _cameraCanvas.transform);
            for(i=0; i< (_zombieList[_wave-1] * _difficulty ); i++)
            {
                _spawnerChoice = UnityEngine.Random.Range(0,3);
                if (_spawnerChoice == 0 || _spawnerChoice == 1)
                {
                    Instantiate(_zombie, new Vector3(_spawnerList[_spawnerChoice].transform.position.x, 
                    _spawnerList[_spawnerChoice].transform.position.y + UnityEngine.Random.Range(10,-10), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(_zombie, new Vector3(_spawnerList[_spawnerChoice].transform.position.x 
                    + UnityEngine.Random.Range(18,-18), _spawnerList[_spawnerChoice].transform.position.y , transform.position.z), transform.rotation);
                }
            }
            for(i=0; i< (_batList[_wave-1] * _difficulty); i++)
            {
                _spawnerChoice = UnityEngine.Random.Range(0,3);
                if (_spawnerChoice == 0 || _spawnerChoice == 1)
                {
                    Instantiate(_bat, new Vector3(_spawnerList[_spawnerChoice].transform.position.x, 
                    _spawnerList[_spawnerChoice].transform.position.y + UnityEngine.Random.Range(10,-10), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(_bat, new Vector3(_spawnerList[_spawnerChoice].transform.position.x 
                    + UnityEngine.Random.Range(18,-18), _spawnerList[_spawnerChoice].transform.position.y , transform.position.z), transform.rotation);
                }
            }
            _time = 0;  
            _wave += 1; 
        }
    }
}
