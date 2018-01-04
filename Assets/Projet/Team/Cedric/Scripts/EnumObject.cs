using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumObject : MonoBehaviour {

	public enum e_ObjectsGame
    {
        NOTHING,
        PacBall,
        PacGum,
        Bonus,
        Enemy
    }

    public e_ObjectsGame m_ObjectsGame;
}
