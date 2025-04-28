
using EFCoreVsDapper;

var repository = new GameCharacterRepository();
Console.WriteLine("EF Core.....");
repository.EF_Create();
repository.EF_Read();
repository.EF_Update();
repository.EF_Read();
repository.EF_Delete();

Console.WriteLine("Dapper.....");
repository.Dapper_Create();
repository.Dapper_Read();
repository.Dapper_Update();
repository.Dapper_Read();
repository.Dapper_Delete();


// This is a simple comparison of EF Core and Dapper for CRUD operations.

// EF Core is more faster for READ
// EF Core is more faster for UPDATE

// Dapper is more faster for DELETE
// Dapper is more faster for CREATE