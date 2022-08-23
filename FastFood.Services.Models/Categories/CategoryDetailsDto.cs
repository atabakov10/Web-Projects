using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Models.Categories
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Items { get; set; }
    } 
}
