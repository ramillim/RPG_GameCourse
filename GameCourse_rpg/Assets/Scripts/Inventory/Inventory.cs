using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int General_Size = 9;
    const int Crafting_Size = 9;
    
    public ItemSlot[] GeneralSlots = new ItemSlot[General_Size];
    public ItemSlot[] CraftingSlots = new ItemSlot[Crafting_Size];
    
    [SerializeField] Item _debugItem;
    public static Inventory Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < General_Size; i++)
        {
            GeneralSlots[i] = new ItemSlot();
        }
        for (int i = 0; i < Crafting_Size; i++)
        {
            CraftingSlots[i] = new ItemSlot();
        }
    }

    public void AddItem(Item item)
    {
        var firstAvailableSlot = GeneralSlots.FirstOrDefault(t=> t.IsEmpty);
        firstAvailableSlot.SetItem(item);
    }

    [ContextMenu(nameof(AddDebugItem))]
    void AddDebugItem() => AddItem(_debugItem);

    [ContextMenu(nameof(MoveItemsRight))]
    void MoveItemsRight()
    {
        var lastItem = GeneralSlots.Last().Item;
        for (int i = General_Size - 1; i > 0; i--)
        {
            GeneralSlots[i].SetItem(GeneralSlots[i-1].Item);
        }
        GeneralSlots.First().SetItem(lastItem);
    }

    public void Bind(List<SlotData> slotDatas)
    {
        for (var i = 0; i < GeneralSlots.Length; i++)
        {
            var slot = GeneralSlots[i];
            var slotData = slotDatas.FirstOrDefault(t => t.SlotName == "General" + i);
            if (slotData == null)
            {
                slotData = new SlotData() {SlotName = "General" + i};
                slotDatas.Add(slotData);
            }

            slot.Bind(slotData);
        }
        for (var i = 0; i < CraftingSlots.Length; i++)
        {
            var slot = CraftingSlots[i];
            var slotData = slotDatas.FirstOrDefault(t => t.SlotName == "Crafting" + i);
            if (slotData == null)
            {
                slotData = new SlotData() {SlotName = "Crafting" + i};
                slotDatas.Add(slotData);
            }

            slot.Bind(slotData);
        }
    }
}