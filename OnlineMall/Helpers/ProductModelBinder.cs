using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OnlineMall.Areas.Identity.Data;
using OnlineMall.Models;
using System.Globalization;
using System.Reflection;

namespace OnlineMall.Helpers
{

    public class ProductModelBinder : IModelBinder
    {
		private readonly ApplicationDbContext _context;
		public ProductModelBinder(ApplicationDbContext context)
		{
            _context = context;
		}
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var data = bindingContext.HttpContext.Request.Form.Keys;

            var modelId = bindingContext.ValueProvider.GetValue("Id").FirstValue;
            Product product = _context.Products.Find(int.Parse(modelId));

            foreach (var key in data)
			{
                var propertyValue = bindingContext.ValueProvider.GetValue(key).FirstValue;
                PropertyInfo property = typeof(Product).GetProperty(key);

                if (key.Equals("Id") || property == null)
                    continue;

				if (key.Equals("Size"))
				{
                    property.SetValue(product, (ProductSize)Enum.Parse(typeof(ProductSize),propertyValue), null);
                }
				else
				{
                    property.SetValue(product, Convert.ChangeType(propertyValue, property.PropertyType, CultureInfo.InvariantCulture), null);
				}


                
            }

            
            bindingContext.Result = ModelBindingResult.Success(product);
            return Task.CompletedTask;
        }

    }

    public class ProductModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Product))
            {
                return new BinderTypeModelBinder(typeof(ProductModelBinder));
            }

            return null;
        }
    }
}
