using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownNose : Item
{
    public AudioSource clownNoseSound;

    public override void Use()
    {
        clownNoseSound.Play();
        UnityEngine.Debug.Log("Honk!");
    }
}
