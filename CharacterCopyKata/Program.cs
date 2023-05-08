namespace TheKata
{
    using System.Linq;
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource src, IDestination dest)
        {
            _source = src;
            _destination = dest;
        }

        public void Copy()
        {
            char c = _source.ReadChar();
            if (c != '\n' & c != '\0')
            {
                _destination.WriteChar(c);
            }

        }

        public void CopyChars(int count)
        {
            char[] values = _source.ReadChars(count);

            int index = Array.IndexOf(values, '\n');

            if (index != -1)
            {
                char[] writeVals = values.Take(values.Length - (values.Length - index)).ToArray();
                _destination.WriteChars(writeVals);
            }

            _destination.WriteChars(values);


        }

        static void Main(string[] args)
        {
            Console.WriteLine("The Character Copy Kata");
        }
    }

    public interface ISource
    {
        public char ReadChar();

        public char[] ReadChars(int count);
    }

    public interface IDestination
    {
        public void WriteChar(char c);

        public void WriteChars(char[] values);
    }
}