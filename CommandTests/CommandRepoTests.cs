using System;
using Xunit;
using System.Collections.Generic;
using CommandsAPI.Models;
using CommandsAPI.Data;
using Moq;

namespace CommandTests
{
    public class CommandRepoTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var mockRepo = new Mock<ICommandRepo>();
            mockRepo.Setup(repo => (repo.GetAllCommands())).Returns(GetCommands());

            //Act
            var result = mockRepo.Object.GetAllCommands();

            //Assert
            Assert.IsType<IEnumerable<Command>>(result);
            Assert.Single(result);
        }


        public IEnumerable<Command> GetCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil Coffee", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a Knife", Platform="Knife & Chooping board"}

            };
            return commands;
        }
    }
}
