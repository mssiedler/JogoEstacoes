using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButton : MonoBehaviour
{
    public GameObject continueButton;
    void Update()
    {
        if (!DragAndDrop.colouCerto)
        {
            continueButton.SetActive(false);
        }
    }
}
