using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace ConsoleApp2
{
	internal class Program
	{
		public static Connect conn = new Connect();
		public static void GetAllData()
		{
			conn.Connection.Open();

			string sql = "select * from `players`";
			MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
			MySqlDataReader dr = cmd.ExecuteReader();
			

			do {
				dr.Read();

				var player = new
				{
					id = dr.GetInt32(0),
					name = dr.GetString(1),
					height = dr.GetInt32(2),
					weight = dr.GetInt32(3),
					createdtime = dr.GetDateTime(4)
				};

				Console.WriteLine($"A játékos neve {player.name}, {player.createdtime}");
			} while (dr.Read());

			conn.Connection.Close();
		}

		public static void SetData() {
			Console.WriteLine("Kérem a személy nevét!");
			string n = Console.ReadLine();
			Console.WriteLine("Kérem a személy magasságát!");
			int h = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Kérem a személ súlyát");
			int w = Convert.ToInt32(Console.ReadLine());

			var player = new
			{
				name = n,
				height = h,
				weight = w
			};
			conn.Connection.Open();
			string sql = $"INSERT INTO `players`(`name`, `height`, `weight`) VALUES ('{player.name}','{player.height}','{player.weight}')";
			MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
			conn.Connection.Close();
		}

		public static void DeleteData() {

			conn.Connection.Open();

			Console.WriteLine("Adja meg az updatelni kívánt személy ID-jét!");
			int id = Convert.ToInt32(Console.ReadLine());

			string sql = $"DELETE FROM `players`WHERE id = {id}";
			MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
			MySqlDataReader dr = cmd.ExecuteReader();

			for (int i = 0; i < id; i++)
			{
				dr.Read();
			}
			cmd.ExecuteNonQuery();
			conn.Connection.Close();

		}

		public static void UpdateData()
		{
            conn.Connection.Open();
            Console.WriteLine($"Adja meg a frissíteni kívánt játékos ID-jét!");
			int userId = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Kérem a személy nevét!");
			string n = Console.ReadLine();
            Console.WriteLine("Kérem a személy magasságát!");
            string h = Console.ReadLine();
            Console.WriteLine("Kérem a személy súlyát!");
            string w = Console.ReadLine();

			var player = new
			{
				name = n,
				height = h,
				weight = w,
			};
			string sql = $"UPDATE `players` SET `name`='{player.name}',`height`={player.height}, `weight`= {player.weight} WHERE `id` = {userId}";
			MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
			cmd.ExecuteNonQuery();
			conn.Connection.Close();
		}
		
		static void Main(string[] args)
		{
			UpdateData();
		}
	}
}
