using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Globalization;

namespace WebFastFood.Binders
{
    public class FloatingTypeModelBinderProvider : IModelBinderProvider
    {
        internal static readonly NumberStyles SupportedStyles = NumberStyles.Float | NumberStyles.AllowThousands; //value = 231

        /// <inheritdoc />
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Type underlyingOrModelType = context.Metadata.UnderlyingOrModelType;
            if (underlyingOrModelType == typeof(decimal))
            {
                return new DecimalModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
            }
            if (underlyingOrModelType == typeof(double))
            {
                return new DoubleModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
            }
            if (underlyingOrModelType == typeof(float))
            {
                return new FloatModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
            }
            return null;
        }
    }
}