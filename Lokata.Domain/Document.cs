using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Document : EntityBase
{
    public string Name { get; set; }

    public string Filename { get; set; }

    public byte[] FileContent { get; set; } = Array.Empty<byte>();
}
