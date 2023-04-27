using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationary_shop.Models;
using stationary_shop;


namespace stationary_shop.Repositories
{
    public class ProductsRepo
    {
		public static List<Products> List()
		{
			var query = $@"SELECT * FROM `products` ORDER BY id ASC";
			var drc = Sql.Query(query);

			var result = 
				Sql.MapAll<Products>(drc, (dre, t) => {
					t.ID = dre.From<int>("id");
					t.Name = dre.From<string>("name");
					t.Description = dre.From<string>("description");
					t.Price = dre.From<int>("price");
					t.Category = dre.From<string>("category");
					t.Brand = dre.From<string>("brand");
					t.Size = dre.From<string>("size");
				});

			return result;
		}

		public static void Update(Products product)
		{
			var query =
				$@"UPDATE `products`
				SET
					name=?name,
					description=?desc,
					price=?price,
					category=?cat,
					brand=?brand,
					size=?size
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?id", product.ID);
				args.Add("?name", product.Name);
				args.Add("?desc", product.Description);
				args.Add("?price", product.Price);
				args.Add("?cat", product.Category);
				args.Add("?brand", product.Brand);
				args.Add("?size", product.Size);
			});
		}
		public static Products Find(string id)
		{
			var query = $@"SELECT * FROM `products` WHERE id=?id";

			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			if( drc.Count > 0 )
			{
				var result = 
					Sql.MapOne<Products>(drc, (dre, t) => {
					t.ID = dre.From<int>("id");
					t.Name = dre.From<string>("name");
					t.Description = dre.From<string>("description");
					t.Price = dre.From<int>("price");
					t.Category = dre.From<string>("category");
					t.Brand = dre.From<string>("brand");
					t.Size = dre.From<string>("size");
					});

				return result;
			}
			return null;
		}

		public static void Delete(string id)
		{
			var query = $@"DELETE FROM `products` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", id);
			});
		}

		public static void Insert(Products product)
		{
			var query =
				$@"INSERT INTO `products`
				(
					name,
					description,
					price,
					category,
					brand,
					size
				)
				VALUES(
					?name,
					?desc,
					?price,
					?cat,
					?brand,
					?size
				)";

			Sql.Insert(query, args => {
				args.Add("?name", product.Name);
				args.Add("?desc", product.Description);
				args.Add("?price", product.Price);
				args.Add("?cat", product.Category);
				args.Add("?brand", product.Brand);
				args.Add("?size", product.Size);
			});
		}
	}
}