using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Private and Protected Members

    #endregion
    #region Public Members
    public List<GameObject> scoringObjectList;
    public int life;
    
    #endregion

    #region Public void

    #endregion

    #region System

    void Start ()
    {
        
    }

    void Update ()
    {
        	
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            PickUp(collision.gameObject);
        Debug.Log("ok");
    }


    #endregion

    #region Tools Debug and Utility
    public void PickUp(GameObject obj)
    {
        //tester la destruction d'objet
        scoringObjectList.Add(obj);
        //obj.SetActive(false);

    }
    public void DestroyScoring()
    {
        foreach (GameObject obj in scoringObjectList)
        {
            Destroy(obj);
            Debug.Log("isdestroyed");
        }
    }
    #endregion


}
