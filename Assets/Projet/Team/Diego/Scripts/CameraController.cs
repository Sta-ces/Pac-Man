using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Private and Protected Members
    public GameObject cam;
    public GameObject subject;
    #endregion
    #region Public Members

    #endregion

    #region Public void

    #endregion

    #region System
    private void Awake()
    {
        cam.transform.LookAt(subject.transform);
        cam.transform.SetParent(subject.transform);

    }
    void Start ()
    {
        
    }

    void Update ()
    {
        	
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    
}
