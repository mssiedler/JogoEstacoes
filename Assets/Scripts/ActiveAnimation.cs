using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimation : MonoBehaviour
{
    public Animation ClickButton;
    

    void Update()
    {
        if (DragAndDrop.colouCerto)
        {
            if (!ClickButton.isPlaying)
            {
                ClickButton.Play();
            }
        }
    }
}
