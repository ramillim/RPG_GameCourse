using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelSlots : MonoBehaviour
{
    ItemSlot _itemSlot;
    [SerializeField] Image itemIcon;

    public void Bind(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;
        _itemSlot.Changed += UpdateIcon;
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (_itemSlot.Item != null)
        {
            itemIcon.sprite = _itemSlot.Item.Icon;
            itemIcon.enabled = true;
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }
}