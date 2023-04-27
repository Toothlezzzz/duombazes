using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationary_shop.Models;
namespace stationary_shop.Repositories
{
    public class CustomersRepo
    {
        public static List<Customers> List()
	{
		var query = $@"SELECT * FROM `customers` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Customers>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Name = dre.From<string>("first_name");
				t.Surname = dre.From<string>("last_name");
				t.Mail = dre.From<string>("contact_email");
				t.PhoneNumber = dre.From<string>("phone_number");
                t.BirthDate = dre.From<DateTime>("date_of_birth");
                t.LoyaltyProgramMembership = dre.From<int>("loyalty_program_membership");
			});

		return result;
	}
	public static Customers Find(string id)
	{
		var query = $@"SELECT * FROM `customers` WHERE id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<Customers>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Name = dre.From<string>("first_name");
				t.Surname = dre.From<string>("last_name");
				t.Mail = dre.From<string>("contact_email");
				t.PhoneNumber = dre.From<string>("phone_number");
                t.BirthDate = dre.From<DateTime>("date_of_birth");
                t.LoyaltyProgramMembership = dre.From<int>("loyalty_program_membership");
				});

			return result;
		}
		return null;
	}
	public static void Insert(Customers customer)
	{
		var query =
			$@"INSERT INTO `customers`
			(
				id,
				first_name,
				last_name,
				contact_email,
				phone_number,
                date_of_birth,
                loyalty_program_membership
			)
			VALUES(
				?id,
				?name,
				?surname,
				?mail,
				?number,
                ?birthdate,
                ?loyaltyprog
			)";

		Sql.Insert(query, args => {
			args.Add("?id", customer.Id);
			args.Add("?name", customer.Name);
			args.Add("?surname", customer.Surname);
			args.Add("?mail", customer.Mail);
			args.Add("?number", customer.PhoneNumber);
            args.Add("?birthdate", customer.BirthDate);
            args.Add("?loyaltyprog", customer.LoyaltyProgramMembership);
		});
	}
		public static void Update(Customers customer)
	{
		var query =
			$@"UPDATE `customers`
			SET
				first_name=?name,
				last_name=?surname,
				contact_email=?mail,
				phone_number=?number,
				date_of_birth=?birthdate,
				loyalty_program_membership=?loyaltyprog
			WHERE
				id=?id";

		Sql.Update(query, args => {
			args.Add("?id", customer.Id);
			args.Add("?name", customer.Name);
			args.Add("?surname", customer.Surname);
			args.Add("?mail", customer.Mail);
			args.Add("?number", customer.PhoneNumber);
			args.Add("?birthdate", customer.BirthDate);
			args.Add("?loyaltyprog", customer.LoyaltyProgramMembership);
		});
	}
	public static void Delete(string id)
	{
		var query = $@"DELETE FROM `customers` WHERE id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
    }
}