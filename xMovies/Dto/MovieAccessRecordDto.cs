using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMovies.Dto
{
    public class MovieAccessRecordDto
    {
        public int Id { set; get; }
        public int CustomerId { set; get; }
        public int MovieId { set; get; }
    }
}