namespace Homework3.Task2_Behavioral.TemplateMethod;

public class PDFMiner : DataMiner
{
    protected override void ExtractData()
    {
        Console.WriteLine("[TemplateMethod]: Extracting text and images from PDF...");
    }

    protected override void ParseData()
    {
        Console.WriteLine("[TemplateMethod]: Parsing PDF structure into a data stream.");
    }
}