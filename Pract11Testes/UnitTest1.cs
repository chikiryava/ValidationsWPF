using pract11.Extensions;
using pract11.SimpleEventHandler;

namespace Pract11Testes
{
    public class IsbnTests
    {
        private Book _book;
        [SetUp]
        public void SetUp()
        {
            _book = new();
        }
        [Test]
        public void ValidIsbnTest1()
        {
            _book.Isbn10 = "1-1234-5678-9";
            Assert.IsTrue(_book.Isbn10.IsIsbn10());
        }
        [Test]
        public void InvalidIsbnTest1()
        {
            _book.Isbn10 = "12-1234-5678-9";
            Assert.IsFalse(_book.Isbn10.IsIsbn10());
        }
        [Test]
        public void InvalidIsbnTest2()
        {
            _book.Isbn10 = "1234-5678-9";
            Assert.IsFalse(_book.Isbn10.IsIsbn10());
        }
        [Test]
        public void InvalidIsbnTest3()
        {
            _book.Isbn10 = "1-1d34-5678-9";
            Assert.IsFalse(_book.Isbn10.IsIsbn10());
        }
    }   
}