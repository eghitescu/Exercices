using System;
using System.Collections.Generic;

namespace Exercices
{
    public class RemoveDuplicates
    {
        private const int lengthLimit = 100;

        public static int[] Run(int[] source)
        {
            if (source == null || source.Length <= 1 )
                return source;
            if (source.Length > lengthLimit)
                throw new ArgumentException("Source array is too long");
            int firstValue = source[0];
            BinaryTree<int> searchTree = new BinaryTree<int>(firstValue);
            int length = source.Length;
            bool[] duplicatedElements= new bool[length];
            BinarySearch<int> binarySearch = new BinarySearch<int>();
            for (int i = 1; i < length; i++)
                duplicatedElements[i] = binarySearch.Search(source[i], searchTree);
            
            List<int> result = new List<int>(length);
            for (int i = 0;i < length;i++)
                if (!duplicatedElements[i])
                    result.Add(source[i]);
            return result.ToArray();
        }


    }

    public class BinarySearch<T> where T : IComparable
    {
        public bool Search(T value, BinaryTree<T> binaryTree)
        {
            if ((value == null) || (binaryTree == null) || binaryTree.Value == null)
                return false;
            if (binaryTree.Value.Equals(value))
                return true;
            if (value.CompareTo(binaryTree.Value) < 0)
                if (binaryTree.Left is null)
                { 
                    binaryTree.Left = new BinaryTree<T>(value);
                    return false;
                }
                else
                    return Search(value, binaryTree.Left);
            if (value.CompareTo(binaryTree.Value) > 0)
                if (binaryTree.Right is null)
                {
                    binaryTree.Right = new BinaryTree<T>(value);
                    return false;
                }
                else
                    return Search(value, binaryTree.Right);
            //default case: should not happen
            return false;
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }
    }
}
