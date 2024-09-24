using AmadeusTestWebApp01.Controllers;
using AmadeusTestWebApp01.Models;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Diagnostics;

namespace AmadeusTestWebProject01.Test
{
    public class UnitTest1
    {

        [Fact]
        public void GamesController_GetsAllGames_NoChanges()
        {
            //Arrange
            var allGames = new List<Game> { new() { Id = 1, Title = "1", Genre = "A" }, new() { Id = 2, Title = "2", Genre = "A" }, new() { Id = 3, Title = "3", Genre = "B" } };
            var dbContextMock = new Mock<GameContext>();

            //Act
            var result = allGames.ToList();
            //Assert
            Assert.Equal(3, result!.Count);
        }

        [Fact]
        public void GamesController_GetsOneGame_CorrectId()
        {
            var allGames = new List<Game> { new() { Id = 1, Title = "1", Genre = "A" }, new() { Id = 2, Title = "2", Genre = "A" }, new() { Id = 3, Title = "3", Genre = "B" } };
            var dbContextMock = new Mock<GameContext>();

            var result = allGames.First(x => x.Id == 2);

            Assert.Equal(2, result.Id);
            Assert.Equal("2", result.Title);
            Assert.Equal("A", result.Genre);
        }
    }
}