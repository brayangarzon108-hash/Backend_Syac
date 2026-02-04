using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class StudentSubjectCore : IStudentSubjectCore
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly IStudentSubjectRepository _repo;

        public StudentSubjectCore(IStudentSubjectRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        ///  Guardar Materia Alumno
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Insert Materia Alumnos
        public async Task<GeneralResponse> InsertAlumnSubject(StudentSubjectResponse info)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes

            var data = await _repo.EnrollSubjectAsync(info.StudentId, info.SubjectId);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Message = data
                };
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.BadRequest,
                    Message = data
                };
            }
        }
        #endregion

        /// <summary>
        /// Actualizar Alumno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        public async Task<GeneralResponse> DeleteAsync(int studentId)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Eliminar Alumno
            var data = await _repo.DeleteAsync(studentId);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Data = data,
                };
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.BadRequest,
                    Message = data
                };
            }
        }

        /// <summary>
        ///  Consulto Alumnos
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Alumnos
        public async Task<GeneralResponse> GetAllAsync(int studentid)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes
            var data = await _repo.GetStudentClassmatesAsync(studentid);

            if (data.Count() > 0)
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
            return generalResponse;
        }
        #endregion

        /// <summary>
        ///  Consulto Materia
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Materias
        public async Task<GeneralResponse> GetAllSubjectAsync()
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes
            var data = await _repo.GetAllSubjectAsync();

            if (data.Count() > 0)
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
            return generalResponse;
        }
        #endregion
    }
}
