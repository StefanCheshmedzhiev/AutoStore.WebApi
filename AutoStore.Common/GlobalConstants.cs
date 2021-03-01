using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Common
{
    public class GlobalConstants
    {
        //Brand
        public const int BrandNameMinLength = 5;
        public const int BrandNameMaxLength = 30;

        //Customer
        public const int UsernameMinLength = 6;
        public const int UsernameMaxLength = 30;
        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 50;
        public const int CustomerNameMinLength = 3;
        public const int CustomerNameMaxLength = 50;

        //CustomerProduct
        public const int CustomerProductMinQuantity = 1;

        //Order
        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 40;
        public const int AddressTextMinLength = 5;
        public const int AddressTextMaxLength = 70;

        //Car
        public const int CarModelNameMinLength = 3;
        public const int CarModelNameMaxLength = 50;
        public const int SellableMinPrice = 0;
        public const int CarMinAge = 0;
        public const int CarMaxAge = 200;

        //Product
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 50;
    }
}
