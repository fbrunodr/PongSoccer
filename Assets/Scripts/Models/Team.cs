namespace TeamNamespace{
public class Team
{
    private string name;
    private string image;
    private string material;

    public Team(){}
    public Team(string name)
    {
        setName(name);
    }

    public void setName(string name)
    {
        this.name = name;
        image = "Images/Teams/" + name;
        material = "Images/Teams/Materials/" + name;
    }

    public string getName()
    {
        return name;
    }

    public string getImagePath()
    {
        return image;
    }

    public string getMaterialPath()
    {
        return material;
    }
}
}