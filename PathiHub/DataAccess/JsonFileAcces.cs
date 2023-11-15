using Newtonsoft.Json;

public class JsonFileAccess<T>
{
    private List<T> itemList = new List<T>();
    private string fileName;


    public JsonFileAccess(string fileName)
    {
        this.fileName = fileName;
    }

    public void SaveToJson()
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
}
