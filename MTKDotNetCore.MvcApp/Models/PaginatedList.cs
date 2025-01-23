namespace MTKDotNetCore.MvcApp.Models
{
	#region PaginatedList

	public class PaginatedList<T>
	{
		public List<T> Items { get; set; }
		public int PageIndex { get; set; }
		public int TotalPages { get; set; }

		#region PaginatedList

		public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
		{
			PageIndex = pageIndex;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			Items = items;
		}

		#endregion

		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;

		#region PaginatedList Create

		public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return new PaginatedList<T>(items, count, pageIndex, pageSize);
		}

		#endregion

	}

	#endregion
}
