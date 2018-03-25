using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public enum ItemRarity { Common, Rare, Legendary }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, int> Stats { get; set; }
    public int Value { get; set; }
    public ItemRarity Rarity { get; set; }

    public Item(int id, string name, string description, Dictionary<string, int> stats, int value, ItemRarity rarity)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.Stats = stats;
        this.Value = value;
        this.Rarity = rarity;
    }
}
