using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    public static DataManagement instance = null;
    public PersistentData gameData = new PersistentData();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}

public class PersistentData
{
    public string employeeID = "";
    public int dirtTransported = -1;
    public int timeTaken = -1;
    public bool pushed = false;
}