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
        public string Encrypt(string message)
        {
            string encryptMessage;
            Init(message);
            RenderMatrix();
            encryptMessage = GetLastColl();
            SetNumber();

            return encryptMessage;
        }

        public string Decrypt(string message, int number)
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
    }
}
