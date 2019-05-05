using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFirebaseUnity;

public class FinishTraining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var firebase = Firebase.CreateNew("https://vr-final-project.firebaseio.com/");
        var child = firebase.Child("employee_id").Child(DataManagement.instance.gameData.employeeID).Child("sessions");

        Debug.Log(DataManagement.instance.gameData.employeeID);

        child.OnPushSuccess += (Firebase sender, DataSnapshot snapshot) =>
        {
            // Push successful, quit game
            Application.Quit();
        };

        child.OnPushFailed += (Firebase sender, FirebaseError error) =>
        {
            Debug.LogError("Could not push data: " + error.ToString());
        };

        if (!DataManagement.instance.gameData.pushed)
        {
            child.Push("{ \"dirt_collected\": " + DataManagement.instance.gameData.dirtTransported
            + ", \"time_taken\": " + Time.time
            + ", \"date\": \"" + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "\" }", true);

            DataManagement.instance.gameData.pushed = true;
        }
    }
}
