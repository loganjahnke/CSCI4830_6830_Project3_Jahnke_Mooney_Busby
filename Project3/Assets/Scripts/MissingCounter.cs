using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingCounter : MonoBehaviour
{
    public GameObject start;
    public GameObject goal;

    public int dirt = 0;
    public float max = 30f;
    public float totalDirt = 750f;

    float mfX;
    float mfY;
    float mfZ;

    private HoleCounter startCounter;
    private HoleCounter goalCounter;

    // Start is called before the first frame update
    void Start()
    {
        this.mfX = this.transform.position.x - this.transform.localScale.x / 2.0f;
        this.mfY = this.transform.position.y - this.transform.localScale.y / 2.0f;
        this.mfZ = this.transform.position.z - this.transform.localScale.z / 2.0f;

        this.startCounter = this.start.GetComponent<HoleCounter>();
        this.goalCounter = this.goal.GetComponent<HoleCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        this.dirt = 500 - this.startCounter.dirt - this.goalCounter.dirt;
        Vector3 v3Scale = this.transform.localScale;
        this.transform.localScale = new Vector3(10f, this.max * (this.dirt / this.totalDirt), 10f);
        this.transform.position = new Vector3(this.transform.position.x, this.mfY + this.transform.localScale.y / 2.0f, this.transform.position.z);
    }
}
