using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel_manager : MonoBehaviour
{
    public string namaScene;

    public void Replaydeongkak()
    {
        SceneManager.LoadScene(namaScene);
    }

    public void ExitAhmalezmaen()
    {
        Application.Quit();
    }
}
