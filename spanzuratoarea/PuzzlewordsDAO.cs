using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace spanzuratoarea
{
    class PuzzlewordsDAO
    {
        public static List<string> findAll()
        {
            List<string> rez = new List<string>();

            // preia conexiune de la db

            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            // executa query pentru preluare date + transfer in lista

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM puzzlewords";

            MySqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                string cuvant = data["cuvant"].ToString();
                rez.Add(cuvant);
            }

            // inchide conexiune + cleanup
            data.Close();
            con.Close();

            return rez;
        }
    }
}
