using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    [Header("Prefabs")]
    public GameObject m_wallLine;
    public GameObject m_wallCorner;
    public GameObject m_wallEnd;
    
	void Awake() {
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;
        /*Debug.Log("Screen : Width = "+m_screenWidth+" Height = "+m_screenHeight);
        Debug.Log("Camera : Width = " + m_screenWidth + " Height = " + m_screenHeight);

        CreateMap();*/
	}

    private void CreateMap()
    {
        int debutScreenWidth = -(m_screenWidth / 2);
        int debutScreenHeight = -(m_screenHeight / 2);
        for (int w = 0; w < m_screenWidth; w++)
        {
            for(int h = 0; h < m_screenHeight; h++)
            {
                if (w == 0)
                {
                    if(h == 0)
                    {
                        MakeInstantiate(m_wallCorner, new Vector3(debutScreenWidth, m_screenHeight, 0), new Quaternion(0,0,0,0));
                    }
                }
                else
                {
                    //MakeInstantiate(m_wallLine, new Vector3(debutScreenWidth + w, debutScreenHeight + h, 0), new Quaternion(0,0,0,0));
                }
            }
        }
    }

    private void MakeInstantiate(GameObject _object, Vector3 _position, Quaternion _rotation)
    {
        Instantiate(_object, _position, _rotation);
    }

    private int m_screenWidth;
    private int m_screenHeight;
}
