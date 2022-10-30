using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLifeIndicators : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas HUD;
    public GameObject lifeIndicator;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    void Start()
    {
        // instantiate one life indicator where pos1 rect transform in hud is
        Instantiate(lifeIndicator, pos1.transform.position, Quaternion.identity, HUD.transform);
        Instantiate(lifeIndicator, pos2.transform.position, Quaternion.identity, HUD.transform);
        Instantiate(lifeIndicator, pos3.transform.position, Quaternion.identity, HUD.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
