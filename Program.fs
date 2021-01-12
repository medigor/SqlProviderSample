

open System
open FSharp.Data.Sql
open System.Data

[<Literal>]
let Conn = "Server=192.168.1.89; Port=5432; Database=test1;User Id=postgres;Password=postgres;"
type Base = SqlDataProvider<DatabaseVendor = Common.DatabaseProviderTypes.POSTGRESQL, ConnectionString = Conn, UseOptionTypes = true>

[<EntryPoint>]
let main argv =
    let context = Base.GetDataContext(Conn)
    query {
        for user in context.Public.Users do
        select (user.Id, user.Name)
        take 5
    } |> Seq.iter (fun x -> Console.WriteLine(x))
    0 