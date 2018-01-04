using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Private and Protected Members

    #endregion
    #region Public Members
    public int score = 0;
    public Player _player;
    public EnumObject enumObj;

    


    #endregion

    #region Public void

    #endregion

    #region System

    void Start ()
    {

    }

    void Update ()
    {
        _BoucleDestruct();
    }

    #endregion

    #region Tools Debug and Utility

    public void _BoucleDestruct()
    {
        if (_player.scoringObjectList.Count > 0)
        {

            int testboucle = 0;
            foreach (GameObject _Object in _player.scoringObjectList)

            {
                EnumObject enumObj = _Object.GetComponent<EnumObject>();

                if (enumObj.m_ScoringObjects.ToString() == "PacBall")
                {

                    Debug.Log("PacBall");
                    score++;
                }
                if (enumObj.m_ScoringObjects.ToString() == "PacGum")
                {

                    Debug.Log("PacGum");
                }
                if (enumObj.m_ScoringObjects.ToString() == "Bonus")
                {

                    Debug.Log("Bonus");
                }
                if (enumObj.m_ScoringObjects.ToString() == "Enemy")
                {

                    Debug.Log("Enemy");
                }

                if (_player.scoringObjectList.Count == 1)
                {
                    Debug.Log("ok");
                    score++;
                    
                }

                testboucle++;

            }
            Debug.Log("Mon test boucle ="+ testboucle);
            _player.DestroyScoring();
        }
    }

    #endregion

    
}
