﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Dominio.Core.Entities;
using Utilitario;

namespace Infraestructura.Data.SqlServer
{
	public class DMenu
	{
		//public string perValue { get => "ID"; }
		//public string perText { get => "PERFIL"; }

		//public string KeyMember { get => "N_IdMenu"; }
		//public string DisplayMember { get => "V_descripcion"; }
		//public string ValueMember { get => "N_IdMenu"; }
		//public string ParentMember { get => "N_IdPadre"; }

		//private string tablaMePer { get => "TBD_MENUPERFIL"; }

		#region Atributos Menu
		internal string tablaMenu { get => "TBC_MENU"; }

		internal string tIdMen { get => "N_IdMenu"; }
		internal string tDesMen { get => "V_Descripcion"; }
		internal string tIdPadMen { get => "N_IdPadre"; }
		internal string tPosMen { get => "N_Posicion"; }
		internal string tIcoMen { get => "V_Icono"; }
		internal string tHabMen { get => "S_Habilitado"; }
		internal string tUrlMen { get => "V_Url"; }
		internal string tIdAppMen { get => "N_IdApli"; }

		public string cIdMen { get => "IdMenu"; }
		public string cDesMen { get => "Descripcion"; }
		public string cIdPadMen { get => "IdPadre"; }
		public string cPosMen { get => "Posicion"; }
		public string cIcoMen { get => "Icono"; }
		public string cHabMen { get => "Habilitado"; }
		public string cUrlMen { get => "Url"; }
		public string cIdAppMen { get => "IdApli"; }
		#endregion

		DtUtilitario com = new DtUtilitario();
		List<SqlParameter> listaParametros = new List<SqlParameter>();

		#region Buscar todos los menues por perfil de cada aplicación
		public DataTable DataSource(EAplicacion oeApli, EPerfil oePerfil)
		{
			try
			{
				listaParametros.Clear();
				SqlParameter idApli = new SqlParameter("@idapli", oeApli.idApli);
				SqlParameter idPerfil = new SqlParameter("@idperfil", oePerfil.idPerfil);
				listaParametros.Add(idApli); listaParametros.Add(idPerfil);
				return com.EjecutaConsulta("XXX_APLICACION_PERFIL_MENU_LISTAR", listaParametros, 1);
			}
			catch (Exception ex)
			{
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Actualizar permisos de menues por perfil
		public void ActualizarMenuPerfil(EPerfil oePerfil, string lista)
		{
			try
			{
				SqlParameter cadena = new SqlParameter("@lista", lista);
				SqlParameter idPerfil = new SqlParameter("@idperfil", oePerfil.idPerfil);
				listaParametros.Add(cadena); listaParametros.Add(idPerfil);
				com.TransUnica("XXX_TBD_ActualizarMenuDePerfil", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Listar todos los perfiles de cada aplicación
		public DataTable ListarPerfilApli(EAplicacion oeApli)
		{
			try
			{
				listaParametros.Clear();
				SqlParameter idApli = new SqlParameter("@idaplicacion", oeApli.idApli);
				listaParametros.Add(idApli);
				return com.EjecutaConsulta("XXX_TBC_PerfilAplicacion", listaParametros, 1);
			}
			catch (Exception ex)
			{
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion
	}
}