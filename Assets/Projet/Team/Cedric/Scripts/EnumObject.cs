using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumObject : MonoBehaviour {

	public enum e_ScoringObjects
    {
        NOTHING,
        PacBall,
        PacGum,
        Bonus,
        Enemy
    }

    public e_ScoringObjects m_ScoringObjects;
}
