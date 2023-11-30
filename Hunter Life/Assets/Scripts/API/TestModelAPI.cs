public class TestModelAPI
{
    public TestModelAPI(string id, string itemName, string description, string image, int price)
    {
        _id = id;
        this.itemName = itemName;
        this.description = description;
        this.image = image;
        this.price = price;
    }

    public string _id { get; set; }
    public string itemName { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public int price { get; set; }
}
