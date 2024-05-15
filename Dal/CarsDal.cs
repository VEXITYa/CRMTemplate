using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class CarsDal : BaseDal<DefaultDbContext, Car, Entities.Car, int, CarsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public CarsDal()
		{
		}

		protected internal CarsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Car entity, Car dbObject, bool exists)
		{
			dbObject.Vin = entity.Vin;
			dbObject.ClientId = entity.ClientId;
			dbObject.Brand = entity.Brand;
			dbObject.Model = entity.Model;
			dbObject.Year = entity.Year;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Car>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Car> dbObjects, CarsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Car>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Car> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Car, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Car, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Car ConvertDbObjectToEntity(Car dbObject)
		{
			return dbObject == null ? null : new Entities.Car(dbObject.Id, dbObject.Vin, dbObject.ClientId,
				dbObject.Brand, dbObject.Model, dbObject.Year);
		}
	}
}
