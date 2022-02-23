namespace TeamNamespace{
public class Team
{
    private string name;
    private string image;

    public Team(){}
    public Team(string name)
    {
        setName(name);
    }

    public void setName(string name)
    {
        this.name = name;
        image = "Images/Teams/Materials/" + name;
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