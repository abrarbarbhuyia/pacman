using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerPellet : MonoBehaviour
{
    public GameObject powerPelletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerPelletPrefab, new Vector3(-32.5f, 16.48f, 0), Quaternion.identity);
        Instantiate(powerPelletPrefab, new Vector3(-7.5f, 16.48f, 0), Quaternion.identity);
        Instantiate(powerPelletPrefab, new Vector3(-32.5f, -6.57f, 0), Quaternion.identity);
        Instantiate(powerPelletPrefab, new Vector3(-7.5f, -6.57f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
