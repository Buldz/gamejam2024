using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public AudioSource balloonPopAudio;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void Pop()
    {
        balloonPopAudio.Play();
        Destroy(this.gameObject);
    }
}
