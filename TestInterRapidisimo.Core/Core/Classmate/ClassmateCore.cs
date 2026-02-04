using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class ClassmateCore : IClassmateCore
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly IClassmateRepository _repo;

        public ClassmateCore(IClassmateRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        ///  Consulto Grupo Alumnos
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Grupo Alumnos
        public async Task<GeneralResponse> GetClassmatesAsync(int studentId, int page, int pageSize, int subjectId, string nameStudent = "")
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes
            if (studentId > 0)
            {
                var data = await _repo.GetClassmatesAsync(studentId, page, pageSize, subjectId, nameStudent);

                if (data.CountRegister > 0)
                {
                    generalResponse.Data = data;
                }
                else
                {
                    return generalResponse = new GeneralResponse
                    {
                        Status = (int)Enumerations.enumTypeMessageResponse.NotFound,
                        Message = "No se encontro data con los filtro seleccionados."
                    };
                }
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.NotFound,
                    Message = "No se encontro Id de alumno"
                };
            }
            return generalResponse;
        }
        #endregion
    }
}
