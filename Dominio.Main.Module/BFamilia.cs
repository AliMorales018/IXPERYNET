using System.Data;
using Infraestructura.Data.SqlServer;
namespace Dominio.Main.Module
{
    public class BFamilia
    {
        DFamilia odFamilia = new DFamilia();

        public DataTable LlenarCombo()
        {
            return odFamilia.LlenarCombo();
        }
        public DataTable ListarFamilia()
        {
            return odFamilia.ListarFamilia();
        }
        public void InsertFamilia(DataSet ds)
        {
            odFamilia.InsertFamilia(ds);
        }
        public void UpdateFamilia(int idFam, string nomFam)
        {
            odFamilia.UpdateFamilia(idFam, nomFam);
        }
        public void DeleteFamilia(int idFam)
        {
            odFamilia.DeleteFamilia(idFam);
        }
        public DataTable BuscarFamilia(string famBuscar)
        {
            return odFamilia.BuscarFamilia(famBuscar);
        }
    }
}
