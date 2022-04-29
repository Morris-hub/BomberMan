using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject PrefabEnemy;
    public float launchTime = 10f;
    private GameObject Enemy;
    //bool enemy = false;
   

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f,  launchTime);
    }

    void SpawnEnemy()
    {
        Enemy = Instantiate(PrefabEnemy, transform.position, Quaternion.identity);
    }
   
}
