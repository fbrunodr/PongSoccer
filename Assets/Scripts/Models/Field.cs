namespace FieldNamespace{

public class Field
{
    private string name;
    private string image;

    public Field(){}
    public Field(string name)
    {
        setName(name);
    }

    public void setName(string name)
    {
        this.name = name;
        image = "Images/Fields/Materials/" + name;
    }

    public string getName()
    {
        return name;
    }

    public string getImagePath()
    {
        return image;
    }
}
}