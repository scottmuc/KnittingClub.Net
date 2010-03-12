using System;
using KnittingClub.Services.ApplicationStartup;
using Xunit;

namespace KnittingClub.Tests.Services.ApplicationStartup
{
    public class DatabaseInitializerTests
    {
        [Fact]
        public void FactMethodName()
        {
            var sut = new DatabaseInitializer();

            sut.InitializeDatabase();
        }
    }
}