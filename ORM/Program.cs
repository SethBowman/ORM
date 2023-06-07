﻿using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM;
using System.Threading.Channels;
using System.Transactions;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

//Console.Write("Type a new Department name: ");

//var newDepartment = Console.ReadLine();

//repo.InsertDepartment(newDepartment);

var departments  = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.Name);
}