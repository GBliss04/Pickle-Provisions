using UnityEngine;

public class Esc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application quit requested."); // Only shows in editor
        }
    }
}
