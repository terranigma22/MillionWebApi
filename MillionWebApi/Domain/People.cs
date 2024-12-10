using System;

namespace MillionWebApi.Domain;

public class People
{
    public int Id { get; set; }
    public required string Name { get; set; } = "";
    public required int Age { get; set; }
}
