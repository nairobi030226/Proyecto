using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto.Interface;

namespace Proyecto.Data
{
    public class PersonPhoneSpRepository : IPersonPhoneSpRepository
    {
        /// <summary>
        #region PersonPhoneSpRepository
        private readonly AddDbContext _context;

        public PersonPhoneSpRepository(AddDbContext context)
        {
            _context = context;
        }

        public async Task PutPersonPhonesBySpAsync(DataTable personPhones)
        {
            var cnx = _context.Database.GetDbConnection();
            await using (cnx)
            {
                if (cnx.State != ConnectionState.Open)
                    await cnx.OpenAsync();

                using var command = cnx.CreateCommand();
                command.CommandText = "dbo.usp_oe_PutPersonPhoneTbl_v1"; // Nombre del SP que tú definas
                command.CommandType = CommandType.StoredProcedure;

                var param = new SqlParameter("@PersonPhoneTable", SqlDbType.Structured)
                {
                    Value = personPhones,
                    TypeName = "dbo.PersonPhoneTblType" // <- Asegúrate que exista este tipo de tabla
                };

                command.Parameters.Add(param);
                await command.ExecuteNonQueryAsync();
            }
        }
        #endregion
    }
}
