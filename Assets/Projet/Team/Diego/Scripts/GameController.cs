using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Private and Protected Members

    #endregion
    #region Public Members
    public int score = 0;
    public Player _player;
    public Text _textScore;
    public GameObject _bonus;

    


    #endregion

    #region Public void

    #endregion

    #region System

    void Start ()
    {
        
    }

    void Update ()
    {
        _textScore.text = score.ToString();
        _BoucleDestruct();
    }

    #endregion

    #region Tools Debug and Utility

    public void _BoucleDestruct()
    {
        if (_player.scoringObjectList.Count > 0)
        {

            
            foreach (GameObject _Object in _player.scoringObjectList)

            {
                EnumObject enumObj = _Object.GetComponent<EnumObject>();

                if (enumObj.m_ScoringObjects.ToString() == "PacBall")
                { 
                    score++;
                }
                if (enumObj.m_ScoringObjects.ToString() == "PacGum")
                { 
                    score = score + 2;
                }
                if (enumObj.m_ScoringObjects.ToString() == "Bonus")
                {
                    _bonus.SetActive(true);
                    score = score + 5;
                }
                if (enumObj.m_ScoringObjects.ToString() == "Enemy")
                { 
                    score++;
                }

            }
           
            _player.DestroyScoring();
        }
    }

    #endregion

    
}
