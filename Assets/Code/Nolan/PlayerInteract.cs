using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    //Raycast
    public float range = 2;
    public GameObject HeldItem;

    /* //Timer
     public int holdKey = 7;
     public float holdTimer;
     public TimerUI timerUI;
     public GameObject timerHUD;*/


    //Object
    public Item lastLookedAtItem;
    public bool itemPickedUp = false;

    //UI
    public GameObject PickupInstructionUI;
    public GameObject DropInstructionUI;

    void Start()
    {
        //holdTimer = holdKey;
    }

    void Update()
    {
        //Timer
        //holdTimer -= Time.deltaTime;

        //Raycast
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
           
            Item item = hit.collider.GetComponent<Item>();

            if (item != null && itemPickedUp == false)
            {
                lastLookedAtItem = item;
            }

            //Item
            if (hit.collider.tag == "item" && itemPickedUp == false)
            {
                PickupInstructionUI.SetActive(true);

                //Press E to pickup item
                if (Input.GetKeyDown("e"))
                {
                    ItemPickup();
                }
            }
            else
            {
                PickupInstructionUI.SetActive(false);
            }

            if (itemPickedUp == true)
            {
                PickupInstructionUI.SetActive(false);
                DropInstructionUI.SetActive(true);
            }
        }

        //Press Q to release item
        if (Input.GetKeyDown("q"))
        {
            ItemRelease();
        }

        //Press Left mouse button to use item
        if (Input.GetMouseButtonDown(0))
        {
            ItemUse();
        }
    }

    //Methods

    void ItemPickup()
    {
        if (itemPickedUp == false) 
        {
            lastLookedAtItem.Pickup();
            itemPickedUp = true;
            //PickupInstructionUI.SetActive(false);
        }
    }

    void ItemRelease()
    {
        if (itemPickedUp == true)
        {
            lastLookedAtItem.Release();
            itemPickedUp = false;
            DropInstructionUI.SetActive(false);
        }
    }

    void ItemUse()
    {
        if (itemPickedUp == true)
        {
            lastLookedAtItem.Use();
        }
    }
}
