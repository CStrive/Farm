using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equiment")]
public class EquimentData : ItemData
{
    public enum ToolType
    {
        Hoe,WateringCam,Axe,Pickaxe
    }
    public ToolType toolType;
}
