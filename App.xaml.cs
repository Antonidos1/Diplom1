using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace Diplom1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    internal class Conection_db
    {
        static async Task MainConect(string[] args)
        {
            var host = "rc1b-feov1zpxl7wupioe.mdb.yandexcloud.net";
            var port = "6432";
            var db = "diplom_bd";
            var username = "admin1";
            var password = "12345678";
            var connString = $"Host={host};Port={port};Database={db};Username={username};Password={password};Ssl Mode=VerifyFull;";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT VERSION();", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
            }
        }
    }
}
