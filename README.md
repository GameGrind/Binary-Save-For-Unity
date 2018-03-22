# Binary Save/Load for Unity
A simple tool for saving and loading data in Unity. Quickly serialize objects, from Dictionaries and Lists, to complex, serializable object structures. 

All it uses is a BinaryFormatter to serialize and deserialize objects. Any object type (as long as it is marked with a serializable attribute) can be saved and loaded. This does however mean that MonoBehaviour objects will need special attention if you want to save/load data for them. We'll go over that in a second.

## How to use it

To save data, this is what you do:

````
SaveData.Save(Items, "Inventory");
````

This takes the object you're saving as the first parameter, and the key you're saving it with for the second. For instance, this `Items` object looks like this:

````
Items = new Dictionary<int, string>
{
    { 12, "Broken Sword" },
    { 20, "Health Scroll" }
};
````

And then when you're loading your game, to load the Inventory data back in, just do this:
````
Items = SaveData.Load<Dictionary<int, string>>("Inventory");
````

Notice that the methods take a generic type so in this case I know I want an int/string Dictionary. Saving data uses a generic type as well, but the overload simply takes an `Object` so it's optional.

## Saving/Loading non-serializable objects
This is something that we have to do a lot of in Unity since MonoBehaviours are quite special. For instance, let's say we want to save this Player object:

````
public class Player : MonoBehaviour {
    public int Health { get; set; }
    public int Level { get; set; }
    public float Coolness { get; set; }
    void Start() {
        Health = 154;
        Level = 12;
        Coolness = 12.7645f;
    }
}
````
I need to save the `Health`, `Level`, and `Coolness` properties. Unlike a serializable type, I can't just pass a Player object to the `Save` and `Load` methods. 

We have a couple options, but what I'm going to do is within the same file, create a class called `SerializablePlayer` with those properties, and mark it with `[System.Serializable]`. I can now create an object from this, pass my values in, and save as I please. 

````
[System.Serializable]
public class SerializablePlayer
{
    public int Health { get; set; }
    public int Level { get; set; }
    public float Coolness { get; set; }
}
````
And then to save player:

````
SerializablePlayer serializedPlayer = new SerializablePlayer()
{
    Health = this.Health,
    Level = this.Level,
    Coolness = this.Coolness
};
SaveData.Save<SerializablePlayer>(serializedPlayer, "PlayerStats");
````
Load player:

````
SerializablePlayer playerData = SaveData.Load<SerializablePlayer>("PlayerStats");
````

This is a trick you may be familiar with if you've worked in Unity long enough. 
