using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }

        string Slug { get; set; }

    }
}
