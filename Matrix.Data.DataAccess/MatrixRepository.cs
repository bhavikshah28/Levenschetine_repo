using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Data.Model;
using Matrix.Data.DataAccess.Interface;

namespace Matrix.Data.DataAccess
{
    public class MatrixRepository : IMatrixRepository
    {
        /// <summary>
        /// Get Matrix Data
        /// </summary>
        /// <param name="matrixModel"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public List<string> GetMatrixData(MatrixModel matrixModel, int[,] matrix)
        {
            List<string> lststr = new List<string>();
            string strMatrix = "  ";

            for (int i = 0; i < matrixModel.SecondInput.Length; i++)
                strMatrix += matrixModel.SecondInput[i];
            lststr.Add(strMatrix);

            for(int i = 0; i <= matrixModel.FirstInput.Length; i++)
            {
                strMatrix = i > 0 ? matrixModel.FirstInput[i - 1].ToString() + "" : " ";

                if(i == 0)
                {
                    for (int j = 0; j < matrixModel.SecondInput.Length + 1; j++)
                        strMatrix += matrix[i, j];
                }
                else
                {
                    for(int j = 1; j <= matrixModel.SecondInput.Length; j++)
                    {
                        int cost = matrixModel.FirstInput[i - 1] == matrixModel.SecondInput[j - 1] ? 0 : 1;

                        int topPlus1 = matrix[i - 1, j] + 1;
                        int leftPlus1 = matrix[i, j - 1] + 1;
                        int topLeftPlusCost = matrix[i - 1, j - 1] + cost;

                        var min = Math.Min(topPlus1, leftPlus1);
                        min = Math.Min(min, topLeftPlusCost);
                        if (j == 1)
                            strMatrix += matrix[i, j - 1];
                        matrix[i, j] = min;
                        strMatrix += matrix[i, j];
                    }
                }
                lststr.Add(strMatrix);
            }
            matrixModel.TotalDistance = matrix[matrixModel.FirstInput.Length, matrixModel.SecondInput.Length];
            return lststr;
        }
    }
}
