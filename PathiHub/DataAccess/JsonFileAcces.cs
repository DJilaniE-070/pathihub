using Newtonsoft.Json;

public class JsonFileAccess<T>
{
    protected List<T> itemList = new List<T>();
    protected string fileName;


    public JsonFileAccess(string fileName)
    {
        this.fileName = fileName;
    }

    public virtual void SaveToJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/", fileName));
        string json = JsonConvert.SerializeObject(itemList, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public bool LoadFromJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/", fileName));
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            itemList = JsonConvert.DeserializeObject<List<T>>(json);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<T> GetItemList()
    {
        return itemList;
    }
    public void RemoveThing(T Thing)
    {
        itemList.Remove(Thing);
    }

    public void AddThing (T Thing)
    {
        itemList.Add(Thing);
    }
}
