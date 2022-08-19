using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Exceptions;
using MODELO.Desafio.Model.Request;
using MODELO.Desafio.Model.Result;
using MODELO.Desafio.Service.Interface.Providers;
using MODELO.Desafio.Service.Interface.Updaters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace MODELO.Desafio.API.Controllers
{
    [ExcludeFromCodeCoverageAttribute]
    [Route("api/fair")]
    [ApiController]
    public class FairController : ControllerBase
    {
        private readonly IFairUpdater fairUpdater;
        private readonly IFairProvider fairProvider;
        private readonly ILogger<FairController> logger;
        public FairController(ILogger<FairController> logger,IFairUpdater fairUpdater, IFairProvider fairProvider)
        {
            this.fairUpdater = fairUpdater;
            this.fairProvider = fairProvider;
            this.logger = logger;
        }


        /// <summary>
        /// Busca todas a feiras cadastradas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Fair>> GetAllAsync()
        {
            try
            {
                return await fairProvider.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Busca Feira pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public async Task<FairResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return await fairProvider.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Busca Feira pelo Nome
        /// </summary>
        /// <param name="nameFair"></param>
        /// <returns></returns>
        [HttpGet("nameFair/{nameFair}")]
        public async Task<FairResult> GetByNameFairAsync([FromRoute] string nameFair)
        {
            try
            {
                return await fairProvider.GetByFairNameAsync(nameFair);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }

        /// <summary>
        ///  Inclusão de uma nova feira
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<dynamic>> PostAsync([FromBody] FairRequest dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();

                return await fairUpdater.SaveAsync(dataObject);
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);

                return Ok(new RespostaApi<FairRequest>
                {
                    erro = true,
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        /// Alteração de um cadastro de feira
        /// </summary>
        /// <param name="id">identificador da feira</param>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        [HttpPut("id/{id}")]
        public async Task<ActionResult<dynamic>> PutAsync([FromRoute] int id,[FromBody] FairRequest dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();
                dataObject.Id = id;
                return fairUpdater.UpdateAsync(dataObject);

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Exclusão de um cadastro de feira
        /// </summary>
        /// <param name="id">identificador da feira</param>
        /// <returns></returns>
        [HttpDelete("id/{id}")]
        public async Task<ActionResult<dynamic>> DeleteAsync([FromRoute] int id)
        {
            try
            {
                return ("", await fairUpdater.DeleteByIdAsync(id));

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }

    }
}
