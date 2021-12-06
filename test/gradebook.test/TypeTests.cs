using GradeBook;
using Xunit;

namespace gradebook.test
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x); // needs ref also here

            Assert.Equal(42, x);

        }

        private void SetInt(ref int anyName)
        {
            anyName = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact] // this is an attribute -> decorator
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name"); // also needs the ref keyword

            Assert.Equal("New Name", book1.Name);

        }
        
        private void GetBookSetName(ref Book book, string name) //ref = pass by reference
        {/* passes the reference to the object, thus modifying it
        also works with out, but requires to initialize the output parameter -> you need to create the book object*/
            book = new Book(name);
            book.Name = name;
        }

        [Fact] // this is an attribute -> decorator
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        
        private void GetBookSetName(Book book, string name) // pass by value
        {/* does not change the original passed object;
        everything happens locally, so the name of book1 won't change outside*/
            book = new Book(name);
            book.Name = name;
        }

        [Fact] // this is an attribute -> decorator
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact] // this is an attribute -> decorator
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

                [Fact] // this is an attribute -> decorator
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }


        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}