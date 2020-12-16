namespace AdventOfCode2020
{
    public struct CircularBuffer<T>
    {
        private readonly T[] _buffer;
        private int _currentIndex;

        public int Count { get; private set; }

        public CircularBuffer(int capacity)
        {
            _buffer = new T[capacity];
            _currentIndex = -1;
            Count = 0;
        }

        public T this[int idx]
        {
            get
            {
                var actualIdx = (_currentIndex + idx) % _buffer.Length;
                return _buffer[actualIdx];
            }
        }

        public void Add(T item)
        {
            _currentIndex = (_currentIndex + 1) % _buffer.Length;
            _buffer[_currentIndex] = item;

            if (Count < _buffer.Length)
                Count++;
        }
    }
}
