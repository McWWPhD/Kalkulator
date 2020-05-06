using System.Security.Cryptography.X509Certificates;

namespace Calculator
{
    class Math
    {
        private double result;

        public double Calculations (double arg1, double arg2, char oper)
        {

            switch (oper)
            {
                case '+':
                    result = arg1 + arg2;
                    break;

                case '-':
                    result = arg1 - arg2;
                    break;

                case '*':
                    result = arg1 * arg2;
                    break;

                case '/':
                    result = arg1 / arg2;
                    break;

                default:
                    break;
            }

            return result;
        }


	}




}





