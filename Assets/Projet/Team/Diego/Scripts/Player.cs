using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Private and Protected Members

    #endregion
    #region Public Members
    public List<Bonus> bonusList;
    public List<GameObject> bonusToDestroy; 
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
        if (collision.transform.tag=="bonus")
        {
            PickUp(collision.gameObject);
        }
            
    }


    #endregion

    #region Tools Debug and Utility
    public void PickUp(GameObject obj)
    {
        //tester la destruction d'objet
        bonusList.Add(obj.GetComponent<Bonus>());
        obj.SetActive(false);
        bonusToDestroy.Add(obj);
        

    }
   
    #endregion


}
