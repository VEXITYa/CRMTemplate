using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Car
	{
		public int Id { get; set; }
		public string Vin { get; set; }
		public int ClientId { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int? Year { get; set; }

		public Car(int id, string vin, int clientId, string brand, string model, int? year)
		{
			Id = id;
			Vin = vin;
			ClientId = clientId;
			Brand = brand;
			Model = model;
			Year = year;
		}
	}
}
