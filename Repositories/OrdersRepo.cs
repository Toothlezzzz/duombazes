using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationary_shop.Models;
namespace stationary_shop.Repositories
{
    public class OrdersRepo
    {
        public static List<Orders> List()
	{
		var query = $@"SELECT * FROM `orders` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Orders>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.OrderDate = dre.From<DateTime>("order_date");
				t.OrderStatus = dre.From<int>("order_status");
				t.PaymentStatus = dre.From<int>("payment_status");
				t.ShippingAdress = dre.From<string>("shipping_adress");
			});

		return result;
	}
	public static Orders Find(string id)
	{
		var query = $@"SELECT * FROM `orders` WHERE id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<Orders>(drc, (dre, t) => {
					t.Id = dre.From<int>("id");
					t.OrderDate = dre.From<DateTime>("order_date");
					t.OrderStatus = dre.From<int>("order_status");
					t.PaymentStatus = dre.From<int>("payment_status");
					t.ShippingAdress = dre.From<string>("shipping_adress");
				});

			return result;
		}
		return null;
	}
	public static void Insert(Orders order)
	{
		var query =
			$@"INSERT INTO `orders`
			(
				id,
				order_date,
				order_status,
				payment_status,
				shipping_adress
			)
			VALUES(
				?id,
				?date,
				?ordstatus,
				?paymstatus,
				?adress
			)";

		Sql.Insert(query, args => {
			args.Add("?id", order.Id);
			args.Add("?date", order.OrderDate);
			args.Add("?ordstatus", order.OrderStatus);
			args.Add("?paymstatus", order.PaymentStatus);
			args.Add("?adress", order.ShippingAdress);
		});
	}
	public static void Delete(string id)
	{
		var query = $@"DELETE FROM `orders` WHERE id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
    }
}