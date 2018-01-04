using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour {

    [Header("Spawn Bonus")]
    public GameObject m_prefabsBonus;
    [Range(1f,10f)]
    public float m_timeToSpawn;
    public List<Sprite> m_listSpritebonus;
    public List<GameObject> m_listSpawner;

    private void Awake()
    {
        m_listSpritebonusMax = m_listSpritebonus.Count;
        m_listSpawnerMax = m_listSpawner.Count;
    }

    private void Update()
    {
        StartCoroutine(MakeSpawnBonus(m_listSpawner[RandomNumber(0, m_listSpawnerMax)].transform));
    }

    private IEnumerator MakeSpawnBonus(Transform _spawner)
    {
        yield return new WaitForSeconds(m_timeToSpawn);
        if (_spawner.childCount == 0)
        {
            GameObject prefab = Instantiate(m_prefabsBonus, _spawner);
            prefab.GetComponent<SpriteRenderer>().sprite = m_listSpritebonus[RandomNumber(0, m_listSpritebonusMax)];
        }
    }

    private int RandomNumber(int _min, int _max)
    {
        return Random.Range(_min, _max);
    }

    private int m_listSpritebonusMax;
    private int m_listSpawnerMax;
}
