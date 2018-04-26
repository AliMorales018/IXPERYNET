using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;

public partial class Familia : System.Web.UI.Page
{
    DFamilia dFamilia = new DFamilia();

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        //int id = Convert.ToInt32(txtIdFamilia.Text);
        String nombre = txtNomFamilia.Text;

        EFamilia ofami = new EFamilia
        {
          //  idFamilia = id,
            nomFamilia = nombre
        };

        dFamilia.InsertarFamilia(ofami);

    }
}