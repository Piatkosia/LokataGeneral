using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Category : EntityBase
{

    public string CategoryName { get; set; }

    public int MinAgeInYears { get; set; } = 6;

    public int? MaxAgeInYears { get; set; } = 120;

    public bool ForDisabled { get; set; }

    public bool ForProfessional { get; set; }

    public bool ForFemale { get; set; }

    public bool ForMale { get; set; }
}
