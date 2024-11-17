using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace đồ_án.Models.View_Model
{
    public class HomeProductVM
    {
        //tiêu chí để search theo tên, mô tả sản phẩm
        //hoặc loại sản phẩm
        public string SearchTerm { get; set; }

        //các thuộc tính hỗ trợ phân trang 
        public int PageNumber { get; set; } //trang hiện tại
        public int PageSize { get; set; } = 10; //số sp mỗi trang

        //ds sp nổi bật
        public List<Product> FeaturedProducts { get; set; }

        //ds sp đã phân trang (giày, áo, ..)
        public PagedList.IPagedList<Product> GiayProducts { get; set; }
        public PagedList.IPagedList<Product> AoProducts { get; set; }
        public PagedList.IPagedList<Product> PhukienProducts { get; set; }

    }
}