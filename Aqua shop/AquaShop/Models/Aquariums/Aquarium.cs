using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private Dictionary<string, IFish> fishes;

        private List<IDecoration> decorations;

        public Aquarium(string name, int capacity)
        {
            this.fishes = new Dictionary<string, IFish>();
            this.decorations = new List<IDecoration>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes.Values;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.Capacity <= this.fishes.Count)
            {
                throw new ArgumentException("Not enough capacity.");
            }

            if (!this.fishes.ContainsKey(fish.Name))
            {
                this.fishes.Add(fish.Name, fish);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.fishes.Values)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fishes.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine("Fish: " + string.Join(", ", this.fishes.Keys));
            }

            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish.Name);           
        }
    }
}
