using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum e_state
{
    up,
    down,
    left,
    right,
    none
}
public class MovementController : MonoBehaviour
{
    #region Private and Protected Members
    private List<GameObject> bullet;
    private Rigidbody2D m_rb;
    private e_state e_cube_state;
    #endregion
    #region Public Members
    public GameObject player;
    public float speed =5f;
    

    #endregion

    #region Public void

    #endregion

    #region System

    public void Start()
    {
        m_rb = player.GetComponent<Rigidbody2D>();
    }
    
    void Update ()
    {
        // si x n'est pas compris entre 1 et -1 et idem y 
        if (!(Input.acceleration.y <= 0.2 && Input.acceleration.y >= -0.2))
        {

            if (Input.acceleration.y < 0 && Input.acceleration.y < Input.acceleration.x)
            {
                StateAction(e_state.up);
            }
            else
            {
                if (Input.acceleration.y > 0)
                {
                    StateAction(e_state.down);
                }
                else
                {
                    StateAction(e_state.none);
                }
            }
        }
        if (!(Input.acceleration.x <= 0.2 && Input.acceleration.x >= -0.2)) {
            if (Input.acceleration.x < 0 )
            {
                StateAction(e_state.left);
            }
            else
            {
                if (Input.acceleration.x > 0 && Input.acceleration.x > Input.acceleration.y)
                {
                    StateAction(e_state.right);
                }
                else
                {
                    StateAction(e_state.none);
                }
            }
           
        }
     
        
        

        //Debug.Log(Input.acceleration);
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

 
    // à voir si implémentation de balles
    private void Shoot(GameObject obj) {

        DestroyObject(obj);

    }

    private void StateAction(e_state state)
    {
        switch (state)
        {
            case e_state.up:
                Debug.Log("up");
                Move(speed, Vector3.down);
                break;
            case e_state.down:
                Debug.Log("down");
                Move(speed, Vector3.up);
                break;
            case e_state.left:
                Debug.Log("left");
                Move(speed, Vector3.left);
                break;
            case e_state.right:
                Debug.Log("right");
                Move(speed, Vector3.right);
                break;
            case e_state.none:
                Debug.Log("none");
                m_rb.velocity = new Vector3(0, 0, 0);
                ;
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
