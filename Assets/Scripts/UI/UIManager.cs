using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject inventoryPanel;
    public InventorySolt[] toolSolts;
    public InventorySolt[] itemSolts;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image toolEquipSlot;
    public HandInventorySlot toolHandSlot;
    public HandInventorySlot itemHandSlot;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RenderInventory();
        AssignSlotIndexes();
    }

    public void AssignSlotIndexes()
    {
        for (int i = 0; i < toolSolts.Length; i++)
        {
            toolSolts[i].AssignIndex(i);
            itemSolts[i].AssignIndex(i);
        }
    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;
        ItemData[] inventoryItemSlots = InventoryManager.Instance.items;
        RenderInventoryPanel(inventoryToolSlots, toolSolts);
        RenderInventoryPanel(inventoryItemSlots, itemSolts);

        toolHandSlot.Display(InventoryManager.Instance.equippedTool);
        itemHandSlot.Display(InventoryManager.Instance.equippedItem);

        ItemData equippedTool = InventoryManager.Instance.equippedTool;
        if (equippedTool != null)
        {
            toolEquipSlot.sprite = equippedTool.thumbnail;
            toolEquipSlot.gameObject.SetActive(true);
            return;
        }
        toolEquipSlot.gameObject.SetActive(false);
    }

    private void RenderInventoryPanel(ItemData[] slots, InventorySolt[] uiSlots)
    {
        for (var i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Display(slots[i]);
        }
    }


    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RenderInventory();
    }

    public void DisplayItemInfo(ItemData data)
    {
        if (data != null)
        {
            itemNameText.text = data.name;
            itemDescriptionText.text = data.description;
        }
    }

}
