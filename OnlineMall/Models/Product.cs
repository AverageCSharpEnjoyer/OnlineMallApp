using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OnlineMall.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMall.Models
{
	[ModelBinder(BinderType = typeof(ProductModelBinder))]
	public class Product
	{
		public int Id { get; set; }
		public string? ShortName { get; set; }
		public string? FullName { get; set; }

        [Range(1,9999.99)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[EnumDataType(typeof(ProductSize))]
		public ProductSize Size { get; set; }
		public string? Color { get; set; }
		public string? Description { get; set; }
		public string? ImgPath { get; set; }
	}

	public enum ProductSize
	{
		XS,
		S,
		M,
		L,
		XL,
		XXL
	}
}
