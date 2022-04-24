using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ARCameraButton()
    {
        SceneManager.LoadScene("MainARCam");
    }

    public void TimeConvertButton()
    {
        SceneManager.LoadScene("TimeConvert");
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
