using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitkButton()
    { 
        Application.Quit();
    }
}
