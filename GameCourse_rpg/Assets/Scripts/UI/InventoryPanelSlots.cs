using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanelSlots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ItemSlot _itemSlot;
    [SerializeField] Image itemIcon;
    [SerializeField] Outline _outline;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _outline.enabled = false;
    }
}