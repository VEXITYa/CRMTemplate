using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class CarsSearchParams : BaseSearchParams
	{
		public CarsSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}
