using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace đồ_án.Models.View_Model
{
    public class ProductDetailVM
    {
        public Product product { get; set; }

        //số lượng đặt mua
        public int quantity { get; set; } = 1;
        //tính giá trị tạm thời (tạm tính)
        public decimal estimatedValue => quantity * product.ProductPrice;

        //thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; } //trang hiện tại
        public int PageSize { get; set; } = 3; //số sp mỗi trang

        //8 sản phảm cùng danh mục
        public PagedList.IPagedList<Product> RelatedProducts { get; set; }
        //public List<Product> RelatedProduct { get; set; }

        //8 sản phẩm bán chạy nhất trong mục
        public PagedList.IPagedList<Product> TopProducts { get; set; }
    }
}
