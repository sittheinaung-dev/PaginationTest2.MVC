using System;
using System.Collections.Generic;

namespace PaginationTest.Database.AppDbContextModels;

public partial class Customer
{
    public int Id { get; set; }

    public string? ContactName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
