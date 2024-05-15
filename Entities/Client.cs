using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public int Discount { get; set; }

		public Client(int id, string name, string phoneNumber, int discount)
		{
			Id = id;
			Name = name;
			PhoneNumber = phoneNumber;
			Discount = discount;
		}
	}
}
