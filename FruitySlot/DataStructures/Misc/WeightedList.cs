using PRNG;
using System.Collections;

namespace FruitySlot.DataStructures.Misc
{
    public class WeightedList<T> : IEnumerable<T>
    {
        public IReadOnlyList<T> Items => _items.ToList().AsReadOnly();

        private T[] _items { get; set; }
        private (int, int)[] _weights { get; set; }

        public WeightedList(IEnumerable<T> valuesInit, IEnumerable<int> weightsInit)
        {
            var values = valuesInit.ToArray();
            var weights = weightsInit.ToArray();
            if (values?.Length != weights?.Length && values != null)
            {
                throw new Exception($"Weighted list beign constructed with invalid number of values {values?.Length} and weights {weights?.Length}.");
            }
            _items = values;
            _weights = new (int, int)[weights.Length];
            var totalWeights = 0;
            for (int i = 0; i < _weights.Length; i++)
            {
                _weights[i] = (totalWeights, totalWeights + weights[i]);
                totalWeights += weights[i];
            }
        }

        public T GetItem(PseudoRandom r)
        {
            // Get all weights and select random value (note, weights start from 0, therefore weights are lower bound inclusive and upper bound exclusive)
            var i = r.GetLong(_weights.Last().Item2);

            // binary search
            int low = 0;
            int mid;
            int high = _weights.Length - 1;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (i < _weights[mid].Item1)
                    high = mid - 1;
                else if (i >= _weights[mid].Item2)
                    low = mid + 1;
                else
                    return _items[mid];
            }
            throw new Exception("Binary search has been incorrectly implemented.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
