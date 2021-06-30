using System;
using Microsoft.AspNetCore.Mvc;
using Matrix.Data.DataAccess.Interface;
using Matrix.Data.Model;
using Matrix.Data.Common;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Sample_Levenscheintine.Controllers
{
    [SecretAuthenticationFilter]
    [ApiController]
    [Route("[controller]")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger<ComputeController> _logger;
        private IMatrixRepository _matrixRepository;

        public ComputeController(ILogger<ComputeController> logger, IMatrixRepository imatrixRepository)
        {
            this._logger = logger;
            this._matrixRepository = imatrixRepository;
        }
        /// <summary>
        /// To get matrix detail based on Input
        /// </summary>
        /// <param name="matrixmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] MatrixModel matrixModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(matrixModel.FirstInput.ToString()) && !string.IsNullOrEmpty(matrixModel.SecondInput.ToString()))
                {
                    var matrix = new int[matrixModel.FirstInput.Length + 1, matrixModel.SecondInput.Length + 1];

                    for (int i = 0; i < matrixModel.FirstInput.Length + 1; i++)
                        matrix[i, 0] = i;

                    for (int j = 0; j < matrixModel.SecondInput.Length + 1; j++)
                        matrix[0, j] = j;

                    List<string> listingdata = _matrixRepository.GetMatrixData(matrixModel, matrix);
                    return Ok((result: "success", message: "Valid Data", MatrixData: listingdata, TotalDistance: matrixModel.TotalDistance));
                }
                else
                {
                    return Ok((result: "Error", message: "Invalid FirstInput or SecondInput."));
                }
            }
            catch (Exception ex)
            {
                return Ok((result: "Error", message: "Invalid Exception."));
            }
        }
    }
}