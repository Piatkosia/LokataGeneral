using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Category : EntityBase
{

    public string CategoryName { get; set; }

    public int? MinAgeInYears { get; set; }

    public int? MaxAgeInYears { get; set; }

    public bool? ForDisabled { get; set; }

    public bool? ForProffessional { get; set; }

    public bool? ForFemale { get; set; }

    public bool? ForMale { get; set; }
}
