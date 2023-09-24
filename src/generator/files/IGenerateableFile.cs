namespace generator.units;

public interface IGenerateableFile
{
    string GetFilePath();
    List<String> Generate();
}