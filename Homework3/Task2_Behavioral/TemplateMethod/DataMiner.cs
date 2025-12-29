namespace Homework3.Task2_Behavioral.TemplateMethod;

public abstract class DataMiner
{
    public void Mine(string path)
    {
        OpenFile(path);
        ExtractData();
        ParseData();
        CloseFile();
    }

    protected void OpenFile(string path) => Console.WriteLine($"Opening file at: {path}");
    protected void CloseFile() => Console.WriteLine("Closing file.");

    protected abstract void ExtractData();
    protected abstract void ParseData();
}