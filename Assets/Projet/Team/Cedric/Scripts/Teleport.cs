using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform m_locationToTeleport;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = m_locationToTeleport.position;
    }
}
