using System.Collections.Generic;
using Matrix.Data.Model;

namespace Matrix.Data.DataAccess.Interface
{
    public interface IMatrixRepository
    {
        List<string> GetMatrixData(MatrixModel matrixModel, int[,] matrix);
    }
}
