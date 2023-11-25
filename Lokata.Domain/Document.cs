using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Document
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Filename { get; set; }

    public byte[]? FileContent { get; set; }
}
