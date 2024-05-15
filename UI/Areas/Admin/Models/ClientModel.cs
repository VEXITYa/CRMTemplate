using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ClientModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Discount")]
		public int Discount { get; set; }

		public static ClientModel FromEntity(Client obj)
		{
			return obj == null ? null : new ClientModel
			{
				Id = obj.Id,
				Name = obj.Name,
				PhoneNumber = obj.PhoneNumber,
				Discount = obj.Discount,
			};
		}

		public static Client ToEntity(ClientModel obj)
		{
			return obj == null ? null : new Client(obj.Id, obj.Name, obj.PhoneNumber, obj.Discount);
		}

		public static List<ClientModel> FromEntitiesList(IEnumerable<Client> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Client> ToEntitiesList(IEnumerable<ClientModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
