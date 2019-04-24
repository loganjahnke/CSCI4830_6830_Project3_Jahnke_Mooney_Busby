using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndRemove : MonoBehaviour
{
    public int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(this.waitTime);
        Destroy(this.gameObject);
    }
}
