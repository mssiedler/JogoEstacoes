using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShadowColor : MonoBehaviour
{
    public Image SombraImage;
    public int gameMode;
    public void ChangeColor()
    {
        if (gameMode == 2)
        {
            SombraImage.color = Color.white;
        }
    }
    public void ResetColor()
    {
        SombraImage.color = Color.grey;
    }
}
