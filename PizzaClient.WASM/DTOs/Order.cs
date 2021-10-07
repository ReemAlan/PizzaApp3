using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace PizzaClient.WASM.DTOs
{
    public class Order
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
        public RepeatedField<string> Toppings { get; set; } = new();
        [Required(ErrorMessage = "Please pick a sauce")]
        public string Sauce { get; set; }
        [Required]
        public double Price { get; set; }
    }
}