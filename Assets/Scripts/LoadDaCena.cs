using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDaCena : MonoBehaviour
{
    public void LoadScenes(string cena)
    {
        if (DragAndDrop.colouCerto)
        {
            SceneManager.LoadScene(cena);
        }
    }
}
