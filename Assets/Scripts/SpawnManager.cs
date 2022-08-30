using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private Transform spawnPoint;

    private PlayerController pc;

    private float startDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        pc = FindObjectOfType<PlayerController>();
    }

    void SpawnObstacle()
    {
        if(!pc.isGameOver())
        {
            Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        }
    }
}
