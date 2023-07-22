using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
       if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }else
        {
            Instance = this;
        }
    }

    public ItemData[] tools = new ItemData[8];
    public ItemData equippedTool = null;

    public ItemData[] items = new ItemData[8];
    public ItemData equippedItem = null;

    public void InventoryToHand(int slotIndex,InventorySolt.InventoryType inventoryType)
    {
        if (inventoryType == InventorySolt.InventoryType.Item)
        {
            ItemData itemToEquip = InventoryManager.Instance.items[slotIndex];
            items[slotIndex] = equippedItem;
            equippedItem = itemToEquip;
        }
        else
        {
            ItemData toolToEquip = tools[slotIndex];
            tools[slotIndex] = equippedTool;
            equippedTool = toolToEquip;
        }
        UIManager.Instance.RenderInventory();
    }

    public void HandToInventory(InventorySolt.InventoryType inventoryType)
    {
        if (inventoryType == InventorySolt.InventoryType.Item)
        {
            for (int i = 0;  i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = equippedItem;
                    equippedItem = null;
                    break;
                }
            }
        } else
        {
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == null)
                {
                    tools[i] = equippedTool;
                    equippedTool = null;
                    break;
                }
            }
        }

        UIManager.Instance.RenderInventory();
    }

}
