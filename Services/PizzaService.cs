using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 11; // 10 default pizzas, so 11 is next Id
        static PizzaService()
        {
            // Default pizza list in cache
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", Description = "Classic Italian pizza", Price = 25, IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni with mozzarella", Price = 28, IsGlutenFree = false },
                new Pizza { Id = 3, Name = "Margherita", Description = "Tomato, mozzarella, and basil", Price = 22, IsGlutenFree = false },
                new Pizza { Id = 4, Name = "BBQ Chicken", Description = "Grilled chicken with BBQ sauce", Price = 30, IsGlutenFree = true },
                new Pizza { Id = 5, Name = "Veggie Delight", Description = "Loaded with fresh vegetables", Price = 24, IsGlutenFree = true },
                new Pizza { Id = 6, Name = "Hawaiian", Description = "Ham and pineapple", Price = 27, IsGlutenFree = false },
                new Pizza { Id = 7, Name = "Four Cheese", Description = "Mozzarella, parmesan, gorgonzola, and ricotta", Price = 29, IsGlutenFree = false },
                new Pizza { Id = 8, Name = "Spicy Mexican", Description = "Spicy chorizo, jalapeños, and onions", Price = 31, IsGlutenFree = false },
                new Pizza { Id = 9, Name = "Mediterranean", Description = "Olives, feta cheese, and sun-dried tomatoes", Price = 26, IsGlutenFree = true },
                new Pizza { Id = 10, Name = "Truffle Mushroom", Description = "Mushrooms with truffle oil", Price = 35, IsGlutenFree = false }
            };
        }

        public static List<Pizza> GetPizzas() => Pizzas;
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++; // add Id property to the pizza
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza == null)
                return; // The method stops if there's no pizza

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id); 
            if (index == -1) // FindIndex returns -1 if there is no such Id
                return;

            Pizzas[index] = pizza; // Update the pizza
        }

    }
}