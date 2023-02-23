
namespace OS {

    public class PriorityQueue<T>
    {
        private List<(T, int)> elements = new List<(T, int)>();

        public int Count => elements.Count;

        public void EnqueueAsc(T item, int priority)
        {
            elements.Add((item, priority));
            int index = elements.Count - 1;

            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (elements[parentIndex].Item2 <= priority)
                {
                    break;
                }

                elements[index] = elements[parentIndex];
                index = parentIndex;
            }

            elements[index] = (item, priority);
        }

        public void EnqueueDsc(T item, int priority)
        {
            elements.Add((item, priority));
            int index = elements.Count - 1;

            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (elements[parentIndex].Item2 >= priority)
                {
                    break;
                }

                elements[index] = elements[parentIndex];
                index = parentIndex;
            }

            elements[index] = (item, priority);
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }

            T result = elements[0].Item1;
            int lastIndex = elements.Count - 1;
            int parentIndex = 0;

            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                int rightChildIndex = parentIndex * 2 + 2;

                if (leftChildIndex > lastIndex)
                {
                    break;
                }

                int smallerChildIndex = leftChildIndex;

                if (rightChildIndex <= lastIndex && elements[rightChildIndex].Item2 < elements[leftChildIndex].Item2)
                {
                    smallerChildIndex = rightChildIndex;
                }

                if (elements[smallerChildIndex].Item2 >= elements[lastIndex].Item2)
                {
                    break;
                }

                elements[parentIndex] = elements[smallerChildIndex];
                parentIndex = smallerChildIndex;
            }

            elements[parentIndex] = elements[lastIndex];
            elements.RemoveAt(lastIndex);

            return result;
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }

            return elements[0].Item1;
        }

        public bool Contains(T item)
        {
            return elements.Any(x => x.Item1.Equals(item));
        }
    }
}