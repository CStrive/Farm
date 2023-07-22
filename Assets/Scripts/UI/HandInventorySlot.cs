using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandInventorySlot : InventorySolt
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.HandToInventory(inventoryType);
    }
}
