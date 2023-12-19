using System;
using System.Collections.Generic;

namespace BookMVC.Models;

public partial class TblBook
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public decimal BookPrice { get; set; }
}
