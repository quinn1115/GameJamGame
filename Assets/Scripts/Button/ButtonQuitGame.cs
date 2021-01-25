using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitGame : ButtonCollider
{
    protected override void OnClick()
    {
        Application.Quit();
    }

}
