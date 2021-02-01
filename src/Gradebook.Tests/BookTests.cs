using System;
using Gradebook.ConsoleApp;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("BookTest");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var results = book.GetStatistics();

            // asert
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.5, results.Highest, 1);
            Assert.Equal(77.3, results.Lowest, 1);
        }

        [Fact]
        public void TestOfGradeValidation()
        {
            // arrange
            var book = new Book("BookTest");
            book.AddGrade(101);
            book.AddGrade(-1);

            // asert
            Assert.True(book.Grades.Count < 1);
        }
    }
}
