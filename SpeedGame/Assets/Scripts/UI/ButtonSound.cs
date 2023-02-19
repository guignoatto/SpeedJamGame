using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AK.Wwise.Event PressSound;
    public void onClick() {
        PressSound.Post(gameObject);
    }

}
