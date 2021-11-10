using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float spawnTime = 1;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, obstaclePrefab.Length);

        GameObject obs = Instantiate(obstaclePrefab[rand]);
        obs.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(obs,0.1f);
        timer = 0;
    }

}
