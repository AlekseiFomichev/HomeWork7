namespace HomeWork7.Models;

internal struct Worker
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Height { get; set; }
    public DateTime Time { get; set; }
    public string BornPlace { get; set; }

    public override string ToString()
    {
        return $"{Id}#{FullName}#{Age}#{Height}#{Time}#{BornPlace}";
    }
}