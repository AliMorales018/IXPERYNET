using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
	public class DPerfil
	{
		#region Atributos Perfil
		internal string tablaPer { get => "TBD_MENUPERFIL"; }

		internal string tIdPer { get => "N_IdPerfil"; }
		internal string tIdAppPer { get => "N_IdApli"; }
		internal string tNomPer { get => "V_Perfil"; }
		internal string tEstPer { get => "S_Est"; }
		internal string tFecCrea { get => "D_FechaCreacion"; }
		internal string tUsuCrea { get => "V_UsuarioCreacion"; }
		internal string tFecMod { get => "D_FechaModificacion"; }
		internal string tUsuMod { get => "V_UsuarioModificacion"; }

		public string cIdPer { get => "IdPerfil"; }
		public string cIdAppPer { get => "IdApli"; }
		public string cNomPer { get => "Perfil"; }
		public string cEstPer { get => "Est"; }
		public string cFecCrea { get => "FechaCreacion"; }
		public string cUsuCrea { get => "UsuarioCreacion"; }
		public string cFecMod { get => "FechaModificacion"; }
		public string cUsuMod { get => "UsuarioModificacion"; }
		#endregion


	}
}
