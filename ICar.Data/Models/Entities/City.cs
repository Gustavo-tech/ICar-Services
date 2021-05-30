using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public City()
        { }
    }
}
