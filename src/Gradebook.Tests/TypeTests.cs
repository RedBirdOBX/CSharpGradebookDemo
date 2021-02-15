using System;
using Gradebook.ConsoleApp;
using Xunit;

namespace GradeBook.Tests
{
    // use 'dotnet test' at CLI.

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate logDelegate = ReturnMessage;
            var result = logDelegate("hello");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "Book 2");

            //https://app.pluralsight.com/course-player?clipId=d8476418-6861-4720-b0b9-f818632e2189
            Assert.Equal("Book 1", book1.BookName);
        }

        [Fact]
        public void NameChangeTest()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.BookName);
        }

        [Fact]
        public void GetBookNameTest()
        {
            var book1Name = "Book 1";
            var book1 = GetBook(book1Name);

            var book2Name = "Book 2";
            var book2 = GetBook(book2Name);

            bool isSame = Object.ReferenceEquals(book1, book2);


            Assert.Equal(book1Name, book1.BookName);
            Assert.Equal(book2Name, book2.BookName);
        }

        [Fact]
        public void InstanceTest()
        {
            var book1Name = "Book 1";
            var book1 = GetBook(book1Name);

            var book2 = book1;

            // is the same as....
            Assert.Same(book1, book2);

            // this...
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void TestInt()
        {
            var x = GetInt();

            // this...
            Assert.Equal(47,x);
        }

        [Fact]
        public void TestBook()
        {
            var book1 = new Book("New Book");
            var book2 = GetNewBook();

            // even though they have the same name, they are not the same.
            Assert.NotSame(book1, book2);
        }

        private Book GetNewBook()
        {
            return new Book("New Book");
        }

        private object GetInt()
        {
            return 47;
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.BookName = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.BookName = name;
        }

        private string ReturnMessage(string msg)
        {
            return msg;
        }
    }
}
