using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationary_shop.Models;
namespace stationary_shop.Repositories
{
    public class StoreRepo
    {
        public static List<Store> List()
	{
		var query = $@"SELECT * FROM `store` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Store>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Name = dre.From<string>("name");
				t.Location = dre.From<string>("location");
				t.Number= dre.From<string>("phone_number");
				t.Mail = dre.From<string>("email");
                t.Manager = dre.From<string>("manager");
                t.WorkHours = dre.From<string>("work_hours");
			});

		return result;
	}
	public static Store Find(string id)
	{
		var query = $@"SELECT * FROM `store` WHERE id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<Store>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Name = dre.From<string>("name");
				t.Location = dre.From<string>("location");
				t.Number= dre.From<string>("phone_number");
				t.Mail = dre.From<string>("email");
                t.Manager = dre.From<string>("manager");
                t.WorkHours = dre.From<string>("work_hours");
				});

			return result;
		}
		return null;
	}
	public static void Insert(Store store)
	{
		var query =
			$@"INSERT INTO `store`
			(
				id,
				name,
				location,
				phone_number,
				email,
                manager,
                work_hours
			)
			VALUES(
				?id,
				?name,
				?location,
				?number,
				?mail,
                ?manager,
                ?workhours
			)";

		Sql.Insert(query, args => {
			args.Add("?id", store.Id);
			args.Add("?name", store.Name);
			args.Add("?location", store.Location);
			args.Add("?number", store.Number);
			args.Add("?mail", store.Mail);
            args.Add("?manager", store.Manager);
            args.Add("?workhours", store.WorkHours);
		});
	}
		public static void Update(Store store)
	{
		var query =
			$@"UPDATE `store`
			SET
				name=?name,
				location=?surname,
				number=?mail,
				mail=?number,
				manager=?birthdate,
				work_hours=?loyaltyprog
			WHERE
				id=?id";

		Sql.Update(query, args => {
			args.Add("?id", store.Id);
			args.Add("?name", store.Name);
			args.Add("?surname", store.Location);
			args.Add("?mail", store.Number);
			args.Add("?number", store.Mail);
			args.Add("?birthdate", store.Manager);
			args.Add("?loyaltyprog", store.WorkHours);
		});
	}
	public static void Delete(string id)
	{
		var query = $@"DELETE FROM `store` WHERE id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
    }
}