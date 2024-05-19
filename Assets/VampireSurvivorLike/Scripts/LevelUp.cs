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

    private void Awake()
    {
        _pauseManager = GameObject.Find("Logic_manager").GetComponent<PauseMenuScript>();
    }

    void Start()
    {
        _effectsList = new List<string>{"speed", "damage", "rotation", "tirfois3"};
    }

    public void CloseLevelUp()
    {
        _pauseManager.Resume();
        panel.SetActive(false);
    }
    
    public void OpenLevelUp(string choice1, string choice2, string choice3)
    {
        _pauseManager.Pause();
        panel.SetActive(true);
        text1.text = choice1;
        text2.text = choice2;
        text3.text = choice3;
        ch1 = choice1;
        ch2 = choice2;
        ch3 = choice3;
    }

    public void Choix1()
    {
        if (ch1 == "damage")
        {

        }
        else if (ch1 == "speed")
        {

        }
        else if (ch1 == "rotation")
        {

        }
        else if (ch1 == "tirfois3")
        {

        }
    }

    public void Choix2()
    {
        if (ch2 == "damage")
        {

        }
        else if (ch2 == "speed")
        {
 
        }
        else if (ch2 == "rotation")
        {

        }
        else if (ch2 == "tirfois3")
        {

        }
    }

    public void Choix3()
    {
        if (ch3 == "damage")
        {

        }
        else if (ch3 == "speed")
        {

        }
        else if (ch3 == "rotation")
        {
 
        }
        else if (ch3 == "tirfois3")
        {

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
