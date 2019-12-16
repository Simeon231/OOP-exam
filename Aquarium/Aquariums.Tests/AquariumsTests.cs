namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void FishPropertiesAreInvalid()
        {
            var fishName = "Joro";
            var fish = new Fish(fishName);
            Assert.AreEqual(fishName, fish.Name);
            Assert.AreEqual(true, fish.Available);
        }

        [Test]
        public void AquariumPropertiesAreInvalid()
        {
            var aquariumName = "Saltyyy";
            var capacity = 100;
            var aqurium = new Aquarium(aquariumName, capacity);
            Assert.AreEqual(aquariumName, aqurium.Name);
            Assert.AreEqual(capacity, aqurium.Capacity);
        }

        [Test]
        public void AquariumPropertiesShouldThrowAnException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 100));
            Assert.Throws<ArgumentException>(() => new Aquarium("Vega", -1));
        }

        [Test]
        public void AddMethodShouldAddAFish()
        {
            var fish = new Fish("gosho");
            var aquarium = new Aquarium("Vega", 22);
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AddMethodShouldThrowAnException()
        {
            var aquarium = new Aquarium("ses", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("golden")));
        }

        [Test] 
        public void RemoveFishMethodShouldRemoveFish()
        {
            var fish = new Fish("silver");
            var aquarium = new Aquarium("Tera", 22);
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void RemoveFishMethodShouldThrowAnException()
        {
            var fish = new Fish("silver");
            var aquarium = new Aquarium("Tera", 22);
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("golden"));
        }

        [Test]
        public void SellFishShouldReturnAFish()
        {
            var fish = new Fish("silver");
            var aquarium = new Aquarium("Tera", 22);
            aquarium.Add(fish);
            var returnedFish = aquarium.SellFish("silver");
            Assert.AreEqual(fish, returnedFish);
        }

        [Test]
        public void SellFishShouldThrowAnException()
        {
            var fish = new Fish("silver");
            var aquarium = new Aquarium("Tera", 22);
            aquarium.Add(fish);
            aquarium.SellFish(fish.Name);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("golden"));
        }

        [Test]
        public void ReportMethodNotWorkingCorrectly()
        {
            var fish = new Fish("silver");
            var aquarium = new Aquarium("Tera", 22);
            aquarium.Add(fish);
            var report = $"Fish available at {aquarium.Name}: {fish.Name}";
            Assert.AreEqual(report, aquarium.Report());
        }
    }
}
