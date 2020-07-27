using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    private bool inventoryEnabled;
    private int allSlots = 4;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        slotHolder = GameObject.FindGameObjectWithTag("Slotholder");

        allSlots = 4;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

        RemoveItem();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty == true)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                slot[i].GetComponent<Slot>().used = false;
                return;
            }
        }
    }

    void RemoveItem()
    {
        for (int i = 0; i < allSlots; i++)
        {
            if ((slot[i].GetComponent<Slot>().empty == false) && (slot[i].GetComponent<Slot>().used == true))
            {
                slot[i].GetComponent<Slot>().UseItem();
                Item itemUsed = slot[i].GetComponent<Slot>().item.GetComponent<Item>();
                itemUsed.ItemUsage();

                slot[i].GetComponent<Slot>().item = null;
                slot[i].GetComponent<Slot>().icon = null;
                slot[i].GetComponent<Slot>().type = null;
                slot[i].GetComponent<Slot>().ID = 0;
                slot[i].GetComponent<Slot>().description = null;


                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = true;
                return;
            }

        }
    }
}