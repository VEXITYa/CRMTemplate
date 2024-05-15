using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CarModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Vin")]
		public string Vin { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "ClientId")]
		public int ClientId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Brand")]
		public string Brand { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Model")]
		public string Model { get; set; }

		[Display(Name = "Year")]
		public int? Year { get; set; }

		public static CarModel FromEntity(Car obj)
		{
			return obj == null ? null : new CarModel
			{
				Id = obj.Id,
				Vin = obj.Vin,
				ClientId = obj.ClientId,
				Brand = obj.Brand,
				Model = obj.Model,
				Year = obj.Year,
			};
		}

		public static Car ToEntity(CarModel obj)
		{
			return obj == null ? null : new Car(obj.Id, obj.Vin, obj.ClientId, obj.Brand, obj.Model, obj.Year);
		}

		public static List<CarModel> FromEntitiesList(IEnumerable<Car> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Car> ToEntitiesList(IEnumerable<CarModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
