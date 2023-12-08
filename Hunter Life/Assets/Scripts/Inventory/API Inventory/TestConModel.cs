using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConModel 
{
    public TestConModel(string id, string itemName, string description, string consumable, string image, int price)
    {
        _id = id;
        this.itemName = itemName;
        this.description = description;
        this.consumable = consumable;
        this.image = image;
        this.price = price;
    }

    public string _id {  get; set; }
    public string itemName { get; set; }
    public string description { get; set; }
    public string consumable { get; set; }
    public string image { get;set; }
    public int price { get; set; }
}
