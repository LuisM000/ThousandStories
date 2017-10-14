
namespace Infrastructure
{
    public class Pagination
    {
        public Pagination(int pageNumber, int rowsPerPage)
        {
            this.PageNumber = pageNumber;
            this.RowsPerPage = rowsPerPage;
        }

        public int PageNumber { get; private set; }
        public int RowsPerPage { get; private set; }

        public int SkippedRows
        {
            get
            {
                return this.PageNumber * this.RowsPerPage;
            }
        }
    }
}
