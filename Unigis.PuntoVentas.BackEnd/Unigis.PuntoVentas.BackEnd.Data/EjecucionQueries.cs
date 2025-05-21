using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Unigis.PuntoVentas.BackEnd.Data
{
    public class EjecucionQueries
    {
        private readonly ApplicationDbContext _context;
        public EjecucionQueries(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<DataTable> GetDataTable(string query)
        {
            var dataTable = new DataTable();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 30;

                    _context.Database.OpenConnection();

                    using (var result = await command.ExecuteReaderAsync())
                        dataTable.Load(result);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                dataTable?.Dispose();

                if (_context.Database.GetDbConnection().State == ConnectionState.Open)
                    _context.Database.CloseConnection();
            }
        }
    }
}