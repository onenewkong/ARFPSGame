using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MonsterManager : MonoBehaviour
{
    ARRaycastManager arManager;

    public List<GameObject> monsterObjectPool;
    private BoxCollider area;
    public int count = 30;

    public GameObject monsterFactory1;
    public GameObject monsterFactory2;
    public GameObject monsterFactory3;

    // Start is called before the first frame update
    void Start()
    {
        arManager = GetComponent<ARRaycastManager>();
        area = GetComponent<BoxCollider>();

        area.enabled = false;

        StopAllCoroutines();

       for(int i = 0; i < count; i++)
       {
            StartCoroutine(Spawn());
       }
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + UnityEngine.Random.Range(-size.x/2f, size.x/2f);
        float posY = basePosition.y + UnityEngine.Random.Range(-size.y/2f, size.y/2f);
        float posZ = basePosition.z + UnityEngine.Random.Range(-size.z/2f, size.z/2f);

        Vector3 spawnPos = new Vector3(posX/2f, posY/2f, posZ/2f);

        return spawnPos;
    }

    private IEnumerator Spawn()
    {
        normalMonsterSpawn();

        int index = UnityEngine.Random.Range(0, monsterObjectPool.Count);
        GameObject selectedPrefab = monsterObjectPool[index];

        if(selectedPrefab.activeSelf == false)
        {
            selectedPrefab.SetActive(true);
        }
        selectedPrefab.transform.position = GetRandomPosition();

        yield return new WaitForSecondsRealtime(1.0f);
    }

    void normalMonsterSpawn()
    {
        monsterObjectPool = new List<GameObject>();

        GameObject monster1 = Instantiate(monsterFactory1);
        GameObject monster2 = Instantiate(monsterFactory2);
        GameObject monster3 = Instantiate(monsterFactory3);

        monsterObjectPool.Add(monster1);
        monsterObjectPool.Add(monster2);
        monsterObjectPool.Add(monster3);
    }
}
