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
    public bool finish = true;



    #endregion

    #region Public void

    #endregion

    #region System

    void Start()
    {

    }

    void Update()
    {
        if (finish)
        {
            ScoreCount();
        }

        _textScore.text = score.ToString();
    }

    #endregion

    #region Tools Debug and Utility

    public void ScoreCount()
    {
        Debug.Log(_player.bonusList.Count);
        if (_player.bonusList.Count > 0)
        {

            finish = false;
            for (int i = 0; i < _player.bonusList.Count; i++)
            {
                Debug.Log(_player.bonusList.Count);
                switch (_player.bonusList[i].m_ScoringObjects.ToString())
                {
                    case "PacBall":
                        RemoveListObject<Bonus>(_player.bonusList,_player.bonusList[i]);
                        score++;
                        break;
                    case "PacGum":
                        _bonus.SetActive(true);
                        RemoveListObject<Bonus>(_player.bonusList, _player.bonusList[i]);
                        score = score + 5;
                        break;
                    case "Bonus":
                        RemoveListObject<Bonus>(_player.bonusList, _player.bonusList[i]);
                        
                        score = score + 600;
                        break;
                    case "Enemy":
                        RemoveListObject<Bonus>(_player.bonusList, _player.bonusList[i]);
                        score += 500;
                        break;
                    default:
                        break;
                }
            }

            if (!(_player.bonusList == null))
            {
               // RemoveAllListObject<Bonus>(_player.bonusList);
            }
            finish = true;

        }

        
    }

    public void RemoveAllListObject<T>(List<T> obj)
    {
        
        for (int i = 0; i < obj.Count; i++)
        {
            T test = obj[i];
            obj.Remove(obj[i]);
        }
    }
    public void RemoveListObject <T>(List<T> obj,T objToRemove)
    {
            obj.Remove(objToRemove);
    }
    #endregion
}

