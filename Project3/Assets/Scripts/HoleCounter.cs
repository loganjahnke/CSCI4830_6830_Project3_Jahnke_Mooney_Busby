using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCounter : MonoBehaviour
{

    public GameObject progressBar;

    public int dirt = 0;
    public float max = 30f;
    public float totalDirt = 750f;

    float mfX;
    float mfY;
    float mfZ;

    // Start is called before the first frame update
    void Start()
    {
        this.mfX = this.progressBar.transform.position.x - this.progressBar.transform.localScale.x / 2.0f;
        this.mfY = this.progressBar.transform.position.y - this.progressBar.transform.localScale.y / 2.0f;
        this.mfZ = this.progressBar.transform.position.z - this.progressBar.transform.localScale.z / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3Scale = this.progressBar.transform.localScale;
        this.progressBar.transform.localScale = new Vector3(10f, this.max * (this.dirt / this.totalDirt), 10f);
        this.progressBar.transform.position = new Vector3(this.progressBar.transform.position.x, this.mfY + this.progressBar.transform.localScale.y / 2.0f, this.progressBar.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.dirt++;
    }

    private void OnTriggerExit(Collider other)
    {
        this.dirt--;
    }

}
