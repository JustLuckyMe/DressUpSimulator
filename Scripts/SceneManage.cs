using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject EndingUI;

    public void Restart()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(0);
        EndingUI.SetActive(false);
    }
}
