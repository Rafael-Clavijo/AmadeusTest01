using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AmadeusTestWebApp01.Controllers;
using AmadeusTestWebApp01.Models;

namespace AmadeusTestWebApp01.Tests
{
    [TestClass]
    public class TestGameController
    {
        [TestMethod]
        public void GetAllGames_ShouldReturnAllGames()
        {
            var testProducts = GetTestProducts();
            var controller = new GameController(testProducts);

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        private List<Game> GetTestGames()
        {
            var testGames = new List<Game>();
            /*
testGames.Add(new Game {Id=1, Title="Elden Ring", Genre="Soulslike	2/2/2022 12:00:00 AM
testGames.Add(new Game {Id=2, Title="Tomb Raider", Genre="Adventure	11/8/1998 12:00:00 PM
testGames.Add(new Game {Id=3, Title="Outer Wilds", Genre="Puzzle	11/20/2019 12:00:00 AM
             */
            testGames.Add(new Game { });

            return testGames;
        }
    }
}
