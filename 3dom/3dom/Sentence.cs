using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dom
{
    public class Sentence : ICollection<ISentencePart>
    {
        private List<ISentencePart> _sentence = new List<ISentencePart>();

        public int Count => ((ICollection<ISentencePart>)_sentence).Count;

        public bool IsReadOnly => false;
        public void Add(ISentencePart item)
        {
            _sentence.Add(item);
        }
        public void Clear()
        {
            _sentence.Clear();
        }

        public bool Contains(ISentencePart item)
        {
            return ((ICollection<ISentencePart>)_sentence).Contains(item);
        }

        public void CopyTo(ISentencePart[] array, int arrayIndex)
        {
            ((ICollection<ISentencePart>)_sentence).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ISentencePart> GetEnumerator()
        {
            return ((ICollection<ISentencePart>)_sentence).GetEnumerator();
        }

        public bool Remove(ISentencePart item)
        {
            return ((ICollection<ISentencePart>)_sentence).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<ISentencePart>)_sentence).GetEnumerator();
        }

        internal void Add(Word item1)
        {
            throw new NotImplementedException();
        }

        internal void Add(Punktuation item2)
        {
            throw new NotImplementedException();
        }
    }
}