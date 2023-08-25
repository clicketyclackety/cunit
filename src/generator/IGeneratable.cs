namespace generators;

public interface IGeneratable
{
    public void Generate(out List<string> lines);
}