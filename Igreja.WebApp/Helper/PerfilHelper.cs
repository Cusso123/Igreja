namespace Igreja.WebApp.Helper
{
	public static class PerfilHelper
	{
		public static string GetPerfilDescricao(int perfilId)
		{
			return perfilId switch
			{
				1 => "1-Pastor",
				2 => "2-Membro",
				_ => "Desconhecido"
			};
		}
	}
}
