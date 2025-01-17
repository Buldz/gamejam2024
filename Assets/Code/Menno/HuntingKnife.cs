using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingKnife : Item
{
    public Balloon balloon;
    public Guy guy;

    public AudioSource slashAudio;

    //Raycast
    public float range = 2;
    Ray ray;

    public bool balloonIsHit = false;
    public bool guyIsHit = false;

    public void Update()
    {
        balloonIsHit = false;
        guyIsHit = false;

        ray = new Ray(transform.position, transform.TransformDirection(-Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == "interactable")
            {
                balloonIsHit = true;
                balloon = hit.collider.GetComponent<Balloon>();
            }

            if (hit.collider.tag == "guy")
            {
                guyIsHit = true;
                guy = hit.collider.GetComponent<Guy>();
            }
        }

        if (pickUp == false)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }

    public override void Use()
    {
        Used();
        slashAudio.Play();
        if (balloonIsHit ==true)
        {
            balloon.Pop();
        }
        
        if (guyIsHit == true)
        {
            guy.Hurt();
        }
    }
}
