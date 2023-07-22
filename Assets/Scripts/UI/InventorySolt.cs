using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySolt : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler
{
    ItemData itemToDisplays;

    public Image itemDisplayImage;

    public enum InventoryType
    {
       Item,Tool
    }

    public InventoryType inventoryType;

    private int slotIndex;

    public void Display(ItemData itemToDisplay)
    {
        if (itemToDisplay != null)
        {
            itemDisplayImage.sprite = itemToDisplay.thumbnail;
            Debug.Log("true");
            itemToDisplays = itemToDisplay;
            itemDisplayImage.gameObject.SetActive(true);
            return;
        }
        itemDisplayImage.gameObject.SetActive(false);

    }

    public void AssignIndex(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.InventoryToHand(slotIndex,inventoryType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.DisplayItemInfo(itemToDisplays);
    }
}
