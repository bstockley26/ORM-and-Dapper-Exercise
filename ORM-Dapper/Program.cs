using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var depRepo = new DepartmentRepo(conn);
var productsRepo = new ProductRepo(conn);

//Console.WriteLine("Enter the name of the department you would like to create");

//var depName = Console.ReadLine();

//depRepo.InsertDepartment(depName);

//var departments = depRepo.GetAllDepartments();

//foreach (var dep in departments)
//{
//    Console.WriteLine($"ID: {dep.DepartmentID}| Name: {dep.Name}");
//}

var products = productsRepo.GetAllPRoducts();

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductID}| Name: {product.Name}|CategoryID: {product.CategoryID}| On Sale: {product.OnSale}| Stock Level: {product.StockLevel}");
}

