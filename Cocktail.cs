using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        private string name;
        private int capacity;
        private int maxAlcoholLevel;

        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int MaxAlcoholLevel { get => maxAlcoholLevel; set => maxAlcoholLevel = value; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {

            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient) 
        {
            if (!this.ingredients.Contains(ingredient) && this.ingredients.Count < this.Capacity && this.MaxAlcoholLevel > ingredient.Alcohol)
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            
            foreach (Ingredient ingredients in ingredients)
            {
                if (ingredients.Name == name)
                {
                    
                    Ingredients.Remove(ingredients);
                    return true;

                    
                }
                

            }
            return false;
        }

        public string FindIngredient(string name) 
        {
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient.Name == name)
                {
                    return name;
                }
            }
            return null;
        }

        public Ingredient GetMostAlcoholicIngredient() 
        {

            Ingredients.OrderByDescending(x => x.Alcohol);
            return Ingredients.FirstOrDefault();
        }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: " + CurrentAlcoholLevel);
            foreach (Ingredient ingredient in ingredients)
            {
                sb.Append(ingredient.ToString());
            }

            return sb.ToString();
            


        }


    }
}
