using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compress_research
{
    class BWT
    {
        public string Message { get; set; }

        private int _length;
        private string[] _matrix;

        public int Number { get; set; }
        public BWT() { }

        private string LeftRotateString(string value, int count)
        {
            string newString = "";

            newString = value.Substring(1, value.Length - count);
            newString = newString + value[0];//.Substring(0, 1);

            return newString;
        }

        private void Init(string message, int number = 0)
        {
            Message = message;
            _length = Message.Length;
            _matrix = new string[_length];
            Number = number;
        }

        private void RenderMatrix()
        {

            _matrix[0] = Message;

            for (int i = 1; i < _length; i++)
            {
                _matrix[i] = LeftRotateString(_matrix[i - 1], 1);
            }

            Array.Sort(_matrix);
        }

        private string GetLastColl()
        {
            string value = "";

            for (int i = 0; i < _length; i++)
            {
                value += _matrix[i].Substring(_length - 1);
            }

            return value;
        }

        private void SetNumber()
        {
            Number = Array.IndexOf(_matrix, Message);
        }

        public string encrypt(string message)
        {
            string encryptMessage;
            Init(message);
            RenderMatrix();
            encryptMessage = GetLastColl();
            SetNumber();

            return encryptMessage;
        }

        public string decrypt(string message, int number)
        {
            Init(message, number);
            RenderDecryptMatrix();

            return GetDecryptMessage();
        }

        private string GetDecryptMessage()
        {
            return _matrix[Number];
        }

        private void RenderDecryptMatrix()
        {
            for (int j = 0; j < _length; j++)
            {
                for (int i = 0; i < _length; i++)
                {
                    _matrix[i] = Message.Substring(i, 1) + _matrix[i];

                }
                Array.Sort(_matrix);
            }

        }

        private int ArrayMin(string[] data, int start)
        {
            int minPos = start;
            for (int pos = start + 1; pos < data.Length; pos++)
                if (data[pos].CompareTo(data[minPos]) == -1)
                    minPos = pos;
            return minPos;
        }

        private int[] GenerateIntervals(int n)
        {
            if (n < 2)
            {  // no sorting will be needed
                return new int[0];
            }
            int t = Math.Max(1, (int)Math.Log(n, 3) - 1);
            int[] intervals = new int[t];
            intervals[0] = 1;
            for (int i = 1; i < t; i++)
                intervals[i] = 3 * intervals[i - 1] + 1;
            return intervals;
        }

        private string[] BubbleSort(string[] array)
        {
            string[] sortedArray = array;
            int N = array.Length;
            string temp;
            for (int j = N - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (sortedArray[i].CompareTo(sortedArray[i + 1]) == 1)
                    {
                        temp = sortedArray[i + 1];
                        sortedArray[i + 1] = sortedArray[i];
                        sortedArray[i] = temp;
                    }
                }
            }
            return sortedArray;
        }

        private string[] SelectionSort(string[] data)
        {
            int i;
            string temp;
            string[] SortedArray = data;
            int N = data.Length;

            for (i = 0; i < N - 1; i++)
            {
                int k = ArrayMin(SortedArray, i);
                if (i != k)
                {
                    temp = SortedArray[k];
                    SortedArray[k] = SortedArray[i];
                    SortedArray[i] = temp;
                }
            }
            return SortedArray;
        }

        private string[] InsertionSort(string[] data)
        {
            int i, j;
            int N = data.Length;
            string temp;
            string[] SortedArray = data;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && SortedArray[i].CompareTo(SortedArray[i - 1]) == -1; i--)
                {
                    temp = SortedArray[i - 1];
                    SortedArray[i - 1] = SortedArray[i];
                    SortedArray[i] = temp;
                }
            }

            return SortedArray;
        }

        private string[] ShellSort(string[] data)
        {
            int i, j, k, m;
            string temp;
            string[] SortedArray = data;
            int N = data.Length;
            int[] intervals = GenerateIntervals(N);

            for (k = intervals.Length - 1; k >= 0; k--)
            {
                int interval = intervals[k];
                for (m = 0; m < interval; m++)
                {
                    for (j = m + interval; j < N; j += interval)
                    {
                        for (i = j; i >= interval && SortedArray[i].CompareTo(SortedArray[i - interval]) == -1; i -= interval)
                        {
                            temp = SortedArray[i - interval];
                            SortedArray[i - interval] = SortedArray[i];
                            SortedArray[i] = temp;
                        }
                    }
                }
            }
            return SortedArray;
        }
    }
}
