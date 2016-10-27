namespace views
{
    public interface IView
    {
        string Run(string passedData = "");
    }
}
