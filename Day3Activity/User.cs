public class User{

    public int id { get; set; }
    public string name { get; set; }
    public bool gender { get; set; }
    public User(int id, string name, bool gender)
    {
        this.id = id;
        this.name = name;
        this.gender = gender;
    }
}

// Derserialize into list, make .json files for users and books.