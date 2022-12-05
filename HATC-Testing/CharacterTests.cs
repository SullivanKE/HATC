using HATC.Controllers;
using HATC.Data;
using HATC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;


namespace HATC_Testing
{
    public class CharacterTests
    {
        CharactersController controller;
        HavenDbContext context;
        public CharacterTests(HavenDbContext c) 
        {
            context = c;
            controller = new CharactersController(c);
        }

/*        [Fact]
        public void Index()
        {
            // Arrange
            List<Character> characters = new List<Character>();

            // Act
            ViewResult viewResult = controller.Index();

            // Assert
            Assert.NotNull(viewResult);

        }*/
    }
}
