namespace TheKataTesting
{
    using TheKata;
    using NSubstitute;
    using System.Linq;


    [TestFixture]
    public class CopierTest
    {
        private ISource _source;
        private IDestination _destination;
        private Copier _copier;

        [SetUp]
        public void Setup()
        {
            _source = Substitute.For<ISource>();
            _destination = Substitute.For<IDestination>();
            _copier = new Copier(_source, _destination);
        }

        [Test]
        public void Copy()
        {
            //arrange
            const char V = 'c';
            _source.ReadChar().Returns(V);

            //act
            _copier.Copy();


            //assert
            _destination.Received().WriteChar(V);
        }

        [Test]
        public void Copy_NewLineChar()
        {
            //arrange
            const char V = '\n';
            _source.ReadChar().Returns(V);

            //act
            _copier.Copy();

            //assert
            _destination.DidNotReceive().WriteChar(V);
        }

        [Test]
        public void Copy_NullChar()
        {
            //arrange
            const char V = '\0';
            _source.ReadChar().Returns(V);

            //act
            _copier.Copy();

            //assert
            _destination.DidNotReceive().WriteChar(V);
        }

        [Test]
        public void Copy_Chars()
        {
            //arrange
            int count = 3;
            char[] arr = { '1', '2', '3' };
            _source.ReadChars(count).Returns(arr);

            //act
            _copier.CopyChars(count);

            //assert
            _destination.Received().WriteChars(Arg.Is<char[]>(x => x.SequenceEqual(arr)));
        }

        [Test]
        public void Copy_CharsWithNewLine()
        {
            //arrange
            int count = 4;
            char[] arr = { '1', '2', '3', '\n' };
            int index = Array.IndexOf(arr, '\n');
            char[] destination_arr = arr.Take(arr.Length - (arr.Length - index)).ToArray();
            _source.ReadChars(count).Returns(arr);

            //act
            _copier.CopyChars(count);

            //assert
            _destination.Received().WriteChars(Arg.Is<char[]>(x => x.SequenceEqual(destination_arr)));
        }
    }
}