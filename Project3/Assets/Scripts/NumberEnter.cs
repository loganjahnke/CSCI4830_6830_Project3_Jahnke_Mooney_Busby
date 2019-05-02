using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SimpleFirebaseUnity;
using UnityEngine.SceneManagement;

public class NumberEnter : MonoBehaviour
{
    string employeeUD = "";
    public TMP_InputField inputField;
    public TextMeshProUGUI textMesh;
    public GameObject component;
    public GameObject background;

    private RectTransform rectComponent;
    private float rotateSpeed = 200f;
    private bool loading = false;


    // Start is called before the first frame update
    void Start()
    {
        this.rectComponent = this.component.GetComponent<RectTransform>();
        this.component.GetComponent<Image>().enabled = false;
        this.background.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (employeeUD.Length < 6)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                this.employeeUD += "0";
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                this.employeeUD += "1";
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                this.employeeUD += "2";
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                this.employeeUD += "3";
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                this.employeeUD += "4";
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                this.employeeUD += "5";
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                this.employeeUD += "6";
            }

            if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            {
                this.employeeUD += "7";
            }

            if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                this.employeeUD += "8";
            }

            if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
            {
                this.employeeUD += "9";
            }
        }
        else if (this.loading)
        {
            // Loading circle
            this.background.GetComponent<Image>().enabled = true;
            this.component.GetComponent<Image>().enabled = true;
            rectComponent.Rotate(0f, 0f, this.rotateSpeed * Time.deltaTime);
        }
        else
        {
            // Load employee ID
            this.Load();
            this.loading = true;
        }


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            this.employeeUD = this.employeeUD.Substring(0, this.employeeUD.Length - 1 > 0 ? this.employeeUD.Length - 1 : 0);
        }

        string result = "";
        int digits = 0;

        // Add numbers
        for (int i = 0; i < this.employeeUD.Length; i++)
        {
            if (this.employeeUD[i] == ' ' || this.employeeUD[i] == '_')
            {
                continue;
            }
            result += this.employeeUD[i];
            result += "  ";
            digits += 1;
        }

        // Add underscores
        for (int i = digits; i < 6; i++)
        {
            result += "_";
            result += "  ";
        }

        // Remove last "  "
        result = result.Substring(0, 16);
        inputField.text = result;
    }

    void Load()
    {
        var firebase = Firebase.CreateNew("https://vr-final-project.firebaseio.com/");
        var child = firebase.Child("employee_id").Child(this.employeeUD);

        child.OnGetSuccess += (Firebase sender, DataSnapshot snapshot) =>
        {
            if (snapshot.Keys == null)
            {
                Debug.Log("Failed");
                // This child does not exist, this person cannot train
                this.textMesh.color = Color.red;
            }
            else
            {
                Debug.Log("Success!");
                this.textMesh.color = Color.white;
                DataManagement.instance.gameData.employeeID = employeeUD;
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoganScene");
                // Destroy to get rid of NullPointerException
                Destroy(this);
            }
        };

        child.OnGetFailed += (Firebase sender, FirebaseError error) =>
        {
            Debug.Log("Failed: " + error.ToString());
            // This child does not exist, this person cannot train
            this.textMesh.color = Color.red;
        };

        child.GetValue();
    }
}
