using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable//MonoBehaviour 
{
    private Inventory inventory;
    public GameObject item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
       
    }


    public override void Interact()
    {
        if (inventory.isFull[0] == false)
        {
            inventory.isFull[0] = true;
            Instantiate(item, inventory.slots[0].transform, false);

        }
        else if(inventory.isFull[0] == true)
        {
            inventory.isFull[0] = false;
            Destroy(inventory.slots[0].transform.GetChild(0).gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        for (int i = 0; i < inventory.slots.Length; i++)
    //        {
    //            if(inventory.isFull[i] == false)
    //            {
    //                inventory.isFull[0] = true;
    //                Instantiate(item, inventory.slots[0].transform, false);
    //                Destroy(gameObject);
    //                break;
    //            }
    //        }
    //    }
    //}


}
