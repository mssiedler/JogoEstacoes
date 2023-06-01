using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableText : MonoBehaviour
{
    public GameObject text;
    void Update()
    {
        if (DragAndDrop.colouCerto)
        {
            text.SetActive(false);
        }
        if (!DragAndDrop.colouCerto)
        {
            text.SetActive(true);
        }
    }
}
