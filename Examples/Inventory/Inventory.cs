using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> Items { get; set; }
    void Start () {
        // Complex data
        Items = new List<Item>()
        {
            new Item(0, "Golden Chalice", "A valuable chalice", new Dictionary<string, int>(), 1250, Item.ItemRarity.Rare),
            new Item(1, "Cheese Slice", "A slice of processed cheese. Yum.", new Dictionary<string, int>(), 6, Item.ItemRarity.Common),
            new Item(2, "Apprentice's Blade", "A sword for a beginner", new Dictionary<string, int>()
            {
                {"Power", 5 },
                {"Speed", 10 }
            }, 
            700, Item.ItemRarity.Rare),
            new Item(2, "Grandmaster Blade", "Big pointy sword", new Dictionary<string, int>()
            {
                {"Power", 75 },
                {"Speed", 16 }
            },
            4800, Item.ItemRarity.Legendary),
        };

        SaveData.Save(Items, "Inventory");
        // To make sure it's working, let's reset the inventory before we load it in
        Items = new List<Item>();
        Items = SaveData.Load<List<Item>>("Inventory");

        // Test it
        Debug.Log(Items[2].Stats["Speed"].ToString());
	}
}
