using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PizzaClient.Blazor.DTOs
{
    public class OrderWeb
    {
        [Required(ErrorMessage = "You have not chosen any pizza!")]
        public Pizza Pizza { get; set; } = new();
        [Required(ErrorMessage = "Please enter your name")]
        public string CustomerName { get; set; } 
    }

    public class Pizza
    {
        [Required(ErrorMessage = "Please pick a size")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Please pick a dough type")]
        public string Dough { get; set; }
        [Required(ErrorMessage = "Please pick toppings")]
        public List<string> Toppings { get; set; } = new();
        [Required(ErrorMessage = "Please pick a sauce")]
        public string BaseSauce { get; set; }
        [Required]
        public double Price { get; set; }
    }
}