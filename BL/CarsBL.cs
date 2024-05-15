using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Car = Entities.Car;

namespace BL
{
	public class CarsBL
	{
		public async Task<int> AddOrUpdateAsync(Car entity)
		{
			entity.Id = await new CarsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new CarsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(CarsSearchParams searchParams)
		{
			return new CarsDal().ExistsAsync(searchParams);
		}

		public Task<Car> GetAsync(int id)
		{
			return new CarsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new CarsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Car>> GetAsync(CarsSearchParams searchParams)
		{
			return new CarsDal().GetAsync(searchParams);
		}
	}
}

