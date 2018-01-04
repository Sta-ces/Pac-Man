using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    #region Private and Protected Members
    private List<GameObject> bullet;
    #endregion
    #region Public Members
    public GameObject player;
    private Rigidbody m_rb;
   
    #endregion

    #region Public void

    #endregion

    #region System
   
    private void OnGUI()
    {
    }
    public void Start()
    {
        m_rb = player.GetComponent<Rigidbody>();
    }
    
    void Update ()
    {

        AccMov();
    }

    #endregion



    #region Tools Debug and Utility
    //A déplacer dans fonction ecran
    public bool TouchButton(Button btn) {

        if (btn.isActiveAndEnabled) {

            return true;

        }
        return false;
    }


    public string FingerTouch()
    {
        bool isPlayerPressing = false;
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_IOS && !UNITY_EDITOR
                isPlayerPressing = Input.touchCount > 0;
#else
        isPlayerPressing = Input.GetMouseButton(0);
#endif
        string str = "";
        if (isPlayerPressing)
        {
            switch (Input.touchCount)
            {
                case 1:
                    str = "Un";
                    break;
                case 2:
                    str = "Deux";
                    break;
                case 3:
                    str = "trois";
                    break;

                default:
                    str = "Non gérer";
                    break;
            }

        }
        return str;
    }
    private void AccMov() {
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_IOS && !UNITY_EDITOR
                

#endif
        //player.transform.Translate(Input.acceleration.x / 10, transform.position.y, -Input.acceleration.z / 10);
        if (Input.acceleration.z >= -1.0f&& Input.acceleration.z <= -0.9f)
        {
            Debug.Log("ici");
            m_rb.AddForce(Input.acceleration.x / 10, transform.position.y, player.transform.position.z);
            //player.transform.Translate();

        }
        else {
            //player.transform.Translate(Input.acceleration.x / 10, transform.position.y, -Input.acceleration.z / 10);
            m_rb.AddForce(Input.acceleration.x / 10, transform.position.y, Input.acceleration.z / 10);
        }
        Debug.Log(Input.acceleration.z); 
    }
    // à voir si implémentation de balles
    private void Shoot(GameObject obj) {

        DestroyObject(obj);

    }


    

    #endregion


}
