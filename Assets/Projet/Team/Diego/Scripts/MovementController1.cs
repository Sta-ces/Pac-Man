using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController1 : MonoBehaviour
{
    #region Private and Protected Members
    private bool compassIsEnabled;
    private Compass compass;
    private Quaternion rot;
    private Gyroscope gyro;
    private bool gyroIsEnabled;
    #endregion
    #region Public Members
    public Text m_text;
    public Transform m_terrain;
    public GameObject cam;
    public GameObject subject;
   
    #endregion

    #region Public void

    #endregion

    #region System
    private void Awake()
    {
        gyroIsEnabled = EnableGyro();
        //compassIsEnabled = EnableCompass();
        cam.transform.LookAt(subject.transform);
        cam.transform.SetParent(subject.transform);

    }
    private void OnGUI()
    {
    }
    public void Start()
    {
    }
    
    void Update ()
    {
        if (gyroIsEnabled)
        {
           // GyroRot();
        }
        if (compassIsEnabled)
        {
       //     CompassRot();
        }
      //  m_text.text=FingerTouch();
        AccMov();
    }

    #endregion
    #region Tools Debug and Utility

    public void Test()
    {
 
        Debug.Log(Input.touchCount); // Number of finger on screne
        //Debug.Log(Input.touches[0].position); // De 0,0 à 1,1 en pixel
        Debug.Log(Input.acceleration); // Accélération
        Debug.Log("Compass: "+Input.compass.enabled); // direction magnétique
        Debug.Log(Input.gyro); // direction magnétique
        Debug.Log(Input.location.lastData.latitude);



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

        subject.transform.Translate(Input.acceleration.x / 10, transform.position.y,- Input.acceleration.z/10);
        m_text.text = Input.acceleration.ToString();
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            //Initialise rotation
            //cam.transform.rotation = new Quaternion(90f, 90f, 90f, 0f);
            //rot = new Quaternion(0, 0, 1, 0);
           // m_text.text = "Gyro ok";
            return true;
        }

        return false;



    }

    public void GyroRot()
    {
        
        float x= gyro.attitude.eulerAngles.x;
        float y= gyro.attitude.eulerAngles.y;
        float z= gyro.attitude.eulerAngles.z;

        Vector3 angle = -new Vector3(x,z,y);
        // Gyro g = new Gyro();
        // g.angle = angle;
        // g.rotationRate = Input.gyro.rotationRateUnbiased;
        m_text.text = angle.ToString();
        m_terrain.transform.eulerAngles = angle;
        
    }
    public bool EnableCompass() {
        if (!Input.location.isEnabledByUser)
        {
            Input.location.Start();
            Debug.Log("Start?" + Input.location.status.ToString());
        }
        Debug.Log("hello!!!" + Input.location.status.ToString());
        compass = Input.compass;
        compass.enabled = true;
        
       // m_text.text = compass.enabled.ToString();
        return true;
    } 

    public void CompassRot()
    {
        m_text.text = compass.magneticHeading.ToString();

    }



    

    #endregion


}
