public class GameData
{
    public string windowText;
    public bool puzzle1;
    public bool puzzle2;
    public bool puzzle3;
    public bool puzzle4;

    override
    public string ToString()
    {
        return windowText + " " + puzzle1.ToString() + " " + puzzle2.ToString() + " " + puzzle3.ToString() + " " + puzzle4.ToString();
    }
}