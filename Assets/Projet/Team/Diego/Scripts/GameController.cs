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
    public bool finish=true;
    


    #endregion

    #region Public void

    #endregion

    #region System

    void Start ()
    {
        
    }

    void Update ()
    {
        if (finish)
        {
            _BoucleDestruct();
        }
        
        _textScore.text = score.ToString();
    }

    #endregion

    #region Tools Debug and Utility

    public void _BoucleDestruct()
    {
        Debug.Log(_player.scoringObjectList.Count);
        if (_player.scoringObjectList.Count > 0)
        {

            finish = false;
            for (int i=0; i < _player.scoringObjectList.Count;i++){

                GameObject gobj = _player.scoringObjectList[i];
                EnumObject enumObj = gobj.GetComponent<EnumObject>();

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
          
            finish = true;
            Debug.Log(score);
            if (!(_player.scoringObjectList==null))
            {
                _player.DestroyScoring();
                Debug.Log(_player.scoringObjectList.Count);
            }
            
        }
    }

    #endregion

    
}
