using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    private Renderer renderer;
    public enum LandStatus
    {
        Soil,Farmland,Watered
    }
    public Material soilMat, farmlandMat, wateredMat;

    public LandStatus landStatus;

    public GameObject select;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Watered);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;
        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmlandMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                break;
        }
        renderer.material = materialToSwitch; 
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        ItemData toolSlot = InventoryManager.Instance.equippedTool;
        EquimentData equimentTool = toolSlot as EquimentData;

        if (equimentTool != null)
        {
            EquimentData.ToolType toolType = equimentTool.toolType;
            switch (toolType)
            {
                case EquimentData.ToolType.Hoe:
                    SwitchLandStatus(LandStatus.Farmland);
                    break;
                case EquimentData.ToolType.WateringCam:
                    SwitchLandStatus(LandStatus.Watered);
                    break;
            }
        }
    }

 }
