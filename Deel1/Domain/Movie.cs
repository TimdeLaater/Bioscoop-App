using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deel1.Domain
{
    public class Movie
    {
        public string Title { get; }

        public Movie(string title)
        {
            Title = title;
        }
        public void AddScreening(MovieScreening screening)
        {

        }

        public override string? ToString()
        {
            return Title;
        }
    }
}
