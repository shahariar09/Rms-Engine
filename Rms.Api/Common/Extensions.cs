
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rms.Api.Middleware;
using Rms.Models.Common.Paging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Api.Common
{
    public static class Extensions
    {
       
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UserLoggingHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerAndPerformanceMiddleware>();
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
        }
        public static void AddPagination(this HttpResponse response, int currentPage, int itemPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
        public static DataTable ConvertListToDataTable<T>(List<T> list)
        {
            DataTable dataTable = new DataTable();

            // Get the type of the object in the list
            Type type = typeof(T);

            // Get all the public properties of the object
            var properties = type.GetProperties();

            // Create the columns in the DataTable based on the object's properties
            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;

                // If the property type is nullable, get the underlying type
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }

                // Add the column to the DataTable
                dataTable.Columns.Add(property.Name, propertyType);
            }

            // Populate the DataTable with data from the list
            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();

                foreach (var property in properties)
                {
                    object value = property.GetValue(item);

                    // Check if the value is null and set DBNull instead
                    row[property.Name] = value ?? DBNull.Value; // Use DBNull.Value for null values
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }


    }
}
