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
        Debug.Log("Screen : Width = "+m_screenWidth+" Height = "+m_screenHeight);

        CreateMap();
	}

    private void CreateMap()
    {
        for(int w = 0; w < m_screenWidth; w++)
        {
            for(int h = 0; h < m_screenHeight; h++)
            {
                Vector3 vec3 = new Vector3(w, h, 0);
                if (w == 0)
                {
                    if(h == 0)
                    {
                        MakeInstantiate(m_wallCorner,vec3,new Quaternion(0,0,0,0));
                    }
                    else
                    {
                        MakeInstantiate(m_wallLine, vec3,new Quaternion(0,0,0,0));
                    }
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
