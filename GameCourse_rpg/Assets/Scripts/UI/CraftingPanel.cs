﻿using UnityEngine;

public class CraftingPanel : MonoBehaviour
{
    void Start() => Bind(Inventory.Instance);

    public void Bind(Inventory inventory)
    {
        var panelSlots = GetComponentsInChildren<InventoryPanelSlots>();
        for (int i = 0; i < panelSlots.Length; i++)
        {
            panelSlots[i].Bind(inventory.CraftingSlots[i]);
        }
    }
}