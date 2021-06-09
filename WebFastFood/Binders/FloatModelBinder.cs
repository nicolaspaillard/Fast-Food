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
using System.Runtime.ExceptionServices;

namespace WebFastFood.Binders
{
    public class FloatModelBinder : IModelBinder
    {
        private readonly NumberStyles _supportedStyles;

        public FloatModelBinder(NumberStyles supportedStyles)
        {
            this._supportedStyles = supportedStyles;
        }

        /// <inheritdoc />
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
            string modelName = bindingContext.ModelName;
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(modelName);
            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            ModelStateDictionary modelState = bindingContext.ModelState;
            modelState.SetModelValue(modelName, value);
            ModelMetadata modelMetadata = bindingContext.ModelMetadata;
            Type underlyingOrModelType = modelMetadata.UnderlyingOrModelType;
            Task completedTask;
            try
            {
                string firstValue = value.FirstValue;
                CultureInfo culture = value.Culture;
                object obj;
                if (string.IsNullOrWhiteSpace(firstValue))
                {
                    obj = null;
                }
                else
                {
                    if (!(underlyingOrModelType == typeof(float)))
                    {
                        throw new NotSupportedException();
                    }
                    //TODO mandatory => culture invariant (.NET Core bug for other culture)
                    //obj = float.Parse(firstValue, this._supportedStyles, culture);
                    obj = float.Parse(firstValue, this._supportedStyles, CultureInfo.InvariantCulture);
                }
                if (obj == null && !modelMetadata.IsReferenceOrNullableType)
                {
                    modelState.TryAddModelError(modelName, modelMetadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor.Invoke(value.ToString()));
                    completedTask = Task.CompletedTask;
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(obj);
                    completedTask = Task.CompletedTask;
                }
            }
            catch (Exception sourceException)
            {
                if (!(sourceException is FormatException) && sourceException.InnerException != null)
                {
                    sourceException = ExceptionDispatchInfo.Capture(sourceException.InnerException).SourceException;
                }
                modelState.TryAddModelError(modelName, sourceException, modelMetadata);
                completedTask = Task.CompletedTask;
            }
            return completedTask;
        }
    }
}