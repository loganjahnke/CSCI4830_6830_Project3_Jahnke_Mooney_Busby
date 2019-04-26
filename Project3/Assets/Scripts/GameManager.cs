using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DirtPrefab;
    public Transform DirtSpawner;
    public int totalDirt = 750;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.totalDirt; i++) { 
            Instantiate(DirtPrefab, DirtSpawner.position, new Quaternion(0, 0, 0, 0));
            DirtSpawner.position += new Vector3(0, 0.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
