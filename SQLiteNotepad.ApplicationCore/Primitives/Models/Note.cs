namespace SQLiteNotepad.ApplicationCore.Primitives.Models;

public class Note
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateDateTime { get; set; }

    public Note(){}
    
    public Note(int id, string name, string description, DateTime createDateTime)
    {
        Id = id;
        Name = name;
        Description = description;
        CreateDateTime = createDateTime;
    }
}