using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum e_state
{
    up,
    down,
    left,
    right
}
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

    public void Start()
    {
        m_rb = player.GetComponent<Rigidbody>();
    }
    
    void Update ()
    {
        Debug.Log(Input.acceleration);
        if (Input.acceleration.x < 0) {
            StateAction(e_state.left);
        }
        if (Input.acceleration.x < 0)
        {
            StateAction(e_state.right);
        }
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
        
    }
    // à voir si implémentation de balles
    private void Shoot(GameObject obj) {

        DestroyObject(obj);

    }

    private void StateAction(e_state state)
    {
        switch (state)
        {
            case e_state.up:
                Move(1, Vector3.up);
                break;
            case e_state.down:
                Move(1, Vector3.down);
                break;
            case e_state.left:
                Debug.Log("left");
                Move(1, Vector3.left);
                break;
            case e_state.right:
                Debug.Log("right");
                Move(1, Vector3.right);
                break;
           
            default:
                break;
        }

    }
    private void Move(float speed, Vector3 direction)
    {
     
        m_rb.velocity= direction*speed ;

    }


    #endregion


}
