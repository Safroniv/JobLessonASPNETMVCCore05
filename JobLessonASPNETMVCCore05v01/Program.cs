

StrategyPdfScan pdf = new StrategyPdfScan();
StrategyImgScan image = new StrategyImgScan();

Mashine mashine = new Mashine();
Scanner scanner = new Scanner(mashine);

Console.WriteLine(mashine.Scan());

scanner.StrategyWorkScanner(image);
scanner.Execute();
scanner.StrategyWorkScanner(pdf);
scanner.Execute();


public interface IScanner
{
    string Scan();
}

public class Mashine : IScanner
{
    public string Scan()
    {
        return "Device сканирует";

    }
}

public class StreamScanToJPG : IScanner
{
    public string Scan()
    {
        return "Сканирование и сохранение в JPG";

    }
}
public interface IStrategyScan
{
    void ScanCreater(IScanner scanner, string NameOfFile);
}

public sealed class Scanner
{
    private readonly IScanner _mashine;
    private IStrategyScan _strategyScan;
    public Scanner(IScanner mashine)
    {
        _mashine = mashine;
    }
    public void StrategyWorkScanner(IStrategyScan strategyScan)
    {
        _strategyScan = strategyScan;
    }

    public void Execute(string NameOfFile = "")
    {
        if (_mashine is null)
        {
            throw new ArgumentNullException("Не выбрано устройство.");
        }
        if (_strategyScan is null)
        {
            throw new ArgumentNullException("Не указан формат вывода.");
        }
        if (string.IsNullOrWhiteSpace(NameOfFile))
        {
            NameOfFile = Guid.NewGuid().ToString();
        }
        _strategyScan.ScanCreater(_mashine, NameOfFile);
    }
}
public sealed class StrategyPdfScan : IStrategyScan
{
    public void ScanCreater(IScanner scannerDevice, string outputFileName)
    {
        Console.WriteLine("Работа по сканированию и сохранению в формат PDF.");
    }
}
public sealed class StrategyImgScan : IStrategyScan
{
    public void ScanCreater(IScanner scannerDevice, string outputFileName)
    {
        Console.WriteLine("Работа по сканированию и сохранению в формат Image.");
    }
}


